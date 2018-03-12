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
            m_dic_NameToBehavior = new Dictionary<string, Behavior>();
        }

        public void Add(Behavior b)
        {
            m_dic_NameToBehavior.Add(b.GetName(), b);
        }

        public Behavior GetBehavior(string name)
        {
            return m_dic_NameToBehavior[name];
        }

        private Dictionary<string, Behavior> m_dic_NameToBehavior;

    }

}
