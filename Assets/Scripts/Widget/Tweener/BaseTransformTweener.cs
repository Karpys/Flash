namespace Flash.Widget
{
    using UnityEngine;
    
    public abstract class BaseTransformTweener : BaseTweener
    {
        [SerializeField] protected Transform m_Target = null;
        [SerializeField] protected float m_Duration = 0.25f;
    }
}