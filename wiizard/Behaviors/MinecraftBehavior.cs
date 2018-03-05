using System;
using System.Collections.Generic;
using WiimoteLib;

namespace wiizard.Behaviors
{
    // Minecraft用の挙動
    public class MinecraftBehavior : Behavior
    {
        public List<WiimoteModel> GetDisabledItem() => new List<WiimoteModel>
        {
            WiimoteModel.N_STICK_X,
            WiimoteModel.N_STICK_Y
        };        

        public string GetName() => "Minecraft";

        public string GetDisplayName() => "Minecraft (ヌンチャク使用)";

        private VKCodes m_vkcodes = new VKCodes();

        private const double STICK_THD = 0.05;
        private const double DASH_THD = 0.25;

        private bool isWalked_X = false;
        private bool isWalked_Y = false;
        private bool isDash = false;

        public void Update(WiimoteState ws, WiimoteState prev)
        {
            if (ws.ExtensionType == ExtensionType.Nunchuk)
            {
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
                    //if (ws.NunchukState.Joystick.Y > 0 && ws.NunchukState.Joystick.Y >= DASH_THD && !isDash)
                    //{
                    //    WinAPI.keybd_event(m_vkcodes["ctrl"], 0, 0, UIntPtr.Zero);
                    //    isDash = true;
                    //}

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

                //if (ws.NunchukState.Joystick.Y <= -DASH_THD && Math.Abs(ws.NunchukState.Joystick.X) <= DASH_THD)
                //{
                //    WinAPI.keybd_event(m_vkcodes["ctrl"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
                //}

            }

        }
    }
}
