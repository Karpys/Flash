namespace Flash.Widget
{
    using KarpysDev.KarpysUtils.TweenCustom;
    using UnityEngine;

    public abstract class BaseTweener : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private bool m_PlayOnAwake = false;
        [SerializeField] protected Ease m_Ease = Ease.LINEAR;
        [SerializeField] private bool m_UseAnimationCurve = false;
        [SerializeField] protected AnimationCurve m_AnimationCurve = null;
        
        private void Awake()
        {
            if (!m_PlayOnAwake) return;
           PlayTween();
        }

        public void PlayTween()
        {
            if (m_UseAnimationCurve)
            {
                GetTween().SetCurve(m_AnimationCurve);
            }
            else
            {
                GetTween().SetEase(m_Ease);
            }
        }
        
        protected abstract BaseTween GetTween();
    }
}