namespace Flash.World
{
    using System.Collections;
    using UnityEngine;

    public class RoomMonsterSpawn : MonoBehaviour
    {
        [SerializeField] private RoomLevel m_RoomLevel = null;
        [SerializeField] private MonsterSpawn[] m_RoomMonsters = null;
        [SerializeField] private float m_StartDelay = 0.1f;
        [SerializeField] private float m_SpawnAdditiveDelay = 0.1f;

        private void Awake()
        {
            m_RoomLevel.OnRoomStarted += SpawnMonsters;
        }

        private void SpawnMonsters()
        {
            StartCoroutine(CO_SpawnMonsters());
        }

        private IEnumerator CO_SpawnMonsters()
        {
            yield return new WaitForSeconds(m_StartDelay);
            
            for (int i = 0; i < m_RoomMonsters.Length; i++)
            {
                MonsterSpawn roomMonster = m_RoomMonsters[i];
                BaseMonster monster = Instantiate(roomMonster.Monster, roomMonster.SpawnPlace);
                yield return new WaitForSeconds(m_SpawnAdditiveDelay);
            }            
        }
    }
}