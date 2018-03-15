using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

using wiizard.Behaviors;

using WiimoteLib;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;

namespace wiizard
{
    /*
     * TODO
     *  - ボタンの種類にN_STICK_UP, N_STICK_DOWN, N_STICK_LEFT,N_STICK_RIGHTを追加
     *  - Profileに"UseJoystickAsButton"(bool)を追加
     *  - これらに伴う変更
     *  - UIを、左半分: マウス・キーボード割当設定, 右半分: ボタン/IR・加速度/詳細設定の3タブ構成に変更
     */
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            m_bMgr.Add(new StandardBehavior());
            m_bMgr.Add(new MinecraftBehavior());

        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            // UIの初期化
            combo_behavior.Items.AddRange(m_bMgr.GetBehaviorNames().ToArray());

            // Profileフォルダの読み込み
            if (!Directory.Exists("./Profile/"))
            {
                // Defaultプロファイルの作成
                Directory.CreateDirectory("./Profile/");
                var defaultProfile = new Profile();
                defaultProfile.Name = "Default";
                defaultProfile.Behavior = (new StandardBehavior()).GetName();
                defaultProfile.ActionAssignments = new Dictionary<WiimoteModel, List<ActionAttribute>>();
                defaultProfile.Save("./Profile/default.json");
            }

            LoadProfiles();

            // ファイル変更の検知
            m_fileSystemWatcher.Path = "./Profile";
            m_fileSystemWatcher.Filter = "*.json";
            m_fileSystemWatcher.SynchronizingObject = this;
            m_fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess;
            m_fileSystemWatcher.Changed += m_fileSystemWatcher_Changed;
            m_fileSystemWatcher.EnableRaisingEvents = true;　//監視を開始

            m_wm = new Wiimote();

            try
            {
                // 接続
                m_wm.WiimoteChanged += (s, args) => UpdateState(args);
                m_wm.WiimoteExtensionChanged += (s, args) => UpdateExtension(args);
                m_wm.Connect();
                m_wm.SetReportType(InputReport.IRExtensionAccel, true);

                // LED
                m_wm.SetLEDs(true, false, false, false);

                // 振動
                Task.Run(() =>
                {
                    m_wm.SetRumble(true);
                    Thread.Sleep(200);
                    m_wm.SetRumble(false);
                });

                // デバッグ情報
                m_debugInfo = new DebugInfo();
                m_debugInfo.OnHiden = () =>
                {
                    MenuItem_debugInfo.Checked = false;
                };
#if DEBUG
                m_debugInfo.Show();
                MenuItem_debugInfo.Checked = true;
#endif

            }
            catch (Exception ex)
            {
                string msg;

                switch (ex)
                {
                    case WiimoteNotFoundException _:
                        msg = "Wiiリモコンを認識できませんでした.\n\n1. Bluetoothが有効になっているか,\n2. Wiiリモコンに電池が入っているか,\n3. LEDが点滅して接続待機状態になっているかどうか\n等を確認してください.";
                        break;
                    case WiimoteException _:
                        msg = "Wiiリモコンに何らかのエラーが発生しました.";
                        break;
                    default:
                        msg = "予期せぬエラーが発生しました.";
                        break;
                }

                MessageBox.Show(
                    msg,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Environment.Exit(1);
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_wm.Disconnect();
        }

        private void MenuItem_debugInfo_Click(object sender, EventArgs e)
        {
            MenuItem_debugInfo.Checked = !MenuItem_debugInfo.Checked;
            if (MenuItem_debugInfo.Checked)
            {
                m_debugInfo.Show();
            }
            else
            {
                m_debugInfo.Hide();
            }
        }

        private Wiimote m_wm;
        private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);
        private delegate void UpdateExtensionChangedDelegate(WiimoteExtensionChangedEventArgs args);

        private WiimoteState prevState = new WiimoteState(); // 直前の状態
        private VKCodes m_vkcodes = new VKCodes();
        private DebugInfo m_debugInfo;
        private List<Profile> m_profiles = new List<Profile>();
        private Profile m_selectedProfile;
        private Behavior m_behavior;
        private BehaviorManager m_bMgr = new BehaviorManager();

        private bool _m_isRunning = false;
        private bool m_profileChanged = false;

        private Dictionary<string, MouseAction> m_dic_mouseAction = new Dictionary<string, MouseAction>
        {
            { "マウスのXを相対移動",    MouseAction.MoveDx },
            { "マウスのYを相対移動",    MouseAction.MoveDy },
            { "マウスのXを指定",        MouseAction.MoveX },
            { "マウスのYを指定",        MouseAction.MoveY },
            { "マウスのホイールを回転",  MouseAction.ScrollWheel },
            { "マウスの左クリック",      MouseAction.LeftClick },
            { "マウスの右クリック",      MouseAction.RightClick },
            { "マウスの中クリック",      MouseAction.MiddleClick }
        };


        private bool m_isRunning
        {
            get
            {
                return _m_isRunning;
            }
            set
            {
                _m_isRunning = value;
                OnRunStateChanged();
            }
        }

        // m_isRunning変更イベント
        private void OnRunStateChanged()
        {
            listBox_profile.Enabled = !m_isRunning;
            btnRun.Text = m_profileChanged ? "保存・" : "";
            btnRun.Text += m_isRunning ? "停止" : "開始";
        }

        private FileSystemWatcher m_fileSystemWatcher = new FileSystemWatcher();
        private const string VERSION = "BETA 0.3.0";

        private void LoadProfiles()
        {
            m_isRunning = false;

            Thread.Sleep(100); // ファイルアクセス衝突防止
            m_profiles.Clear();

            foreach (var path in Directory.EnumerateFiles("./Profile/"))
            {
                try
                {
                    var profile = Profile.Load(path);
                    profile._path = path;
                    m_profiles.Add(profile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("重大なエラーが発生しました。\n終了します。\n\nエラー内容: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Environment.Exit(1);
                }
            }

            listBox_profile.Items.Clear();
            foreach (var p in m_profiles)
            {
                listBox_profile.Items.Add(p.Name);
            }
            listBox_profile.SelectedIndex = 0;

        }

        private void m_fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            labStat.Text = "プロファイルの変更を適用しました. (" + DateTime.Now.ToShortTimeString() + ")";
            System.Media.SystemSounds.Asterisk.Play();
            LoadProfiles();
        }

        private void UpdateWiimoteChanged(WiimoteChangedEventArgs args)
        {
            var ws = args.WiimoteState;

            m_debugInfo.Update(ws);

            if (m_isRunning)
            {
                // Profileに設定されている動作を実行
                foreach (WiimoteModel item in m_selectedProfile.ActionAssignments.Keys)
                {
                    foreach (var action in m_selectedProfile.ActionAssignments[item])
                    {
                        if (item.isButton())
                        {
                            ProcessButtonAction(action, item.GetButtonState(ws), item.GetButtonState(prevState));
                        }
                        else
                        {
                            var value = item.GetAxisValue(ws);
                            var prevValue = item.GetAxisValue(prevState);
                            if (value.Available && prevValue.Available)
                            {
                                ProcessAxisAction(action, value.Value, prevValue.Value);
                            }
                        }
                    }

                }

                // Behavior固有の処理を実行
                m_behavior.Update(ws, prevState);
            }

            // 状態を保持
            prevState = DeepCopy(ws);

        }

        public void UpdateState(WiimoteChangedEventArgs args)
        {
            BeginInvoke(new UpdateWiimoteStateDelegate(UpdateWiimoteChanged), args);
        }

        public void UpdateExtension(WiimoteExtensionChangedEventArgs args)
        {
            BeginInvoke(new UpdateExtensionChangedDelegate(UpdateExtensionChanged), args);
        }

        private void UpdateExtensionChanged(WiimoteExtensionChangedEventArgs args)
        {
            if (args.Inserted)
            {
                m_wm.SetReportType(InputReport.IRExtensionAccel, true);
            }
            else
            {
                m_wm.SetReportType(InputReport.IRAccel, true);
            }
        }

        /// <summary>
        /// 指定されたactionに基づく動作を実行します。
        /// </summary>
        private void ProcessButtonAction(ActionAttribute action, bool state, bool prevState)
        {
            var pressing = action.Incremental.GetValueOrDefault(defaultValue: false) && state;
            var pressed = !prevState && state;
            var released = prevState && !state;

            if (!pressing && !pressed && !released)
            {
                return;
            }

            var delay = action.Delay.GetValueOrDefault(defaultValue: 0);

            if (action.Type == ActionType.Keyboard)
            {
                var key = action.Key;
                var modKey = action.ModifierKey;
                bool sendModKey = modKey != null && m_vkcodes.Contains(modKey) && pressed;

                if (m_vkcodes.Contains(key))
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(delay);

                        if (sendModKey)
                        {
                            WinAPI.keybd_event(m_vkcodes[modKey], 0, 0, UIntPtr.Zero);
                            m_debugInfo.LogWriteLine("modKey press");
                        }

                        WinAPI.keybd_event(m_vkcodes[key], 0, released ? WinAPI.KEYEVENTF_KEYUP : 0, UIntPtr.Zero);

                        if (sendModKey)
                        {
                            WinAPI.keybd_event(m_vkcodes[modKey], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
                            m_debugInfo.LogWriteLine("modKey release");
                        }

                    });
                }

                return;
            }

            var pos = Cursor.Position;
            var value = action.Value;
            var mouseAction = action.MouseAction;

            Task.Run(() =>
            {
                Thread.Sleep(delay);

                switch (mouseAction)
                {
                    case MouseAction.LeftClick:
                        WinAPI.mouse_event(released ? WinAPI.MOUSEEVENTF_LEFTUP : WinAPI.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        break;
                    case MouseAction.RightClick:
                        WinAPI.mouse_event(released ? WinAPI.MOUSEEVENTF_RIGHTUP : WinAPI.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                        break;
                    case MouseAction.MiddleClick:
                        WinAPI.mouse_event(released ? WinAPI.MOUSEEVENTF_MIDDLEUP : WinAPI.MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
                        break;
                    case MouseAction.MoveDx:
                        if (!released)
                        {
                            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, value.GetValueOrDefault(defaultValue: 0), 0, 0, 0);
                        }
                        break;
                    case MouseAction.MoveDy:
                        if (!released)
                        {
                            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, 0, value.GetValueOrDefault(defaultValue: 0), 0, 0);
                        }
                        break;
                    case MouseAction.MoveX:
                        if (pressed)
                        {
                            Cursor.Position = new System.Drawing.Point(value.GetValueOrDefault(defaultValue: pos.X), pos.Y);
                        }
                        break;
                    case MouseAction.MoveY:
                        if (pressed)
                        {
                            Cursor.Position = new System.Drawing.Point(pos.X, value.GetValueOrDefault(defaultValue: pos.Y));
                        }
                        break;
                    case MouseAction.ScrollWheel:
                        if (!released)
                        {
                            WinAPI.mouse_event(WinAPI.MOUSEEVENTF_WHEEL, 0, 0, value.GetValueOrDefault(defaultValue: 0), 0);
                        }
                        break;
                    default:
                        break;
                }
            });
        }

        private void ProcessAxisAction(ActionAttribute action, double value, double prevValue)
        {
            const double IGNORE_THD = 0.05;

            var pressing = action.Incremental.GetValueOrDefault(defaultValue: false) && Math.Abs(value) > IGNORE_THD;
            var pressed = Math.Abs(value) > IGNORE_THD && Math.Abs(prevValue) <= IGNORE_THD;
            var released = Math.Abs(value) <= IGNORE_THD && Math.Abs(prevValue) > IGNORE_THD;

            var delay = action.Delay.GetValueOrDefault(defaultValue: 0);

            if (action.Type == ActionType.Keyboard)
            {
                var key = action.Key;
                var modKey = action.ModifierKey;
                bool sendModKey = modKey != null && m_vkcodes.Contains(modKey) && pressed;

                if (m_vkcodes.Contains(key) && (pressing || pressed || released))
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(delay);

                        if (sendModKey)
                        {
                            WinAPI.keybd_event(m_vkcodes[modKey], 0, 0, UIntPtr.Zero);
                        }

                        WinAPI.keybd_event(m_vkcodes[key], 0, released ? WinAPI.KEYEVENTF_KEYUP : 0, UIntPtr.Zero);

                        if (sendModKey)
                        {
                            WinAPI.keybd_event(m_vkcodes[modKey], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
                        }
                    });
                }

                return;
            }

            var pos = Cursor.Position;
            var mouseAction = action.MouseAction;
            var actionValue = action.Value;

            Task.Run(() =>
            {
                Thread.Sleep(delay);

                switch (mouseAction)
                {
                    case MouseAction.LeftClick:
                        if (pressing || pressed || released)
                        {
                            WinAPI.mouse_event(released ? WinAPI.MOUSEEVENTF_LEFTUP : WinAPI.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        }
                        break;
                    case MouseAction.RightClick:
                        if (pressing || pressed || released)
                        {
                            WinAPI.mouse_event(released ? WinAPI.MOUSEEVENTF_RIGHTUP : WinAPI.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                        }
                        break;
                    case MouseAction.MiddleClick:
                        if (pressing || pressed || released)
                        {
                            WinAPI.mouse_event(released ? WinAPI.MOUSEEVENTF_MIDDLEUP : WinAPI.MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
                        }
                        break;
                    case MouseAction.MoveDx:
                        WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, (int)(actionValue.GetValueOrDefault(defaultValue: 1) * value), 0, 0, 0);
                        break;
                    case MouseAction.MoveDy:
                        WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, 0, (int)(actionValue.GetValueOrDefault(defaultValue: 1) * value), 0, 0);
                        break;
                    case MouseAction.MoveX:
                        if (pressing || pressed || released)
                        {
                            Cursor.Position = new System.Drawing.Point(actionValue.GetValueOrDefault(defaultValue: pos.X), pos.Y);
                        }
                        break;
                    case MouseAction.MoveY:
                        if (pressing || pressed || released)
                        {
                            Cursor.Position = new System.Drawing.Point(pos.X, actionValue.GetValueOrDefault(defaultValue: pos.Y));
                        }
                        break;
                    case MouseAction.ScrollWheel:
                        WinAPI.mouse_event(WinAPI.MOUSEEVENTF_WHEEL, 0, 0, (int)(actionValue.GetValueOrDefault(defaultValue: 1) * value), 0);
                        break;
                    default:
                        break;
                }
            });

        }

        /// <summary>
        /// クラスオブジェクトをディープコピーします。
        /// (For cloning WiimoteState)
        /// http://l-s-d.sakura.ne.jp/2016/04/class_obj_copy/
        /// </summary>
        private static T DeepCopy<T>(T target)
        {
            T result;

            using (var mem = new MemoryStream())
            {
                var b = new BinaryFormatter();
                b.Serialize(mem, target);
                mem.Position = 0;
                result = (T)b.Deserialize(mem);
            }

            return result;
        }

        private void MenuItem_Readme_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/oyakodon/wiizard/tree/master/README.md");
        }

        private void MenuItem_Version_Click(object sender, EventArgs e)
        {
            MessageBox.Show("< Wiizard >\n\nVer. " + VERSION + "\n\n作者: Oyakodon\n(https://github.com/oyakodon/)", "バージョン情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuItem_autoReload_Click(object sender, EventArgs e)
        {
            m_fileSystemWatcher.EnableRaisingEvents = !m_fileSystemWatcher.EnableRaisingEvents;
            MenuItem_autoReload.Checked = m_fileSystemWatcher.EnableRaisingEvents;
        }

        private void listBox_profile_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index > -1)
            {
                Brush b = new SolidBrush(e.ForeColor);

                if ((e.State & DrawItemState.Disabled) == DrawItemState.Disabled)
                {
                    if ((e.State & DrawItemState.Selected) != DrawItemState.Selected)
                    {
                        b = new SolidBrush(Color.Black);

                        e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                    }
                }

                var sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;

                var itemText = (sender as ListBox).Items[e.Index].ToString();

                e.Graphics.DrawString(itemText, e.Font, b, e.Bounds, sf);

                b.Dispose();

            }

            e.DrawFocusRectangle();
        }

        private void listBox_profile_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_selectedProfile = m_profiles[(sender as ListBox).SelectedIndex];
            m_behavior = m_bMgr.GetBehavior(m_selectedProfile.Behavior);

            //// 現在の設定をUIに適用
            //foreach (var combo in m_dic_combos.SelectMany(i => i.Value))
            //{
            //    var model = m_dic_combos.First(i => i.Value.Contains(combo)).Key;
                
            //}

            //// Behaviorで指定されたものを無効化
            //var disabledItem = m_behavior.GetDisabledItem();
            //foreach (var p in m_dic_combos)
            //{
            //    foreach(var combo in p.Value)
            //    {
            //        if (disabledItem.Contains(p.Key))
            //        {
            //            combo.Enabled = false;
            //            combo.Text = "無し";
            //        }
            //        else
            //        {
            //            combo.Enabled = true;
            //        }
            //    }
            //}
            
            OnRunStateChanged();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // プロファイル変更の保存
            if (m_profileChanged)
            {
                //var newProfile = new Profile();
                //newProfile.Name = m_selectedProfile.Name;
                //newProfile.Behavior = m_bMgr.GetBehavior(combo_behavior.Text, true).GetName();
                //newProfile.ActionAssignments = new Dictionary<WiimoteModel, List<ActionAttribute>>();

                //foreach (var combo in m_dic_combos.SelectMany(i => i.Value))
                //{
                //    var attr = new ActionAttribute();
                //    var model = m_dic_combos.First(i => i.Value.Contains(combo)).Key;

                //    if (!check_UseNunchuk.Checked && m_combos_nunchuk.Contains(combo))
                //    {
                //        continue;
                //    }

                //    if ((combo.Name.Contains("Joy") && !check_JoyAsButton.Checked) || (combo.Name.Contains("joy") && !check_JoyAsButton.Checked))
                //    {
                //        continue;
                //    }

                //    if (m_dic_mouseAction.ContainsKey(combo.Text))
                //    {
                //        attr.Type = ActionType.Mouse;
                //        attr.MouseAction = m_dic_mouseAction[combo.Text];
                //    }
                //    else
                //    {
                //        attr.Type = ActionType.Keyboard;
                //        attr.Key = combo.Text;
                //    }

                //    newProfile.ActionAssignments.Add(model, new List<ActionAttribute> { attr });
                //}

                //newProfile.Save(newProfile._path);
            }

            m_isRunning = !m_isRunning;
        }

        private void profile_UI_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_profileChanged = true;
            m_isRunning = false;
        }
        
    }

}
