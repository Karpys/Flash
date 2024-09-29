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
        [SerializeField] private BaseBulletBehaviour m_Bullet = null;
        [SerializeField] private Transform m_SpawnPosition = null;
        [SerializeField] private BaseTweener m_ShootTweener = null;

        [Header("Shoot Parameters")]
        [SerializeField] private float m_ShootForce = 1;
        [SerializeField] private float m_ShootDelay = 1;

        private ShooterBehaviour m_ShooterBehaviour = null;
        private TransformShootPositionProvider m_ShootPositionProvider = null;
        protected override void Awake()
        {
            base.Awake();
            m_ShootPositionProvider = new TransformShootPositionProvider(m_SpawnPosition);
            m_GunLookAt.SetTarget(m_PlayerController.transform);
            m_ShooterBehaviour = new ShooterBehaviour(m_Bullet, m_ShootPositionProvider, this, m_BulletCount, m_ShootDelay, m_ShootForce);
            m_AttackCountUI.Initialize(m_BulletCount);
            m_ShooterBehaviour.OnShoot += OnShoot;
        }

        protected override void Behave()
        {
            m_ShooterBehaviour.Behave();
        }

        private void OnShoot()
        {
            m_AttackCountUI.RemoveAttack();
            m_ShootTweener.PlayTween();

            if (m_ShooterBehaviour.BulletCount <= 0)
                TriggerDeath();
        }
    }
}