namespace UI
{
    using System.Collections.Generic;
    using UnityEngine;

    public class AttackCountUI : MonoBehaviour
    {
        [SerializeField] private RectTransform m_AttackUiHolder = null;
        [SerializeField] private RectTransform m_AttackUI = null;

        private Stack<RectTransform> m_AttackStack = new Stack<RectTransform>();
        public void Initialize(int attackCount)
        {
            for (int i = 0; i < attackCount; i++)
            {
                RectTransform attackUI = Instantiate(m_AttackUI, m_AttackUiHolder);
                m_AttackStack.Push(attackUI);
            }
        }

        public void PopAttack()
        {
            Destroy(m_AttackStack.Pop().gameObject);
        }
    }
}