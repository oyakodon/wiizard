using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

using WiimoteLib;

namespace wiizard
{
    public partial class DebugInfo : Form
    {
        public DebugInfo()
        {
            InitializeComponent();
        }

        public void Update(WiimoteState ws)
        {
            // ボタンの状態
            var buttonStateDic = GetDictionaryFromButton(ws);

            for(var i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, buttonStateDic[(string)checkedListBox1.Items[i]] ? CheckState.Checked : CheckState.Unchecked);
            }

            // 加速度
            labAcc.Text = AccToString(ws.AccelState.Values.X, ws.AccelState.Values.Y, ws.AccelState.Values.Z);

            if (ws.ExtensionType == ExtensionType.Nunchuk)
            {
                labNunchukAcc.Text = AccToString(ws.NunchukState.AccelState.Values.X, ws.NunchukState.AccelState.Values.Y, ws.NunchukState.AccelState.Values.Z);
            }

            // バッテリー残量
            labBattery.Text = ws.Battery.ToString("00") + "%";

        }

        private Dictionary<string, bool> GetDictionaryFromButton(WiimoteState ws)
        {
            var dic = new Dictionary<string, bool>();

            dic["A"] = ws.ButtonState.A;
            dic["B"] = ws.ButtonState.B;
            dic["+"] = ws.ButtonState.Plus;
            dic["-"] = ws.ButtonState.Minus;
            dic["Home"] = ws.ButtonState.Home;
            dic["1"] = ws.ButtonState.One;
            dic["2"] = ws.ButtonState.Two;
            dic["Up"] = ws.ButtonState.Up;
            dic["Down"] = ws.ButtonState.Down;
            dic["Left"] = ws.ButtonState.Left;
            dic["Right"] = ws.ButtonState.Right;

            if (ws.ExtensionType == ExtensionType.Nunchuk)
            {
                dic["Z"] = ws.NunchukState.Z;
                dic["C"] = ws.NunchukState.C;
            }
            else
            {
                dic["Z"] = dic["C"] = false;
            }

            return dic;
        }

        private string AccToString(double _x, double _y, double _z)
        {
            var x = _x.ToString("0.000");
            var y = _y.ToString("0.000");
            var z = _z.ToString("0.000");

            return $"{x}/{y}/{z}";
        }

    }
}
