namespace Flash.World
{
    using UnityEngine;

    public class TestMonster : BaseMonster
    {
        [SerializeField] private Rigidbody2D m_Rigidbody = null;
        [SerializeField] private float m_MonsterSpeed = 0;
        protected override void Behave()
        {
            MoveTo();
        }

        private void MoveTo()
        {
            Vector2 direction = m_PlayerController.transform.position - transform.position;
            m_Rigidbody.velocity = direction.normalized * m_MonsterSpeed;
        }
    }
}