namespace Flash.Manager
{
    using Player;
    using KarpysDev.KarpysUtils;
    using UnityEngine;

    public class GameManager : SingletonMonoBehavior<GameManager>
    {
        [SerializeField] private PlayerController m_PlayerController = null;

        public PlayerController PlayerController => m_PlayerController;
    }
}