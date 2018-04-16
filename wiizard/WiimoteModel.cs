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
        _N_STICK,
        N_STICK_X,
        N_STICK_Y,
        N_STICK_UP,
        N_STICK_DOWN,
        N_STICK_LEFT,
        N_STICK_RIGHT,
        IR_X,
        IR_Y,
        ACC_X,
        ACC_Y,
        N_ACC_X,
        N_ACC_Y
    }

    public static class WiimoteModelExt
    {
        public class AxisValue
        {
            public bool Available;
            public double Value;

            public AxisValue(bool valid, double val)
            {
                Available = valid;
                Value = val;
            }

            public static AxisValue Invalid
            {
                get
                {
                    return new AxisValue(false, 0);
                }
            }

        }

        private const double IGNORE_THD = 0.05;

        public static bool GetButtonState(this WiimoteModel item, WiimoteState ws)
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

        public static AxisValue GetAxisValue(this WiimoteModel item, WiimoteState ws)
        {
            switch (item)
            {
                case WiimoteModel.ACC_X:
                    return new AxisValue(true, AdjustRange(ws.AccelState.Values.X, -1, 1, -0.5, 0.5));
                case WiimoteModel.ACC_Y:
                    return new AxisValue(true, AdjustRange(ws.AccelState.Values.Y, -1, 1, -0.5, 0.5));
                case WiimoteModel.N_ACC_X:
                    return new AxisValue(ws.ExtensionType == ExtensionType.Nunchuk, AdjustRange(ws.NunchukState.AccelState.Values.X, -1, 1, -0.5, 0.5));
                case WiimoteModel.N_ACC_Y:
                    return new AxisValue(ws.ExtensionType == ExtensionType.Nunchuk, AdjustRange(ws.NunchukState.AccelState.Values.Y, -1, 1, -0.5, 0.5));
                case WiimoteModel.N_STICK_X:
                    {
                        if (ws.ExtensionType != ExtensionType.Nunchuk)
                        {
                            return AxisValue.Invalid;
                        }
                        var value = ws.NunchukState.Joystick.X;
                        value = Math.Abs(value) > IGNORE_THD ? value : 0;
                        return new AxisValue(true, value);
                    }
                case WiimoteModel.N_STICK_Y:
                    {
                        if (ws.ExtensionType != ExtensionType.Nunchuk)
                        {
                            return AxisValue.Invalid;
                        }
                        var value = ws.NunchukState.Joystick.Y;
                        value = Math.Abs(value) > IGNORE_THD ? value : 0;
                        return new AxisValue(true, value);
                    }
                case WiimoteModel.IR_X:
                    {
                        var count = ws.IRState.IRSensors.Count(x => x.Found);
                        if (count == 0)
                        {
                            return AxisValue.Invalid;
                        }
                        var val = (double)ws.IRState.IRSensors.Where(x => x.Found).Select(x => x.Position.X).Average();
                        val = Math.Abs(val - 0.5) > IGNORE_THD ? val : 0.5;
                        return new AxisValue(true, val);
                    }
                case WiimoteModel.IR_Y:
                    {
                        var count = ws.IRState.IRSensors.Count(x => x.Found);
                        if (count == 0)
                        {
                            return AxisValue.Invalid;
                        }
                        var val = (double)ws.IRState.IRSensors.Where(x => x.Found).Select(x => x.Position.Y).Average();
                        val = Math.Abs(0.5 - val) > IGNORE_THD ? val : 0.5;
                        return new AxisValue(true, val);
                    }
                default:
                    return AxisValue.Invalid;
            }
        }

        private static double AdjustRange(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

    }

}
