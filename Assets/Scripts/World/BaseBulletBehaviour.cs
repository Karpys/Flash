namespace Flash.World
{
    using UnityEngine;

    public class BaseBulletBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D m_Rigidbody2D = null;
        [SerializeField] private float m_Speed = 0;
        [SerializeField] private float m_Acceleration = 0;
        [SerializeField] private Vector2 m_MinMaxSpeed = Vector2.zero;

        private Vector2 _direction = Vector2.zero;

        private void Update()
        {
            BulletSpeed();
            BulletMovement();
        }

        private void BulletSpeed()
        {
            m_Speed += m_Acceleration * Time.deltaTime;
            m_Speed = Mathf.Clamp(m_Speed, m_MinMaxSpeed.x, m_MinMaxSpeed.y);
        }

        private void BulletMovement()
        {
            m_Rigidbody2D.velocity = _direction * m_Speed;
        }

        public void SetSpeed(float speed)
        {
            m_Speed = 0;
        }

        public void SetAcceleration(float acceleration)
        {
            m_Acceleration = acceleration;
        }

        public void ShootAt(Vector3 position)
        {
            _direction = position - transform.position;
            _direction.Normalize();
        }
    }
}