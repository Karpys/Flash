namespace Flash.World
{
    using UI;
    using UnityEngine;
    using Widget;

    public class GunMonster : BaseMonster
    {
        [Header("Gun Specifics")]
        [SerializeField] private AttackCountUI m_AttackCountUI = null;
        [SerializeField] private LookAt m_GunLookAt = null;
        [SerializeField] private int m_BulletCount = 3;
        [SerializeField] private Transform m_Bullet = null;

        [Header("Shoot Parameters")]
        [SerializeField] private float m_ShootForce = 1;
        [SerializeField] private float m_ShootDelay = 1;

        private ShooterBehaviour m_ShooterBehaviour = null;
        protected override void Awake()
        {
            base.Awake();
            m_GunLookAt.SetTarget(m_PlayerController.transform);
            m_ShooterBehaviour = new ShooterBehaviour(m_Bullet, this, m_BulletCount, m_ShootDelay, m_ShootForce);
            m_AttackCountUI.Initialize(m_BulletCount);
            m_ShooterBehaviour.OnShoot += m_AttackCountUI.PopAttack;
        }

        protected override void Behave()
        {
            m_ShooterBehaviour.Behave();
        }
    }
}