namespace Flash.World
{
	using System;
	using KarpysDev.KarpysUtils.TweenCustom;
	using UnityEngine;

	public class GateController : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] private Transform m_RightGate = null;
		[SerializeField] private Transform m_LeftGate = null;
		[SerializeField] private Transform m_RightGateStartPoint = null;
		[SerializeField] private Transform m_RightGateEndPoint = null;
		[SerializeField] private Transform m_LeftGateStartPoint = null;
		[SerializeField] private Transform m_LeftGateEndPoint = null;
		[SerializeField] private BoxCollider2D m_Collider2D = null;
		
		[Header("Parameters")]
		[SerializeField] private bool m_IsOpen = false;
		[SerializeField] private float m_OpenTime = 0.15f;
		[SerializeField] private Ease m_OpenEase = Ease.LINEAR;

		private void Start()
		{
			if (m_IsOpen)
			{
				OpenInstant();
			}
			else
			{
				CloseInstant();
			}
		}

		private void Update()
		{
			if(Input.GetKeyDown(KeyCode.F))
				Switch();
		}

		public void Switch()
		{
			if (m_IsOpen)
			{
				Close();
			}
			else
			{
				Open();
			}

			m_IsOpen = !m_IsOpen;
		}

		private void Open()
		{
			m_Collider2D.enabled = false;
			m_RightGate.DoKill();
			m_LeftGate.DoKill();
			m_RightGate.DoMove(m_RightGateEndPoint.position, m_OpenTime).SetEase(m_OpenEase);
			m_LeftGate.DoMove(m_LeftGateEndPoint.position, m_OpenTime).SetEase(m_OpenEase);
		}

		private void Close()
		{
			m_Collider2D.enabled = true;
			m_RightGate.DoKill();
			m_LeftGate.DoKill();
			m_RightGate.DoMove(m_RightGateStartPoint.position,  m_OpenTime).SetEase(m_OpenEase);
			m_LeftGate.DoMove(m_LeftGateStartPoint.position, m_OpenTime).SetEase(m_OpenEase);
		}

		private void OpenInstant()
		{
			m_Collider2D.enabled = false;
			m_RightGate.position = m_RightGateEndPoint.position;
			m_LeftGate.position = m_LeftGateEndPoint.position;
		}

		private void CloseInstant()
		{
			m_Collider2D.enabled = true;
			m_RightGate.position = m_RightGateStartPoint.position;
			m_LeftGate.position = m_LeftGateStartPoint.position;
		}
	}
}