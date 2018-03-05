using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using WiimoteLib;
using System.Drawing;

namespace wiizard
{
    public partial class DebugInfo : Form
    {
        public DebugInfo()
        {
            InitializeComponent();
        }

        private bool irDetected = false;
        private List<System.Drawing.PointF> irPoints = new List<System.Drawing.PointF>();
        private System.Drawing.PointF averagedIrPoint;

        public Action OnHiden;

        public void Update(WiimoteState ws)
        {
            if (this.IsDisposed)
            {
                return;
            }

            // 赤外線
            var count = ws.IRState.IRSensors.Count(s => s.Found);
            irDetected = (count != 0);
            labIrStat.Text = irDetected ? "Detected" : "Not Detected";
            labIrCount.Text = count.ToString();
            if (irDetected)
            {
                irPoints.Clear();
                float sum_x = 0, sum_y = 0;
                foreach (var ir in ws.IRState.IRSensors)
                {
                    if (ir.Found)
                    {
                        irPoints.Add(new System.Drawing.PointF(ir.Position.X, ir.Position.Y));

                        sum_x += ir.Position.X;
                        sum_y += ir.Position.Y;
                    }
                }

                averagedIrPoint = new System.Drawing.PointF( sum_x / count, sum_y / count );
            }
            UpdateIRWindow();

            // ボタンの状態
            var buttonStateDic = GetDictionaryFromButton(ws);

            for(var i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, buttonStateDic[(string)checkedListBox1.Items[i]] ? CheckState.Checked : CheckState.Unchecked);
            }

            // 加速度・ジョイスティック
            labAcc.Text = AccToString(ws.AccelState.Values.X, ws.AccelState.Values.Y, ws.AccelState.Values.Z);

            if (ws.ExtensionType == ExtensionType.Nunchuk)
            {
                labNunchukAcc.Text = AccToString(ws.NunchukState.AccelState.Values.X, ws.NunchukState.AccelState.Values.Y, ws.NunchukState.AccelState.Values.Z);
                labNunchukStick.Text = ws.NunchukState.Joystick.X.ToString("0.000") + "/" + ws.NunchukState.Joystick.Y.ToString("0.000");
            }

            // バッテリー残量
            labBattery.Text = ws.Battery.ToString("00") + "%";

        }

        public void LogWriteLine(string log)
        {
            listBox_log.Items.Insert(0, string.Format("[{0}] {1}", System.DateTime.Now, log));
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

        private delegate void UpdateIRWindowDelegate();
        private Brush[] irColors = { Brushes.Red, Brushes.Blue, Brushes.Green, Brushes.Yellow };

        private void UpdateIRWindow()
        {
            if (InvokeRequired)
            {
                // 別スレッドから呼び出された場合
                Invoke(new UpdateIRWindowDelegate(UpdateIRWindow), irPoints);
                return;
            }

            Graphics g = picBox_IrWindow.CreateGraphics();
            g.Clear(Color.Black);

            for (var i = 0; i < irPoints.Count; i++)
            {
                g.FillEllipse(
                    irColors[i],
                    irPoints[i].X * picBox_IrWindow.Width,
                    irPoints[i].Y * picBox_IrWindow.Height, 10, 10
                );
            }

            if (irDetected)
            {
                g.FillEllipse(
                    Brushes.DeepPink,
                    averagedIrPoint.X * picBox_IrWindow.Width,
                    averagedIrPoint.Y * picBox_IrWindow.Height, 10, 10
                );
            }

            g.Dispose();
        }

        private void DebugInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            OnHiden();
        }
    }
}
