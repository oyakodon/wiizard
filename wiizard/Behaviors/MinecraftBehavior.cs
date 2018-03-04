using System;
using WiimoteLib;

namespace wiizard.Behaviors
{
    public class MinecraftBehavior : Behavior
    {
        public override void Update(WiimoteState ws)
        {
            //if (ws.ExtensionType == ExtensionType.Nunchuk)
            //{

            //    // 移動キー
            //    const double STICK_THD = 0.05;
            //    const double DASH_THD = 0.25;

            //    if (Math.Abs(ws.NunchukState.Joystick.X) >= STICK_THD)
            //    {
            //        WinAPI.keybd_event(m_vkcodes[(ws.NunchukState.Joystick.X > 0) ? "d" : "a"], 0, 0, UIntPtr.Zero);
            //        isWalked_X = true;
            //    }
            //    else if (isWalked_X)
            //    {
            //        WinAPI.keybd_event(m_vkcodes["a"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
            //        WinAPI.keybd_event(m_vkcodes["d"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
            //        isWalked_X = false;
            //    }

            //    if (Math.Abs(ws.NunchukState.Joystick.Y) >= STICK_THD)
            //    {
            //        if (ws.NunchukState.Joystick.Y > 0 && ws.NunchukState.Joystick.Y >= DASH_THD && !isDash)
            //        {
            //            WinAPI.keybd_event(m_vkcodes["ctrl"], 0, 0, UIntPtr.Zero);
            //            isDash = true;
            //        }

            //        WinAPI.keybd_event(m_vkcodes[(ws.NunchukState.Joystick.Y > 0) ? "w" : "s"], 0, 0, UIntPtr.Zero);
            //        isWalked_Y = true;

            //    }
            //    else if (isWalked_Y)
            //    {
            //        WinAPI.keybd_event(m_vkcodes["w"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
            //        WinAPI.keybd_event(m_vkcodes["s"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
            //        isWalked_Y = false;
            //        isDash = false;
            //    }

            //    if (ws.NunchukState.Joystick.Y <= -DASH_THD && Math.Abs(ws.NunchukState.Joystick.X) <= DASH_THD)
            //    {
            //        WinAPI.keybd_event(m_vkcodes["ctrl"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
            //    }

            //    if (!previousNunchuk.Z && ws.NunchukState.Z)
            //    {
            //        WinAPI.keybd_event(m_vkcodes["spacebar"], 0, 0, UIntPtr.Zero);
            //        System.Threading.Thread.Sleep(100);
            //        WinAPI.keybd_event(m_vkcodes["spacebar"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
            //    }

            //    if (ws.NunchukState.C)
            //    {
            //        WinAPI.keybd_event(m_vkcodes["left_shift"], 0, 0, UIntPtr.Zero);
            //    }

            //    if (previousNunchuk.C && !ws.NunchukState.C)
            //    {
            //        WinAPI.keybd_event(m_vkcodes["left_shift"], 0, WinAPI.KEYEVENTF_KEYUP, UIntPtr.Zero);
            //    }

            //    previousNunchuk = ws.NunchukState;

            //}

        }
    }
}
