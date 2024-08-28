namespace Flash.World
{
    using System;
    using UnityEngine;

    public class RoomLevel : MonoBehaviour
    {
        [SerializeField] private GateController m_BotGate = null;
        [SerializeField] private GateController m_TopGate = null;

        public Action OnRoomStarted = null;
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
    }
}