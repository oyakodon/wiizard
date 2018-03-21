using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiizard
{
    public static class Configuration
    {
        /// <summary>
        ///　バージョン
        /// </summary>
        public const string VERSION = "BETABETA 0.1.0";

        /// <summary>
        /// 作者情報
        /// </summary>
        public static string GetAuthor() => "< Wiizard >\n\nVer. " + VERSION + "\n\n作者: Oyakodon\n(https://github.com/oyakodon/)";

        /// <summary>
        /// READMEへのリンク
        /// </summary>
        public const string README_URL = "https://github.com/oyakodon/wiizard/tree/master/README.md";

    }
}
