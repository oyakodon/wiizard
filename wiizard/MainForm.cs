using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            } catch (Exception ex)
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
                foreach (WiimoteModel item in m_profile.Assignments.Keys)
                {
                    if (item.isButton())
                    {
                        var action = m_profile.Assignments[item];

                        if (action.EndsWith("_INC"))
                        {
                            if (item.GetState(ws))
                            {
                                m_debugInfo.LogWriteLine(item + " pressing.");
                                action = action.Replace("_INC", "");
                                ProcessButtonAction(action);
                            }
                        }
                        else
                        {
                            if (!item.GetState(prevState) && item.GetState(ws))
                            {
                                m_debugInfo.LogWriteLine(item + " pressed.");
                                ProcessButtonAction(action);
                            }
                            if (item.GetState(prevState) && !item.GetState(ws))
                            {
                                m_debugInfo.LogWriteLine(item + " released.");
                                ProcessButtonAction(action, released: true);
                            }
                        }
                    }
                    else
                    {
                        var value = item.GetValue(ws);
                        var prevValue = item.GetValue(prevState);
                        if (value.Item2 && prevValue.Item2)
                        {
                            ProcessAxisAction(m_profile.Assignments[item], value.Item1, prevValue.Item1);
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
        private void ProcessButtonAction(string action, bool released = false)
        {
            bool inverted = false;

            if (action.EndsWith("_INV"))
            {
                action = action.Replace("_INV", "");
                inverted = true;
            }

            switch (action)
            {
                case "M_LCLICK":
                    WinAPI.mouse_event(released ? WinAPI.MOUSEEVENTF_LEFTUP : WinAPI.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    break;
                case "M_RCLICK":
                    WinAPI.mouse_event(released ? WinAPI.MOUSEEVENTF_RIGHTUP : WinAPI.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    break;
                case "MOUSE_X":
                    WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, inverted ? -10 : 10, 0, 0, 0);
                    break;
                case "MOUSE_Y":
                    WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, 0, inverted ? -10 : 10, 0, 0);
                    break;
                case "MOUSE_WHEEL":
                    WinAPI.mouse_event(WinAPI.MOUSEEVENTF_WHEEL, 0, 0, inverted ? -20 : 20, 0);
                    break;
                default:
                    if (m_vkcodes.Contains(action))
                    {
                        WinAPI.keybd_event(m_vkcodes[action], 0, released ? WinAPI.KEYEVENTF_KEYUP : 0, UIntPtr.Zero);
                    }

                    break;
            }
        }

        private void ProcessAxisAction(string action, double value, double prevValue)
        {
            switch (action)
            {
                case "MOUSE_X":
                    WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, (int)(value * 20), 0, 0, 0);
                    break;
                case "MOUSE_Y":
                    WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, 0, (int)(value * 20), 0, 0);
                    break;
                case "MOUSE_WHEEL":
                    WinAPI.mouse_event(WinAPI.MOUSEEVENTF_WHEEL, 0, 0, (int)(value * 20), 0);
                    break;
                default:
                    if (Math.Abs(value) > 0.05)
                    {
                        // press
                        ProcessButtonAction(action);
                    }
                    else if (Math.Abs(prevValue) > 0.05)
                    {
                        //release
                        ProcessButtonAction(action, released: true);
                    }
                    break;
            }

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
