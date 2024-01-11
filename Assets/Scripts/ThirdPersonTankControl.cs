using UnityEngine;
using System;
using System.Collections;

using UnityStandardAssets.Characters.ThirdPerson;
using InControl;

public class ThirdPersonTankControl : MonoBehaviour
{
	public bool m_active = true;

	private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
	private Vector3 m_Move;

	bool m_quickturning = false;
	Vector3 m_quickturnTarget;
	float m_quickturnSpeed = 540.0f;
	float m_cachedTurnSpeed = 0.0f;

	private void Start()
	{
		// get the third person character ( this should never be null due to require component )
		m_Character = GetComponent<ThirdPersonCharacter>();
	}

	// Fixed update is called in sync with physics
	private void FixedUpdate()
	{
		if(m_active)
		{
			if(m_quickturning)
			{
				m_Character.Move(Vector3.right, false, false);
				if(Vector3.Dot(transform.forward, m_quickturnTarget) >= 0.999f)
				{
					m_quickturning = false;
					m_Character.m_StationaryTurnSpeed = m_cachedTurnSpeed;
				}
			}
			else
			{
				// read inputs
				float h = 0.0f;
				float v = 0.0f;

				h = Mathf.Round(InputManager.ActiveDevice.LeftStickX + InputManager.ActiveDevice.DPadX);
				v = Mathf.Round(InputManager.ActiveDevice.LeftStickY + InputManager.ActiveDevice.DPadY);

				// calculate move direction to pass to character
				m_Move = new Vector3(h, 0.0f, v);

				m_Move.x *= 0.5f;
				m_Move.z *= 0.5f;

				// walk/run speed multiplier
				if(v > 0.0f)
				{
					if(InputManager.ActiveDevice.Action2)
					{
						m_Move.z *= 1.5f;
					}
				}
				else if(v < 0.0f)
				{
					if(InputManager.ActiveDevice.Action2.WasPressed)
					{
						m_quickturnTarget = transform.forward * -1;
						m_quickturning = true;
						m_cachedTurnSpeed = m_Character.m_StationaryTurnSpeed;
						m_Character.m_StationaryTurnSpeed = m_quickturnSpeed;
					}
				}
			}
		}
		else
		{
			m_Move = Vector3.zero;
		}

		// pass all parameters to the character control script
		m_Character.Move(m_Move, false, false);
	}

	void OnDisable()
	{
		m_Move = Vector3.zero;
		m_Character.Move(m_Move, false, false);
	}
}
