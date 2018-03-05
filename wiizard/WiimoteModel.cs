using System;
using WiimoteLib;
using System.Linq;

namespace wiizard
{
    public enum WiimoteModel
    {
        A,
        B,
        Plus,
        Minus,
        Home,
        One,
        Two,
        Up,
        Down,
        Left,
        Right,
        N_Z,
        N_C,
        N_STICK_X,
        N_STICK_Y,
        IR_X,
        IR_Y,
        ACC_X,
        ACC_Y,
        N_ACC_X,
        N_ACC_Y
    }

    static class WiimoteModelExt
    {
        public static bool GetState(this WiimoteModel item, WiimoteState ws)
        {
            bool ret = false;
            switch (item)
            {
                case WiimoteModel.A:
                    ret = ws.ButtonState.A;
                    break;
                case WiimoteModel.B:
                    ret = ws.ButtonState.B;
                    break;
                case WiimoteModel.Plus:
                    ret = ws.ButtonState.Plus;
                    break;
                case WiimoteModel.Minus:
                    ret = ws.ButtonState.Minus;
                    break;
                case WiimoteModel.Home:
                    ret = ws.ButtonState.Home;
                    break;
                case WiimoteModel.One:
                    ret = ws.ButtonState.One;
                    break;
                case WiimoteModel.Two:
                    ret = ws.ButtonState.Two;
                    break;
                case WiimoteModel.Up:
                    ret = ws.ButtonState.Up;
                    break;
                case WiimoteModel.Down:
                    ret = ws.ButtonState.Down;
                    break;
                case WiimoteModel.Left:
                    ret = ws.ButtonState.Left;
                    break;
                case WiimoteModel.Right:
                    ret = ws.ButtonState.Right;
                    break;
                case WiimoteModel.N_Z:
                    ret = ws.ExtensionType == ExtensionType.Nunchuk ? ws.NunchukState.Z : false;
                    break;
                case WiimoteModel.N_C:
                    ret = ws.ExtensionType == ExtensionType.Nunchuk ? ws.NunchukState.C : false;
                    break;
                default:
                    break;
            }

            return ret;
        }

        public static bool isButton(this WiimoteModel item)
        {
            switch (item)
            {
                case WiimoteModel.A:
                case WiimoteModel.B:
                case WiimoteModel.Plus:
                case WiimoteModel.Minus:
                case WiimoteModel.Home:
                case WiimoteModel.One:
                case WiimoteModel.Two:
                case WiimoteModel.Up:
                case WiimoteModel.Down:
                case WiimoteModel.Left:
                case WiimoteModel.Right:
                case WiimoteModel.N_Z:
                case WiimoteModel.N_C:
                    return true;
                default:
                    return false;
            }
        }

        public static (double, bool) GetValue(this WiimoteModel item, WiimoteState ws)
        {
            (double, bool) invalid = (0, false);

            switch (item)
            {
                case WiimoteModel.ACC_X:
                    return (ws.AccelState.Values.X, true);
                case WiimoteModel.ACC_Y:
                    return (ws.AccelState.Values.Y, true);
                case WiimoteModel.N_ACC_X:
                    return ws.ExtensionType == ExtensionType.Nunchuk ? (ws.NunchukState.AccelState.Values.X, true) : invalid;
                case WiimoteModel.N_ACC_Y:
                    return ws.ExtensionType == ExtensionType.Nunchuk ? (ws.NunchukState.AccelState.Values.Y, true) : invalid;
                case WiimoteModel.N_STICK_X:
                    if (ws.ExtensionType == ExtensionType.Nunchuk)
                    {
                        var value = ws.NunchukState.Joystick.X;
                        if (Math.Abs(value) <= 0.05)
                        {
                            value = 0;
                        }
                        return (AdjustRange(value, -0.5, 0.5, 0, 1.0), true);
                    }
                    else
                    {
                        return invalid;
                    }
                case WiimoteModel.N_STICK_Y:
                    if (ws.ExtensionType == ExtensionType.Nunchuk)
                    {
                        var value = ws.NunchukState.Joystick.Y;
                        if (Math.Abs(value) <= 0.05)
                        {
                            value = 0;
                        }
                        return (AdjustRange(value, -0.5, 0.5, 0, 1.0), true);
                    }
                    else
                    {
                        return invalid;
                    }
                case WiimoteModel.IR_X:
                    {
                        var count = ws.IRState.IRSensors.Count(x => x.Found);
                        if (count != 0)
                        {
                            var val = ws.IRState.IRSensors.Where(x => x.Found).Select(x => x.Position.X).Average();
                            return (val, true);
                        }
                        else
                        {
                            return invalid;
                        }
                    }
                case WiimoteModel.IR_Y:
                    {
                        var count = ws.IRState.IRSensors.Count(x => x.Found);
                        if (count != 0)
                        {
                            var val = ws.IRState.IRSensors.Where(x => x.Found).Select(x => x.Position.Y).Average();
                            return (val, true);
                        } else
                        {
                            return invalid;
                        }
                    }
                default:
                    return invalid;
            }
        }

        private static double AdjustRange(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

    }

}
