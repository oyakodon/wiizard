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

    }
}
