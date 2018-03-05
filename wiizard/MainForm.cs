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

#if DEBUG
                // デバッグ情報を表示
                m_debugInfo = new DebugInfo();
                m_debugInfo.Show();
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

                Application.Exit();
            }

            // Load profile.
            string json;
            using (var sr = new StreamReader(@"C:\Users\Riku\Desktop\default.json", System.Text.Encoding.UTF8))
            {
                json = sr.ReadToEnd();
            }

            m_loadedProfile = JsonConvert.DeserializeObject<Profile>(json);

            m_behavior = new MinecraftBehavior();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_wm.Disconnect();
        }

        private Wiimote m_wm;
        private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);
        private delegate void UpdateExtensionChangedDelegate(WiimoteExtensionChangedEventArgs args);

        private WiimoteState prevState = new WiimoteState(); // 直前の状態
        private VKCodes m_vkcodes = new VKCodes();
        private DebugInfo m_debugInfo;
        private Profile m_loadedProfile;
        private Behavior m_behavior;

        private void UpdateWiimoteChanged(WiimoteChangedEventArgs args)
        {
            var ws = args.WiimoteState;

            m_debugInfo.Update(ws);

            // Profileに設定されている動作を実行
            foreach (WiimoteModel item in m_loadedProfile.Assignments.Keys)
            {
                if (item.isButton())
                {
                    var action = m_loadedProfile.Assignments[item];
                    bool inc = false;
                    bool inv = false;

                    if (action.EndsWith("_INC"))
                    {
                        action = action.Replace("_INC", "");
                        inc = true;
                    }
                    if (action.EndsWith("_INV"))
                    {
                        action = action.Replace("_INV", "");
                        inv = true;
                    }

                    if (inc)
                    {
                        if (item.GetState(ws))
                        {
                            m_debugInfo.LogWriteLine(item + " pressing.");
                            ProcessButtonAction(action, inverted: inv);
                        }
                    }
                    else
                    {
                        if (!item.GetState(prevState) && item.GetState(ws))
                        {
                            m_debugInfo.LogWriteLine(item + " pressed.");
                            ProcessButtonAction(action, inverted: inv);
                        }
                        if (item.GetState(prevState) && !item.GetState(ws))
                        {
                            m_debugInfo.LogWriteLine(item + " released.");
                            ProcessButtonAction(action, inverted: inv, released: true);
                        }
                    }
                }
                else
                {
                    var value = item.GetValue(ws);
                    if (value.Item2)
                    {
                        ProcessAxisAction(m_loadedProfile.Assignments[item], value.Item1);
                    }
                }
            }

            // Behavior固有の処理を実行
            m_behavior.Update(ws, prevState);

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
        private void ProcessButtonAction(string action, bool inverted = false, bool released = false)
        {
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

        private void ProcessAxisAction(string action, double value)
        {
            switch (action)
            {
                case "MOUSE_X":
                    WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, (int)((value - 0.5) * 20), 0, 0, 0);
                    break;
                case "MOUSE_Y":
                    WinAPI.mouse_event(WinAPI.MOUSEEVENTF_MOVE, 0, (int)((0.5 - value) * 20), 0, 0);
                    break;
                case "MOUSE_WHEEL":
                    WinAPI.mouse_event(WinAPI.MOUSEEVENTF_WHEEL, 0, 0, (int)((0.5 - value) * 20), 0);
                    break;
                default:
                    ProcessButtonAction(action, released: (value < 0.5));
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

    }

}
