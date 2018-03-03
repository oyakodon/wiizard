using System;
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

            m_vkcodes = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public byte this[string code]
        {
            get { return Convert.ToByte(m_vkcodes[code], 16); }
        }

        private Dictionary<string, string> m_vkcodes;

    }
}
