namespace Flash.Widget
{
    using KarpysDev.KarpysUtils.TweenCustom;
    using UnityEngine;

    public class ScaleTweener : BaseTransformTweener
    {
        [SerializeField] protected Vector3 m_StartValue = Vector3.zero;
        [SerializeField] protected Vector3 m_EndValue = Vector3.zero;
        protected override BaseTween GetTween()
        {
            m_Target.localScale = m_StartValue;
            return m_Target.DoScale(m_EndValue, m_Duration);
        }
    }
}