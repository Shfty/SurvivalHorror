using UnityEngine;
using System.Collections;
using InControl;

public class WeaponsControl : MonoBehaviour
{
	[SerializeField]
	Transform FirstPersonWeaponAnchor;
	[SerializeField]
	Transform ThirdPersonWeaponAnchor;
	[SerializeField]
	GameObject[] Weapons;

	public bool m_AttachedToCamera = false;

	int m_gunIndex = 0;
	bool m_prevSwitch = false;

	void Start()
	{
		AttachToCharacter();
	}

	// Update is called once per frame
	void Update()
	{
		bool switchGun = InputManager.ActiveDevice.GetControl(InputControlType.Select);

		if(switchGun && !m_prevSwitch && GameSingleton.Instance.ShotgunObtained)
		{
			if(++m_gunIndex >= Weapons.Length)
			{
				m_gunIndex = 0;
			}

			for(int i = 0; i < Weapons.Length; ++i)
			{
				if(i == m_gunIndex)
				{
					Weapons[i].SetActive(true);
				}
				else
				{
					Weapons[i].SetActive(false);
				}
			}
		}

		m_prevSwitch = switchGun;
	}

	public void AttachToCamera()
	{
		transform.position = FirstPersonWeaponAnchor.position;
		transform.rotation = FirstPersonWeaponAnchor.rotation;
		transform.parent = FirstPersonWeaponAnchor;
		m_AttachedToCamera = true;
	}

	public void AttachToCharacter()
	{
		transform.position = ThirdPersonWeaponAnchor.position;
		transform.rotation = ThirdPersonWeaponAnchor.rotation;
		transform.parent = ThirdPersonWeaponAnchor;
		m_AttachedToCamera = false;
	}
}
