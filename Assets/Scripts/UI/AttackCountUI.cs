namespace UI
{
    using System.Collections.Generic;
    using KarpysDev.KarpysUtils.TweenCustom;
    using UnityEngine;
    using UnityEngine.UI;

    public class AttackCountUI : MonoBehaviour
    {
        [SerializeField] private RectTransform m_AttackUiHolder = null;
        [SerializeField] private RectTransform m_AttackUI = null;
        [SerializeField] private RectTransform m_Layout = null;

        private List<RectTransform> m_AttackStack = new List<RectTransform>();
        public void Initialize(int attackCount)
        {
            for (int i = 0; i < attackCount; i++)
            {
                RectTransform attackUI = Instantiate(m_AttackUI, m_AttackUiHolder);
                m_AttackStack.Add(attackUI);
            }
        }

        public void RemoveAttack()
        {
            int id = m_AttackStack.Count / 2;
            RectTransform attackUI = m_AttackStack[id];
            m_AttackStack.RemoveAt(id);
            attackUI.DoSizeDelta(Vector3.zero, 0.25f).SetEase(Ease.EASE_OUT_SIN);
            attackUI.DoScale(Vector3.zero, 0.25f).SetEase(Ease.EASE_OUT_SIN).OnComplete(() => Destroy(attackUI.gameObject));
        }

        //Todo: Check performance issue or better way to achieve force rebuild
        private void Update()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(m_Layout);
        }
    }
}