namespace Flash.World
{
    using UnityEngine;

    [System.Serializable]
    public struct MonsterSpawn
    {
        [SerializeField] private BaseMonster m_Monster;
        [SerializeField] private Transform m_SpawnPlace;

        public BaseMonster Monster => m_Monster;
        public Transform SpawnPlace => m_SpawnPlace;
    }
}