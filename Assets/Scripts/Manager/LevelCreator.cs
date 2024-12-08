namespace Flash.Manager
{
    using System.Collections.Generic;
    using UnityEngine;
    using World;

    public class LevelCreator : MonoBehaviour
    {
        [SerializeField] private int m_RoomCount = 1;
        [SerializeField] private RoomLevel m_RoomPrefab = null;
        [SerializeField] private Transform m_StartPoint = null;
        [SerializeField] private Transform m_RoomParent = null;

        private List<RoomLevel> m_RoomLevels = new List<RoomLevel>();
        
        public void GenerateLevel()
        {
            Vector3 roomPlace = m_StartPoint.position;
            
            for (int i = 0; i < m_RoomCount; i++)
            {
                RoomLevel roomLevel = Instantiate(m_RoomPrefab, roomPlace - m_RoomPrefab.StartPoint.position, Quaternion.identity, m_RoomParent);
                roomPlace = roomLevel.EndPoint.position;
            }
        }
    }
}