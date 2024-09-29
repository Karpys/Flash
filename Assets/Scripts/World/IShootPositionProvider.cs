namespace Flash.World
{
    using UnityEngine;

    public interface IShootPositionProvider
    {
        Vector3 ShootPosition{ get; }
    }
}