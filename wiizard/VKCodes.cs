using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

namespace wiizard
{
    public class VKCodes
    {
        public VKCodes()
        {
            // load json file
            string json = null;
            using (var sr = new StreamReader(@"./VKCodes.json", System.Text.Encoding.UTF8))
            {
                json = sr.ReadToEnd();
            }

            vkcodes_dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public bool Contains(string code)
        {
            return vkcodes_dic.ContainsKey(code);
        }

        public List<string> GetKeys()
        {
            return vkcodes_dic.Keys.ToList();
        }

        public byte this[string code]
        {
            get { return Convert.ToByte(vkcodes_dic[code], 16); }
        }

        private Dictionary<string, string> vkcodes_dic;

    }
}
