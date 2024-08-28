namespace Flash.World
{
    using Manager;
    using UnityEngine;

    public class RoomEnterCollision : MonoBehaviour
    {
        [SerializeReference] private RoomLevel m_Level = null;
        private bool m_HasTrigger = false;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(m_HasTrigger)
                return;
            
            if (other.CompareTag("Player"))
            {
                m_HasTrigger = true;   
                PlayerEnter();
            }
        }

        private void PlayerEnter()
        {
            CameraManager.Instance.Attach(m_Level.transform);
            m_Level.StartLevel();
        }
    }
}