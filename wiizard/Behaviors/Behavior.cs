using System.Linq;
using System.Collections.Generic;
using WiimoteLib;

namespace wiizard.Behaviors
{
    /// <summary>
    /// 固有の挙動
    /// </summary>
    public interface Behavior
    {
        // Wiiリモコンの状態が変更された時に、Behavior固有の挙動をする
        void Update(WiimoteState ws, WiimoteState prev);

        // ユーザーから変更不可な項目
        List<WiimoteModel> GetDisabledItem();

        // Behaviorの名前 (json用)
        string GetName();

        // 表示名
        string GetDisplayName();
    }

    public class BehaviorManager
    {
        public BehaviorManager()
        {
            m_dic_names = new Dictionary<string, Behavior>();
            m_dic_displayNames = new Dictionary<string, Behavior>();
        }

        public void Add(Behavior b)
        {
            m_dic_names.Add(b.GetName(), b);
            m_dic_displayNames.Add(b.GetDisplayName(), b);
        }

        public List<string> GetBehaviorNames() => m_dic_displayNames.Keys.ToList();

        public Behavior GetBehavior(string name, bool displayName = false)
        {
            if (displayName)
            {
                return m_dic_displayNames[name];
            }

            return m_dic_names[name];
        }

        private Dictionary<string, Behavior> m_dic_names;
        private Dictionary<string, Behavior> m_dic_displayNames;

    }

}
