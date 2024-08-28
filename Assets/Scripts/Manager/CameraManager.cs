namespace Manager
{
    using System;
    using KarpysDev.KarpysUtils;
    using KarpysDev.KarpysUtils.TweenCustom;
    using UnityEngine;

    public class CameraManager : SingletonMonoBehavior<CameraManager>
    {
        [SerializeField] private float m_AttachDuration = 0.25f;
        [SerializeField] private Ease m_AttachEase = Ease.LINEAR;
        [SerializeField] private Transform m_StartAttach = null;

        private void Awake()
        {
            if(m_StartAttach)
                Attach(m_StartAttach);
        }

        public void Attach(Transform target)
        {
            transform.parent = target;
            transform.DoLocalMove(new Vector3(0,0,-10), m_AttachDuration).SetEase(m_AttachEase);
        }
    }
}