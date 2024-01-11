using UnityEngine;
using System.Collections;

public class CameraRegionDetector : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		CameraRegion Region = other.gameObject.GetComponent<CameraRegion>();
		if(GameSingleton.Instance.PlayerCamera != null && Region != null)
		{
			CameraControl PlayerCamera = GameSingleton.Instance.PlayerCamera.GetComponent<CameraControl>();
			if(Region.m_CameraAnchor != null && PlayerCamera.m_CameraAnchor != Region.m_CameraAnchor)
			{
				PlayerCamera.SetAnchor(Region.m_CameraAnchor);
				PlayerCamera.RequestMoveToAnchor();
			}
		}
	}
}
