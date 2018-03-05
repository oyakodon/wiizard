using System;
using System.Collections.Generic;
using WiimoteLib;

namespace wiizard.Behaviors
{
    // 標準の挙動
    public class StandardBehavior : Behavior
    {
        public List<WiimoteModel> GetDisabledItem() => new List<WiimoteModel>();

        public string GetName() => "Standard";

        public string GetDisplayName() => "標準";

        public void Update(WiimoteState ws, WiimoteState prev)
        {
            // Do Nothing.
        }

    }
}
