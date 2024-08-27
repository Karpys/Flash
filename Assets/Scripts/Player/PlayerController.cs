namespace Flash.Player
{
    using System;
    using UnityEngine;
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform m_Target = null;
        [SerializeField] private Rigidbody2D m_Rigidbody = null;
        [SerializeField] private float m_Speed = 0;

        private void Update()
        {
            Vector2 velocity = GetInputDirection();
            velocity = velocity.normalized * (m_Speed);
            m_Rigidbody.velocity = new Vector3(velocity.x, velocity.y);
        }

        private Vector2 GetInputDirection()
        {
            Vector2 inputDirection = Vector2.zero;

            if (Input.GetKey(KeyCode.A))
                inputDirection.x += -1;
            if (Input.GetKey(KeyCode.D))
                inputDirection.x += 1;
            if (Input.GetKey(KeyCode.W))
                inputDirection.y += 1;
            if (Input.GetKey(KeyCode.S))
                inputDirection.y += -1;

            return inputDirection;
        }
    }
}
