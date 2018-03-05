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
        public Dictionary<WiimoteModel, string> Assignments;

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
            return JsonConvert.DeserializeObject<Profile>(json);
        }

    }

}
