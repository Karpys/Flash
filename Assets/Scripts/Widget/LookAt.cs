namespace Widget
{
    using System;
    using UnityEngine;

    public class LookAt : MonoBehaviour
    {
        [SerializeField] private Transform m_Transform = null;
        [SerializeField] private Transform m_Target = null;
        [SerializeField] private float m_Offset = 0;

        public void SetTarget(Transform target)
        {
            m_Target = target;
        }

        private void Update()
        {
            if(!m_Target)
                return;
            
            Vector3 direction = m_Target.position - m_Transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + m_Offset));
        }
    }
}