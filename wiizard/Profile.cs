using Newtonsoft.Json;
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
        /// 割り当て
        /// </summary>
        public Dictionary<WiimoteModel, CommandOption> Assignments;

        /// <summary>
        /// JSONにシリアライズして保存します。
        /// </summary>
        public void Save(string path)
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
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
            if (profile.Assignments == null || profile.Behavior == null || profile.Name == null)
            {
                throw new System.FormatException("JSONの構文に誤りがあるか, 必要な項目を満たしていません.");
            }

            return profile;
        }

    }

    public class CommandOption
    {
        public CommandType type;


    }

    public enum CommandType
    {
        Keyboard,
        Mouse
    }

}
