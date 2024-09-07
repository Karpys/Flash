namespace Flash.World
{
    using System;
    using KarpysDev.KarpysUtils;
    using Manager;
    using UnityEngine;
    using Object = UnityEngine.Object;

    public class ShooterBehaviour : IMonsterBehaviour
    {
        private BaseBulletBehaviour m_Bullet = null;
        private int m_BulletCount = 0;
        private float m_ShootForce = 0;
        private float m_ShootDelay = 0;
        private ITargetProvider m_TargetProvider = null;

        private Clock m_ShootClock = null;
        public Action OnShoot = null;
        public int BulletCount => m_BulletCount;
        public ShooterBehaviour(BaseBulletBehaviour bullet, ITargetProvider targetProvider,int bulletCount, float shootDelay, float shootForce)
        {
            m_Bullet = bullet;
            m_TargetProvider = targetProvider;
            m_BulletCount = bulletCount;
            m_ShootDelay = shootDelay;
            m_ShootForce = shootForce;
            m_ShootClock = new Clock(shootDelay, ShootAt);
        }


        public void Behave()
        {
            if(m_BulletCount <= 0)
                return;
            m_ShootClock.UpdateClock();
        }

        private void ShootAt()
        {
            BaseBulletBehaviour bullet = Object.Instantiate(m_Bullet, GameManager.Instance.BulletRoot);
            bullet.ShootAt(m_TargetProvider.TargetPosition);
            m_BulletCount--;
            m_ShootClock.Restart(m_ShootDelay);
            OnShoot?.Invoke();
        }
    }
}