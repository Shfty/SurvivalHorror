using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour
{
	[SerializeField]
	Transform m_DoorMesh;
	[SerializeField]
	float m_RotationRate = 2.0f;
	[SerializeField]
	bool m_Locked = false;

	Quaternion m_cachedRotation;
	Quaternion m_targetRotation;

	// Use this for initialization
	void Start()
	{
		m_cachedRotation = transform.rotation;
	}

	// Update is called once per frame
	void Update()
	{
		m_DoorMesh.rotation = Quaternion.Lerp(m_DoorMesh.rotation, m_targetRotation, Time.deltaTime * m_RotationRate);
	}

	public void OpenDoor(bool OpenOutward)
	{
		if(!m_Locked)
		{
			m_targetRotation = m_cachedRotation * Quaternion.AngleAxis((OpenOutward ? 90.0f : -90.0f), Vector3.up);
		}
	}

	public void CloseDoor()
	{
		m_targetRotation = m_cachedRotation;
	}

	public void Lock()
	{
		m_Locked = true;
	}

	public void Unlock()
	{
		m_Locked = false;
	}
}
