namespace Flash.World
{
    using System;
    using UnityEngine;

    public abstract class BaseMonster : MonoBehaviour
    {
        private void Update()
        {
            Behave();
        }

        protected abstract void Behave();
    }
}