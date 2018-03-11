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

namespace wiizard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            // Load profile.
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Filter = "JSONファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
            ofd.Title = "プロファイルを選択してください";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // ファイル変更の検知
                m_fileSystemWatcher.Path = Path.GetDirectoryName(ofd.FileName);
                m_fileSystemWatcher.Filter = Path.GetFileName(ofd.FileName);
                m_fileSystemWatcher.SynchronizingObject = this;
                m_fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess;
                m_fileSystemWatcher.Changed += m_fileSystemWatcher_Changed;
                m_fileSystemWatcher.EnableRaisingEvents = true;　//監視を開始

                // プロファイルの読み込み
                LoadProfile(ofd.FileName);
            }
            else
            {
                Environment.Exit(1);
            }

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
                        msg = "Wiiリモコンを認識できませんでした。";
                        break;
                    case WiimoteException _:
                        msg = "Wiiリモコンに何らかのエラーが発生しました。";
                        break;
                    default:
                        msg = "予期せぬエラーが発生しました。";
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
        private Profile m_profile;
        private Behavior m_behavior;

        private bool m_isRunning = false;
        private FileSystemWatcher m_fileSystemWatcher = new FileSystemWatcher();
        private const string VERSION = "BETA 0.2.0";

        private string m_profilePath;

        private void LoadProfile()
        {
            LoadProfile(m_profilePath);
        }

        private void LoadProfile(string profilePath)
        {
            m_profilePath = profilePath;

            m_isRunning = false;

            Thread.Sleep(100); // ファイルアクセス衝突防止

            try
            {
                m_profile = Profile.Load(profilePath);

                switch (m_profile.Behavior)
                {
                    case "Minecraft":
                        m_behavior = new MinecraftBehavior();
                        break;
                    default:
                        m_behavior = new StandardBehavior();
                        break;
                }

                labProfileName.Text = m_profile.Name;
                m_isRunning = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("重大なエラーが発生しました。\n終了します。\n\nエラー内容: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(1);
            }

        }

        private void m_fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            labStat.Text = "プロファイルの変更を適用しました. (" + DateTime.Now.ToShortTimeString() + ")";
            System.Media.SystemSounds.Asterisk.Play();
            LoadProfile(e.FullPath);
        }



        private void UpdateWiimoteChanged(WiimoteChangedEventArgs args)
        {
            var ws = args.WiimoteState;

            m_debugInfo.Update(ws);
            
            if (m_isRunning)
            {
                // Profileに設定されている動作を実行
                foreach (WiimoteModel item in m_profile.ActionAssignments.Keys)
                {
                    foreach (var action in m_profile.ActionAssignments[item])
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

            var delay = action.Delay;
            
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

            var delay = action.Delay;

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

        private void btnToggleMode_Click(object sender, EventArgs e)
        {
            m_isRunning = !m_isRunning;
            if (m_isRunning)
            {
                btnToggleMode.Text = "停止(&S)";
            }
            else
            {
                btnToggleMode.Text = "開始(&R)";
            }
        }

        private void MenuItem_Readme_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/oyakodon/wiizard/tree/master/README.md");
        }

        private void MenuItem_Version_Click(object sender, EventArgs e)
        {
            MessageBox.Show("< Wiizard >\n\nVer. " + VERSION + "\n\n作者: Oyakodon\n(https://github.com/oyakodon/)", "バージョン情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuItem_reloadProfile_Click(object sender, EventArgs e)
        {
            LoadProfile();
            MessageBox.Show("プロファイルは正常に再読み込みされました。", "Wiizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuItem_autoReload_Click(object sender, EventArgs e)
        {
            m_fileSystemWatcher.EnableRaisingEvents = !m_fileSystemWatcher.EnableRaisingEvents;
            MenuItem_autoReload.Checked = m_fileSystemWatcher.EnableRaisingEvents;
        }
    }

}
