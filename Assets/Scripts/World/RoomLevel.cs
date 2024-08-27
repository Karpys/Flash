namespace Flash.World
{
    using System;
    using UnityEngine;

    public class RoomLevel : MonoBehaviour
    {
        [SerializeField] private GateController m_BotGate = null;

        public void StartLevel()
        {
            CloseRoom();
        }

        private void CloseRoom()
        {
            m_BotGate.Switch();
        }
    }
}