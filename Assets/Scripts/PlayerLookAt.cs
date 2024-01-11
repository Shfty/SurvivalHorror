using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

using InControl;

public class PlayerLookAt : MonoBehaviour
{
	[SerializeField]
	GazeInputModule m_GazeInput;
	[SerializeField]
	GameObject m_GazeCursor;

	public bool m_FirstPerson = false;

	float m_yaw = 0.0f;
	float m_pitch = 0.0f;

	void OnEnable()
	{
		m_GazeInput.enabled = false;
	}

	void OnDisable()
	{
		m_GazeInput.enabled = true;
	}

	void Update()
	{
		if(m_FirstPerson)
		{
			m_GazeInput.enabled = true;
			m_GazeCursor.SetActive(true);

			m_yaw += InputManager.ActiveDevice.DPadX;
			m_pitch -= InputManager.ActiveDevice.DPadY;
			m_pitch = Mathf.Clamp(m_pitch, -90f, 90f);
			transform.rotation = Quaternion.AngleAxis(m_yaw, Vector3.up) * Quaternion.AngleAxis(m_pitch, Vector3.right);
        }
		else
		{
			m_GazeInput.enabled = false;
			m_GazeCursor.SetActive(false);

			m_yaw = GameSingleton.Instance.PlayerCharacter.transform.eulerAngles.y;
			m_pitch = 0.0f;
			transform.rotation = Quaternion.LookRotation(GameSingleton.Instance.PlayerHead.position - transform.position);
		}
	}
}
