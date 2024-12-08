namespace Flash.Manager
{
    using System;
    using KarpysDev.KarpysUtils;
    using KarpysDev.KarpysUtils.TweenCustom;
    using UnityEngine;

    public class CameraManager : SingletonMonoBehavior<CameraManager>
    {
        [SerializeField] private float m_AttachSpeed = 0.25f;
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
            float distance = Vector3.Distance(target.position, transform.position);
            transform.DoLocalMove(new Vector3(0,0,-10), m_AttachSpeed.ToTime(distance)).SetEase(m_AttachEase);
        }
    }
}