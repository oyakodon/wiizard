using System;
using System.Threading;
using System.Threading.Tasks;   
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

using wiizard.Behaviors;

using System.IO;
using System.Drawing;

namespace wiizard
{
    public partial class Profiler : Form
    {
        public Profiler()
        {
            InitializeComponent();
        }

        public void Profiler_Load(object sender, EventArgs e)
        {
            m_vkcodes = new VKCodes();
            m_profiles = new List<Profile>();

            // ModelRect
            m_dic_buttonRect = new Dictionary<WiimoteModel, Rectangle>();
            ReadRectFromCsv(csv: Properties.Resources.modelRect);

            // Behavior
            m_bMgr = new BehaviorManager();
            m_bMgr.Add(new StandardBehavior());
            m_bMgr.Add(new MinecraftBehavior());

            m_dic_mouseAction = new Dictionary<string, MouseAction>
            {
                { "マウスのXを相対移動",    MouseAction.MoveDx },
                { "マウスのYを相対移動",    MouseAction.MoveDy },
                { "マウスのXを指定",        MouseAction.MoveX },
                { "マウスのYを指定",        MouseAction.MoveY },
                { "マウスのホイールを回転",  MouseAction.ScrollWheel },
                { "マウスの左クリック",      MouseAction.LeftClick },
                { "マウスの右クリック",      MouseAction.RightClick },
                { "マウスの中クリック",      MouseAction.MiddleClick }
            };

            // 装飾キーを追加
            m_dic_modKeys = new Dictionary<string, byte>
            {
                { "Shift",  m_vkcodes["Shift"] },
                { "Ctrl",   m_vkcodes["Ctrl"] },
                { "Alt",    m_vkcodes["Alt"] },
                { "Win",    m_vkcodes["LWin"] }
            };

            #region UIの初期化
            // RadioButton
            radioBtn_none.Checked = true;

            // Behavior
            combo_behavior.Items.AddRange(m_bMgr.GetBehaviorNames().ToArray());
            combo_behavior.SelectedIndex = 0;

            // キーボード
            combo_key.Items.AddRange(m_vkcodes.GetKeys().ToArray());

            // マウス
            combo_mouse.Items.AddRange(m_dic_mouseAction.Keys.ToArray());


            // 装飾キー
            combo_modKey.Items.AddRange(m_dic_modKeys.Keys.ToArray());

            #endregion

            LoadProfiles();

            // 詳細タブ
            listBox_models.Items.AddRange(Enum.GetNames(typeof(WiimoteModel)).Where(x => x != "N_STICK").ToArray());
            listBox_models.SelectedIndex = 0;

        }

        /// <summary>
        /// 仮想キー辞書
        /// </summary>
        private VKCodes m_vkcodes;
        /// <summary>
        /// マウス動作辞書
        /// </summary>
        private Dictionary<string, MouseAction> m_dic_mouseAction;
        /// <summary>
        /// 装飾キー辞書
        /// </summary>
        private Dictionary<string, byte> m_dic_modKeys;

        /// <summary>
        ///  プロファイル
        /// </summary>
        private List<Profile> m_profiles;
        /// <summary>
        /// 選択されているプロファイル
        /// </summary>
        private Profile m_selectedProfile;

        private BehaviorManager m_bMgr;

        private Dictionary<WiimoteModel, Rectangle> m_dic_buttonRect;

        private Point? m_mousePos = null;

        private bool m_profileChanged = false;

        /// <summary>
        /// プロファイルを読み込み、UIを更新します
        /// </summary>
        private void LoadProfiles(int idx = 0)
        {
            Thread.Sleep(100); // ファイルアクセス衝突防止
            m_profiles.Clear();

            foreach (var path in Directory.EnumerateFiles("./Profile/"))
            {
                try
                {
                    var profile = Profile.Load(path);
                    profile._path = path;
                    m_profiles.Add(profile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("重大なエラーが発生しました。\n終了します。\n\nエラー内容: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Environment.Exit(1);
                }
            }

            // ListBoxに反映
            listBox_profile.Items.Clear();
            foreach (var p in m_profiles)
            {
                listBox_profile.Items.Add(p.Name);
            }
            listBox_profile.SelectedIndex = idx;

        }

        /// <summary>
        /// 画像上のボタンの座標をCSVから読み込みます
        /// </summary>
        private void ReadRectFromCsv(string csv)
        {
            foreach (var line in csv.Split('\n'))
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var sp = line.Split(',');
                var idx = 0;
                var model = (WiimoteModel)Enum.Parse(typeof(WiimoteModel), sp[idx++]);
                var rect = new Rectangle(int.Parse(sp[idx++]), int.Parse(sp[idx++]), int.Parse(sp[idx++]), int.Parse(sp[idx++]));
                m_dic_buttonRect.Add(model, rect);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // プロファイルの保存
            m_selectedProfile.Save();

            MessageBox.Show("プロファイルは正常に保存されました。", "Wiizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // 変更をm_selectedProfileに反映
            WiimoteModel selectedModel;

            if (tabControl_config.SelectedIndex != 1)
            {
                if (!m_mousePos.HasValue || !m_dic_buttonRect.Values.Any(x => x.Contains(m_mousePos.Value)))
                {
                    return;
                }

                selectedModel = m_dic_buttonRect.First(x => x.Value.Contains(m_mousePos.Value)).Key;
            }
            else
            {
                // 「詳細」タブの時
                selectedModel = (WiimoteModel)Enum.Parse(typeof(WiimoteModel), listBox_models.SelectedItem.ToString());
            }

            if (radioBtn_key.Checked)
            {

            }
            else if (radioBtn_mouse.Checked)
            {

            }
            else
            {
                // None

            }

            m_profileChanged = true;

        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            combo_key.Enabled = false;
            combo_mouse.Enabled = false;

            combo_modKey.Enabled = false;
            num_value.Enabled = false;

            if (radioBtn_key.Checked)
            {
                combo_key.Enabled = true;
                combo_modKey.Enabled = true;
            }
            else if (radioBtn_mouse.Checked)
            {
                combo_mouse.Enabled = true;
                num_value.Enabled = true;
            }
        }

        private void combo_models_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedModel = (WiimoteModel)Enum.Parse(typeof(WiimoteModel), listBox_models.SelectedItem.ToString());
            listBox_actions.Items.Clear();

            if (m_selectedProfile.ActionAssignments.ContainsKey(selectedModel))
            {
                foreach (var act in m_selectedProfile.ActionAssignments[selectedModel])
                {
                    string context;
                    context = act.Delay.GetValueOrDefault(defaultValue: 0) + " ";
                    context += (act.Type == ActionType.Keyboard) ? "<Key> " + act.Key : "<Mouse> " + act.MouseAction.Value.ToString();

                    listBox_actions.Items.Add(context);
                }
            }
        }

        private void panel_config_wiiimg_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            pos.Offset(-10, -10);
            pos = GetImagePos(picBox_wii, pos);
            // labStat.Text = $"Button: {pos.X},{pos.Y}";

            var disabled = m_bMgr.GetBehavior(m_selectedProfile.Behavior).GetDisabledItem();
            if (m_dic_buttonRect.Any(x => !disabled.Contains(x.Key) && x.Value.Contains(pos)))
            {
                m_mousePos = pos;
                picBox_wii_Paint();
            }
        }

        private void MenuItem_Readme_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Configuration.README_URL);
        }

        private void MenuItem_Version_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Configuration.GetAuthor(), "バージョン情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listBox_profile_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index > -1)
            {
                Brush b = new SolidBrush(e.ForeColor);

                if ((e.State & DrawItemState.Disabled) == DrawItemState.Disabled)
                {
                    if ((e.State & DrawItemState.Selected) != DrawItemState.Selected)
                    {
                        b = new SolidBrush(Color.Black);

                        e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                    }
                }

                var sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;

                var itemText = (sender as ListBox).Items[e.Index].ToString();

                e.Graphics.DrawString(itemText, e.Font, b, e.Bounds, sf);

                b.Dispose();

            }

            e.DrawFocusRectangle();
        }

        private void listBox_profile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_profileChanged)
            {
                var dlg = MessageBox.Show("プロファイルへの変更内容を保存しますか？", "Wiizard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlg == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                }

                m_profileChanged = false;
            }

            m_selectedProfile = m_profiles[(sender as ListBox).SelectedIndex];

            // 現在の設定をUIに適用
            m_mousePos = null;
            picBox_wii_Paint();
        }

        private void picBox_wii_Paint()
        {
            var img = (Image)picBox_wii.InitialImage.Clone();
            var g = Graphics.FromImage(img);

            var fill_normal = Color.FromArgb(64, Color.Orange);
            var fill_selected = Color.FromArgb(128, SystemColors.Highlight);
            var fill_assigned = Color.FromArgb(128, Color.LawnGreen);
            var fill_disabled = Color.FromArgb(128, Color.LightGray);

            var disabled = m_bMgr.GetBehavior(m_selectedProfile.Behavior).GetDisabledItem();

            foreach (var item in m_dic_buttonRect)
            {
                var rect = item.Value;
                var fillColor = fill_normal;
                var pen = new Pen(Color.Black, 2);

                if (disabled.Contains(item.Key))
                {
                    fillColor = fill_disabled;
                    pen = new Pen(Color.Black, 2);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                }
                else if (m_mousePos.HasValue && rect.Contains(m_mousePos.Value))
                {
                    fillColor = fill_selected;
                    pen = new Pen(SystemColors.Highlight, 4);
                }
                else if (m_selectedProfile.ActionAssignments.ContainsKey(item.Key))
                {
                    fillColor = fill_assigned;
                    pen = new Pen(Color.Green, 2);
                }

                g.FillRectangle(new SolidBrush(fillColor), rect);
                g.DrawRectangle(pen, rect);
            }

            g.Dispose();
            picBox_wii.Image = img;

        }

        private void tabControl_config_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Text = (tabControl_config.SelectedIndex == 1) ? "追加(&A)" : "適用(&A)";
        }

        private void listBox_actions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedModel = (WiimoteModel)Enum.Parse(typeof(WiimoteModel), listBox_models.SelectedItem.ToString());
            var selected = m_selectedProfile.ActionAssignments[selectedModel][listBox_actions.SelectedIndex];
            if (selected.Type == ActionType.Keyboard)
            {
                radioBtn_key.Checked = true;
                combo_modKey.Enabled = true;
            }
            else
            {
                radioBtn_mouse.Checked = true;
            }

            num_delay.Value = selected.Delay.GetValueOrDefault(defaultValue: 0);
            num_value.Enabled = selected.Value.HasValue;
            num_value.Value = selected.Value.GetValueOrDefault(defaultValue: 0);

            check_inc.Checked = selected.Incremental.GetValueOrDefault(defaultValue: false);
        }

        private Point GetImagePos(PictureBox picBox, Point mPos)
        {
            int W = picBox.Image.Width;
            int H = picBox.Image.Height;

            var imgScale = Math.Min((double)picBox.Width / W, (double)picBox.Height / H);

            var imgX = (picBox.Width - (W * imgScale)) / 2.0;
            var imgY = (picBox.Height - (H * imgScale)) / 2.0;

            var ret = new Point();
            ret.X = (int)((mPos.X - imgX) / imgScale);
            ret.Y = (int)((mPos.Y - imgY) / imgScale);

            return ret;
        }

    }

    public enum ModelType : int
    {
        Button = 0,
        AccIR = 1
    }

}
