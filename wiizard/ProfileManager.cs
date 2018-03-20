using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

using wiizard.Behaviors;

using WiimoteLib;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;

namespace wiizard
{
    public partial class ProfileManager : Form
    {
        public ProfileManager()
        {
            InitializeComponent();
        }

        public void ProfileManager_Load(object sender, EventArgs e)
        {
            m_vkcodes = new VKCodes();
            m_profiles = new List<Profile>();

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

            combo_models.Items.AddRange(Enum.GetNames(typeof(WiimoteModel)).ToArray());

            #endregion

            // Profileフォルダの読み込み
            if (!Directory.Exists("./Profile/"))
            {
                // Defaultプロファイルの作成
                Directory.CreateDirectory("./Profile/");
                var defaultProfile = new Profile();
                defaultProfile.Name = "Default";
                defaultProfile.Behavior = (new StandardBehavior()).GetName();
                defaultProfile.ActionAssignments = new Dictionary<WiimoteModel, List<ActionAttribute>>();
                defaultProfile.Save("./Profile/default.json");
            }

            LoadProfiles();

            // フォルダ内JSON変更の検知
            m_fileSystemWatcher.Path = "./Profile";
            m_fileSystemWatcher.Filter = "*.json";
            m_fileSystemWatcher.SynchronizingObject = this;
            m_fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess;
            m_fileSystemWatcher.Changed += m_fileSystemWatcher_Changed;
            m_fileSystemWatcher.EnableRaisingEvents = true;　//監視を開始

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
        /// <summary>
        /// プロファイルが変更されたか
        /// </summary>
        private bool m_profileChanged;

        /// <summary>
        /// 現在のBehavior
        /// </summary>
        private Behavior m_behavior;
        private BehaviorManager m_bMgr;

        private FileSystemWatcher m_fileSystemWatcher = new FileSystemWatcher();

        /// <summary>
        ///　バージョン
        /// </summary>
        private const string VERSION = "BETABETA 0.1.0";

        private void LoadProfiles()
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

            listBox_profile.Items.Clear();
            foreach (var p in m_profiles)
            {
                listBox_profile.Items.Add(p.Name);
            }
            listBox_profile.SelectedIndex = 0;

        }

        private void m_fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            labStat.Text = "プロファイルの変更を適用しました. (" + DateTime.Now.ToShortTimeString() + ")";
            System.Media.SystemSounds.Asterisk.Play();
            LoadProfiles();
        }

        private void MenuItem_Readme_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/oyakodon/wiizard/tree/master/README.md");
        }

        private void MenuItem_Version_Click(object sender, EventArgs e)
        {
            MessageBox.Show("< Wiizard >\n\nVer. " + VERSION + "\n\n作者: Oyakodon\n(https://github.com/oyakodon/)", "バージョン情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuItem_autoReload_Click(object sender, EventArgs e)
        {
            m_fileSystemWatcher.EnableRaisingEvents = !m_fileSystemWatcher.EnableRaisingEvents;
            MenuItem_autoReload.Checked = m_fileSystemWatcher.EnableRaisingEvents;
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
            m_selectedProfile = m_profiles[(sender as ListBox).SelectedIndex];
            m_behavior = m_bMgr.GetBehavior(m_selectedProfile.Behavior);

            //// 現在の設定をUIに適用
            //foreach (var combo in m_dic_combos.SelectMany(i => i.Value))
            //{
            //    var model = m_dic_combos.First(i => i.Value.Contains(combo)).Key;

            //}

            //// Behaviorで指定されたものを無効化
            //var disabledItem = m_behavior.GetDisabledItem();
            //foreach (var p in m_dic_combos)
            //{
            //    foreach(var combo in p.Value)
            //    {
            //        if (disabledItem.Contains(p.Key))
            //        {
            //            combo.Enabled = false;
            //            combo.Text = "無し";
            //        }
            //        else
            //        {
            //            combo.Enabled = true;
            //        }
            //    }
            //}
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //// プロファイル変更の保存
            //var newProfile = new Profile();
            //newProfile.Name = m_selectedProfile.Name;
            //newProfile.Behavior = m_bMgr.GetBehavior(combo_behavior.Text, true).GetName();
            //newProfile.ActionAssignments = new Dictionary<WiimoteModel, List<ActionAttribute>>();

            //foreach (var combo in m_dic_combos.SelectMany(i => i.Value))
            //{
            //    var attr = new ActionAttribute();
            //    var model = m_dic_combos.First(i => i.Value.Contains(combo)).Key;

            //    if (!check_UseNunchuk.Checked && m_combos_nunchuk.Contains(combo))
            //    {
            //        continue;
            //    }

            //    if ((combo.Name.Contains("Joy") && !check_JoyAsButton.Checked) || (combo.Name.Contains("joy") && !check_JoyAsButton.Checked))
            //    {
            //        continue;
            //    }

            //    if (m_dic_mouseAction.ContainsKey(combo.Text))
            //    {
            //        attr.Type = ActionType.Mouse;
            //        attr.MouseAction = m_dic_mouseAction[combo.Text];
            //    }
            //    else
            //    {
            //        attr.Type = ActionType.Keyboard;
            //        attr.Key = combo.Text;
            //    }

            //    newProfile.ActionAssignments.Add(model, new List<ActionAttribute> { attr });
            //}

            //newProfile.Save(newProfile._path);
            
        }

        private void panel_config_wiiimg_MouseUp(object sender, MouseEventArgs e)
        {

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

        }
    }

}
