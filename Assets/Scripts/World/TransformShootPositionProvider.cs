namespace Flash.World
{
    using UnityEngine;

    public class TransformShootPositionProvider : IShootPositionProvider
    {
        private Transform m_Transform = null;
        public Vector3 ShootPosition => m_Transform.position;

        public TransformShootPositionProvider(Transform transform)
        {
            m_Transform = transform;
        }
    }
}