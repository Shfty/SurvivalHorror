using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using InControl;
using UnityStandardAssets.Characters.ThirdPerson;

public class CameraControl : MonoBehaviour
{
	[SerializeField]
	public GameObject m_CameraAnchor;
	[SerializeField]
	Image m_blackFade;

	public bool m_anchored = false;
	bool m_prevSwitch = false;
	float m_fadeOpacity = 1.0f;
	float m_targetOpacity = 0.0f;
	float m_fadeSpeed = 15.0f;

	bool m_switchRequested = false;
	bool m_targetState = true;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// check for camera switch input
		bool SwitchCam = false;

		if(InputManager.Devices.Count > 0)
		{
			SwitchCam = InputManager.Devices[0].Action3;
		}

		if(SwitchCam && !m_prevSwitch)
		{
			if(m_anchored)
			{
				RequestMoveToCharacter();
			}
			else
			{
				RequestMoveToAnchor();
			}
		}

		m_prevSwitch = SwitchCam;

		// Handle fade-to-black
		m_fadeOpacity = Mathf.Lerp(m_fadeOpacity, m_targetOpacity, Time.deltaTime * m_fadeSpeed);
		Color c = m_blackFade.color;
		c.a = m_fadeOpacity;
		m_blackFade.color = c;

		// Trigger transitions when fade opacity reaches its target
		if((Mathf.Abs(m_fadeOpacity - m_targetOpacity) < 0.01f) && m_switchRequested)
		{
			if(m_targetState)
			{
				MoveToAnchor();
			}
			else
			{
				MoveToCharacter();
			}

			m_switchRequested = false;
			m_targetOpacity = 0.0f;
		}

		// Camera anchor orientation control
		if(!m_anchored)
		{
			GameSingleton.Instance.PlayerCharacter.transform.rotation = Quaternion.AngleAxis(GetComponentInChildren<CardboardHead>().transform.rotation.eulerAngles.y, Vector3.up);
			m_CameraAnchor.transform.rotation = Quaternion.LookRotation(GameSingleton.Instance.PlayerHead.position - m_CameraAnchor.transform.position);
		}
		else
		{
			m_CameraAnchor.transform.rotation = GetComponentInChildren<Cardboard>().HeadPose.Orientation;
		}
	}

	public void SetAnchor(GameObject Anchor)
	{
		if(m_CameraAnchor != null)
		{
			m_CameraAnchor.GetComponent<CameraLookAt>().enabled = true;
		}

		if(Anchor != null)
		{
			m_CameraAnchor = Anchor;
			m_CameraAnchor.GetComponent<CameraLookAt>().enabled = false;
		}
	}

	public void RequestMoveToAnchor()
	{
		m_targetState = true;
		m_switchRequested = true;
		m_targetOpacity = 1.0f;
	}

	public void RequestMoveToCharacter()
	{
		m_targetState = false;
		m_switchRequested = true;
		m_targetOpacity = 1.0f;
	}

	void MoveToAnchor()
	{
		if(m_CameraAnchor != null)
		{
			GameSingleton.Instance.PlayerCharacter.GetComponent<ThirdPersonTankControl>().m_active = true;
			GameSingleton.Instance.PlayerCharacter.GetComponent<ThirdPersonCharacter>().ResetAnimator();

			GameSingleton.Instance.PlayerWeapons.GetComponent<WeaponsControl>().AttachToCharacter();

			SkinnedMeshRenderer[] Meshes = GameSingleton.Instance.PlayerCharacter.GetComponentsInChildren<SkinnedMeshRenderer>();
			for(int i = 0; i < Meshes.Length; ++i)
			{
				Meshes[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
			}

			MeshRenderer[] CameraMeshes = m_CameraAnchor.GetComponentsInChildren<MeshRenderer>();
			for(int i = 0; i < CameraMeshes.Length; ++i)
			{
				CameraMeshes[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
			}

			GetComponentInChildren<PlayerLookAt>().m_FirstPerson = false;

			transform.position = m_CameraAnchor.transform.position;
			YawFromTo(GetComponentInChildren<Cardboard>().HeadPose.Orientation, Quaternion.LookRotation(GameSingleton.Instance.PlayerHead.position - m_CameraAnchor.transform.position));

			m_anchored = true;
		}
	}

	void MoveToCharacter()
	{
		GameSingleton.Instance.PlayerCharacter.GetComponent<ThirdPersonTankControl>().m_active = false;
		GameSingleton.Instance.PlayerCharacter.GetComponent<ThirdPersonCharacter>().ResetAnimator();

		GameSingleton.Instance.PlayerWeapons.GetComponent<WeaponsControl>().AttachToCamera();

		SkinnedMeshRenderer[] Meshes = GameSingleton.Instance.PlayerCharacter.GetComponentsInChildren<SkinnedMeshRenderer>();
		for(int i = 0; i < Meshes.Length; ++i)
		{
			Meshes[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
		}

		MeshRenderer[] CameraMeshes = m_CameraAnchor.GetComponentsInChildren<MeshRenderer>();
		for(int i = 0; i < CameraMeshes.Length; ++i)
		{
			CameraMeshes[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		}

		GetComponentInChildren<PlayerLookAt>().m_FirstPerson = true;

		transform.position = GameSingleton.Instance.PlayerCharacter.transform.position + (1.3f * Vector3.up);
		YawFromTo(GetComponentInChildren<Cardboard>().HeadPose.Orientation, GameSingleton.Instance.PlayerCharacter.transform.rotation);

		m_anchored = false;
	}

	void YawFromTo(Quaternion From, Quaternion To)
	{
		float DeltaYaw = To.eulerAngles.y - From.eulerAngles.y;
		Quaternion DeltaQuaternion = Quaternion.AngleAxis(DeltaYaw, Vector3.up);

		transform.rotation = DeltaQuaternion;
	}
}
