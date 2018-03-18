using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace wiizard
{
    /// <summary>
    /// プロファイル
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// プロファイルの名前
        /// </summary>
        public string Name;

        /// <summary>
        /// 挙動
        /// </summary>
        public string Behavior;

        /// <summary>
        /// ジョイスティック入力をボタンとして使うかどうか
        /// </summary>
        public bool UseJoystickAsButton;

        /// <summary>
        /// 動作の割り当て
        /// </summary>
        public Dictionary<WiimoteModel, List<ActionAttribute>> ActionAssignments;

        /// <summary>
        /// (非シリアライズ) 保存先
        /// </summary>
        [JsonIgnore]
        public string _path;

        /// <summary>
        /// JSONにシリアライズして保存します。
        /// </summary>
        public void Save(string path)
        {
            var json = JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            using (var sw = new System.IO.StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.Write(json);
            }
        }

        /// <summary>
        /// jsonファイルからProfileを読み込みます。
        /// </summary>
        public static Profile Load(string path)
        {
            string json;
            using (var sr = new System.IO.StreamReader(path, System.Text.Encoding.UTF8))
            {
                json = sr.ReadToEnd();
            }

            var profile = JsonConvert.DeserializeObject<Profile>(json);

            // 構文チェック
            if (profile.ActionAssignments == null || profile.Behavior == null || profile.Name == null)
            {
                throw new System.FormatException("JSONの構文に誤りがあるか, 必要な項目を満たしていません.");
            }

            return profile;
        }

    }

    public class ActionAttribute
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionType Type;

        public string Key;
        public string ModifierKey;

        [JsonConverter(typeof(StringEnumConverter))]
        public MouseAction? MouseAction;

        public int? Delay;

        public bool? Incremental;
        public int? Value;
    }

    public enum ActionType
    {
        Keyboard,
        Mouse
    }

    public enum MouseAction
    {
        MoveDx,
        MoveDy,
        MoveX,
        MoveY,
        ScrollWheel,
        LeftClick,
        RightClick,
        MiddleClick
    }

}
