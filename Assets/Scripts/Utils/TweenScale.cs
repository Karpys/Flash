namespace Flash.World
{
    using KarpysDev.KarpysUtils.TweenCustom;
    using UnityEngine;

    public class TweenScale : MonoBehaviour
    {
        [SerializeField] private Transform m_Target = null;
        [SerializeField] private Vector3 m_StartScale = Vector3.zero;
        [SerializeField] private Vector3 m_EndScale = Vector3.zero;
        [SerializeField] private float m_Duration = 0.25f;
        [SerializeField] private Ease m_Ease = Ease.LINEAR;
        
        private void Awake()
        {
            m_Target.localScale = m_StartScale;
            m_Target.DoScale(m_EndScale, m_Duration).SetEase(m_Ease);
        }
    }
}