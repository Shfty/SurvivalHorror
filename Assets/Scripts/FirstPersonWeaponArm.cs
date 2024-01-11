using UnityEngine;
using System.Collections;
using InControl;

public class FirstPersonWeaponArm : MonoBehaviour
{
	[SerializeField]
	public float m_trackingSpeed;
	Quaternion m_targetRotation = Quaternion.identity;

	// Update is called once per frame
	void Update()
	{
		if(InputManager.ActiveDevice.RightBumper && GameSingleton.Instance.PlayerWeapons.GetComponent<WeaponsControl>().m_AttachedToCamera)
		{
			m_targetRotation = Quaternion.LookRotation(GameSingleton.Instance.GazePoint - transform.position);
		}
		else
		{
			m_targetRotation = Quaternion.AngleAxis(transform.parent.rotation.eulerAngles.y, Vector3.up) * Quaternion.AngleAxis(90.0f, Vector3.right) * Quaternion.AngleAxis(-20.0f, Vector3.up);
		}

		transform.rotation = Quaternion.Lerp(transform.rotation, m_targetRotation, Time.deltaTime * m_trackingSpeed);
	}
}
