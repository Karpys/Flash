namespace Flash.Widget
{
    using KarpysDev.KarpysUtils.TweenCustom;
    using UnityEngine;

    [System.Serializable]
    public class TweenerEaseCurve
    {
        [SerializeField] private bool m_UseAnimationCurve = false;
        [SerializeField] protected Ease m_Ease = Ease.LINEAR;
        [SerializeField] protected AnimationCurve m_AnimationCurve = null;
        
        #region Properties

        public bool UseAnimationCurve
        {
            get => m_UseAnimationCurve;
            set => m_UseAnimationCurve = value;
        }
        
        public Ease Ease
        {
            get => m_Ease;
            set => m_Ease = value;
        }
        
        public AnimationCurve AnimationCurve
        {
            get => m_AnimationCurve;
            set => m_AnimationCurve = value;
        }
        #endregion
    }
    public abstract class BaseTweener : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] private bool m_PlayOnAwake = false;
        [SerializeField] private TweenerEaseCurve m_TweenerEaseCurve = null;
        

        #region Properties
        public bool PlayOnAwake
        {
            get => m_PlayOnAwake;
            set => m_PlayOnAwake = value;
        }
        
        #endregion

        private void Awake()
        {
            if (!m_PlayOnAwake) return;
           PlayTween();
        }

        public void PlayTween()
        {
            if (m_TweenerEaseCurve.UseAnimationCurve)
            {
                GetTween().SetCurve(m_TweenerEaseCurve.AnimationCurve);
            }
            else
            {
                GetTween().SetEase(m_TweenerEaseCurve.Ease);
            }
        }
        
        protected abstract BaseTween GetTween();
    }
}