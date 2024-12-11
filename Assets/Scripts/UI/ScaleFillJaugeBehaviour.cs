namespace Flash.Player
{
    using KarpysDev.KarpysUtils;
    using KarpysDev.KarpysUtils.TweenCustom;
    using UnityEngine;
    using UnityEngine.UI;

    public class ScaleFillJaugeBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform m_Fill = null;
        [SerializeField] private Image[] m_FadeImages = null;
        [SerializeField] private float m_FadeDuration = 0;

        public void JaugeFill(float fillDuration)
        {
            foreach (Image image in m_FadeImages)
            {
                image.color = image.color.setAlpha(1);
            }
            
            m_Fill.localScale = new Vector3(0,1,1);
            m_Fill.DoScale(Vector3.one, fillDuration).OnComplete(Fade);
        }

        private void Fade()
        {
            foreach (Image image in m_FadeImages)
            {
                image.DoColor(image.color.setAlpha(0), m_FadeDuration);
            }
        }
    }
}