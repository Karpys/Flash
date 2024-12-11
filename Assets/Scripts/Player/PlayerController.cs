namespace Flash.Player
{
    using KarpysDev.KarpysUtils;
    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform m_Target = null;
        [SerializeField] private Rigidbody2D m_Rigidbody = null;
        [SerializeField] private float m_Speed = 0;
        [SerializeField] private float m_DashSpeed = 0;
        [SerializeField] private float m_DashSpeedTime = 0;
        [SerializeField] private float m_DashCooldown = 0;

        [Header("References")]
        [SerializeField] private ScaleFillJaugeBehaviour m_DashJauge = null;
        
        private Vector2 m_PreviousInputDirection = Vector2.zero;
        private bool m_InDash = false;
        private bool m_CanDash = true;
        private Clock m_DashSpeedClock = null;
        private Clock m_DashResetClock = null;

        private void Awake()
        {
            m_DashSpeedClock = new Clock(m_DashSpeedTime, ResetDashState);
            m_DashResetClock = new Clock(m_DashCooldown, ResetCanDash);
        }

        private void Update()
        {
            DashClock();
            DashInput();
            Vector2 velocity = GetInputDirection();
            velocity = velocity.normalized * GetSpeed();
            m_Rigidbody.velocity = new Vector3(velocity.x, velocity.y);
        }

        private float GetSpeed()
        {
            return m_InDash ? m_DashSpeed : m_Speed;
        }

        private Vector2 GetInputDirection()
        {
            if (m_InDash)
                return m_PreviousInputDirection;
            
            Vector2 inputDirection = Vector2.zero;

            if (Input.GetKey(KeyCode.A))
                inputDirection.x += -1;
            if (Input.GetKey(KeyCode.D))
                inputDirection.x += 1;
            if (Input.GetKey(KeyCode.W))
                inputDirection.y += 1;
            if (Input.GetKey(KeyCode.S))
                inputDirection.y += -1;

            m_PreviousInputDirection = inputDirection;
            return inputDirection;
        }
        
        private void DashInput()
        {
            if (Input.GetKeyDown(KeyCode.E) && m_CanDash)
            {
                m_CanDash = false;
                m_InDash = true;
                m_DashSpeedClock.Restart(m_DashSpeedTime);
                m_DashJauge.JaugeFill(m_DashCooldown + m_DashSpeedTime);
            }
        }
        
        private void ResetDashState()
        {
            m_InDash = false;
        }
        
        private void ResetCanDash()
        {
            m_CanDash = true;
        }
        
        private void DashClock()
        {
            if (m_InDash)
            {
                m_DashSpeedClock.UpdateClock();
                
                if(!m_InDash)
                    m_DashResetClock.Restart(m_DashCooldown);
            }else if (!m_CanDash)
            {
                m_DashResetClock.UpdateClock();
            }
        }
    }
}
