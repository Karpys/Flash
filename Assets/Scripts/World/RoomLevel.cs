namespace Flash.World
{
    using System;
    using UnityEngine;

    public class RoomLevel : MonoBehaviour
    {
        [SerializeField] private GateController m_BotGate = null;
        [SerializeField] private GateController m_TopGate = null;
        [SerializeField] private Transform m_EndPoint = null;
        [SerializeField] private Transform m_StartPoint = null;

        private int m_CompleteConditionCount = 0;
        private int m_CurrentCompleteCondition = 0;
        public Action OnRoomStarted = null;
        public Transform EndPoint => m_EndPoint;
        public Transform StartPoint => m_StartPoint;
        public void StartLevel()
        {
            CloseRoom();
            OnRoomStarted?.Invoke();
        }

        private void CloseRoom()
        {
            m_BotGate.Switch();
        }

        public void RoomComplete()
        {
            m_TopGate.Switch();
        }

        public void CompleteCondition()
        {
            m_CurrentCompleteCondition++;

            if (m_CompleteConditionCount == m_CurrentCompleteCondition)
                RoomComplete();
        }
        public void AddCompleteCondition()
        {
            m_CompleteConditionCount++;
        }
    }
}