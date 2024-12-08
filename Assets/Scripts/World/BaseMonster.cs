namespace Flash.World
{
    using KarpysDev.KarpysUtils;
    using Manager;
    using Player;
    using Unity.VisualScripting;
    using UnityEngine;

    public interface ITargetProvider
    {
        Vector3 TargetPosition { get; }
    }

    public abstract class BaseMonster : MonoBehaviour,ITargetProvider
    {
        [SerializeField] private float m_BehaveDelay = 1;

        private ISpawnOrigin m_SpawnOrigin = null;
        private bool m_IsDead = false;
        private Clock m_BehaveSwitch = null;
        private bool m_ActiveBehave = false;
        protected PlayerController m_PlayerController = null;

        public Vector3 TargetPosition => m_PlayerController.transform.position;

        protected virtual void Awake()
        {
            m_PlayerController = GameManager.Instance.PlayerController;
            m_BehaveSwitch = new Clock(m_BehaveDelay, ActiveBehave);
        }

        public void Initialize(ISpawnOrigin spawnOrigin)
        {
            m_SpawnOrigin = spawnOrigin;
        }

        private void ActiveBehave()
        {
            m_ActiveBehave = true;
        }

        private void Update()
        {
            m_BehaveSwitch.UpdateClock();
            
            if(m_ActiveBehave && !m_IsDead)
                Behave();
        }

        protected abstract void Behave();

        protected void TriggerDeath()
        {
            if(m_IsDead)
                return;
            
            m_SpawnOrigin.MonsterDead(this);
            m_IsDead = true;
            DeathAnim();
        }

        protected virtual void DeathAnim()
        {
            Destroy(gameObject);
        }
    }

    public interface ISpawnOrigin
    {
        public void MonsterDead(BaseMonster baseMonster);
    }
}