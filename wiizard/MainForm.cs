using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using WiimoteLib;

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
            m_vkcodes = new VKCodes();

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
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_wm.Disconnect();
        }

        private Wiimote m_wm;
        private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);
        private delegate void UpdateExtensionChangedDelegate(WiimoteExtensionChangedEventArgs args);
        private WiimoteLib.ButtonState previousBtns = new WiimoteLib.ButtonState(); // 直前のボタンの状態
        private NunchukState previousNunchuk = new WiimoteLib.NunchukState(); // 直前のヌンチャクの状態

        private DebugInfo m_debugInfo;
        private VKCodes m_vkcodes;

        private bool isDash = false;
        private bool isWalked_X = false;
        private bool isWalked_Y = false;

        public void UpdateState(WiimoteChangedEventArgs args)
        {
            BeginInvoke(new UpdateWiimoteStateDelegate(UpdateWiimoteChanged), args);
        }

        public void UpdateExtension(WiimoteExtensionChangedEventArgs args)
        {
            BeginInvoke(new UpdateExtensionChangedDelegate(UpdateExtensionChanged), args);
        }

        private void UpdateWiimoteChanged(WiimoteChangedEventArgs args)
        {
            WiimoteState ws = args.WiimoteState;

            m_debugInfo.Update(ws);

            if (ws.ExtensionType == ExtensionType.Nunchuk)
            {
                // toolStripStatusLabel2.Text = string.Format("({0}, {1})", ws.NunchukState.Joystick.X, ws.NunchukState.Joystick.Y);

                // 移動キー
                const double STICK_THD = 0.05;
                const double DASH_THD = 0.25;

                if (Math.Abs(ws.NunchukState.Joystick.X) >= STICK_THD)
                {
                    WinAPI.keybd_event(m_vkcodes[(ws.NunchukState.Joystick.X > 0) ? "d" : "a"], 0, 0, UIntPtr.Zero);
                    isWalked_X = true;
                }
                else if (isWalked_X)
                {
                    WinAPI.keybd_event(m_vkcodes["a"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
                    WinAPI.keybd_event(m_vkcodes["d"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
                    isWalked_X = false;
                }

                if (Math.Abs(ws.NunchukState.Joystick.Y) >= STICK_THD)
                {
                    if (ws.NunchukState.Joystick.Y > 0 && ws.NunchukState.Joystick.Y >= DASH_THD && !isDash)
                    {
                        WinAPI.keybd_event(m_vkcodes["ctrl"], 0, 0, UIntPtr.Zero);
                        isDash = true;
                    }

                    WinAPI.keybd_event(m_vkcodes[(ws.NunchukState.Joystick.Y > 0) ? "w" : "s"], 0, 0, UIntPtr.Zero);
                    isWalked_Y = true;

                }
                else if (isWalked_Y)
                {
                    WinAPI.keybd_event(m_vkcodes["w"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
                    WinAPI.keybd_event(m_vkcodes["s"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
                    isWalked_Y = false;
                    isDash = false;
                }

                if (ws.NunchukState.Joystick.Y <= -DASH_THD && Math.Abs(ws.NunchukState.Joystick.X) <= DASH_THD)
                {
                    WinAPI.keybd_event(m_vkcodes["ctrl"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
                }

                if (!previousNunchuk.Z && ws.NunchukState.Z)
                {
                    WinAPI.keybd_event(m_vkcodes["spacebar"], 0, 0, UIntPtr.Zero);
                    System.Threading.Thread.Sleep(100);
                    WinAPI.keybd_event(m_vkcodes["spacebar"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
                }

                if (ws.NunchukState.C)
                {
                    WinAPI.keybd_event(m_vkcodes["left_shift"], 0, 0, UIntPtr.Zero);
                }

                if (previousNunchuk.C && !ws.NunchukState.C)
                {
                    WinAPI.keybd_event(m_vkcodes["left_shift"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
                }

                previousNunchuk = ws.NunchukState;

            }

            if (!previousBtns.A && ws.ButtonState.A)
            {
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            }

            if (previousBtns.A && !ws.ButtonState.A)
            {
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }

            if (!previousBtns.B && ws.ButtonState.B)
            {
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            }

            if (previousBtns.B && !ws.ButtonState.B)
            {
                WinAPI.mouse_event(WinAPI.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            }

            // ボタンの状態を保持
            previousBtns = ws.ButtonState;

            // バッテリー残量
            // tsProgressBar_battery.Value = (ws.Battery > 0xc8 ? 0xc8 : (int)ws.Battery);
            // tsStatLab_battery.Text = Math.Floor(ws.Battery) + "%";
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

    }

}
