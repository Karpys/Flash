namespace Flash.Widget
{
    using KarpysDev.KarpysUtils.TweenCustom;
    using UnityEngine;

    public class MoveTweener : BaseTransformTweener
    {
        [SerializeField] private Transform m_Point = null;
        protected override BaseTween GetTween()
        {
            return m_Target.DoMove(m_Point.transform.position, m_Duration);
        }
    }
}