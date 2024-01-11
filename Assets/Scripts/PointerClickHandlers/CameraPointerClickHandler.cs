using UnityEngine;
using UnityEngine.EventSystems;

public class CameraPointerClickHandler : MonoBehaviour, IPointerClickHandler
{
	[SerializeField]
	bool m_MoveToCharacter = false;

	public void OnPointerClick(PointerEventData eventData)
	{
		CameraControl PlayerCamera = GameSingleton.Instance.PlayerCamera.GetComponent<CameraControl>();
		if(PlayerCamera != null)
		{
			if(m_MoveToCharacter)
			{
				PlayerCamera.RequestMoveToCharacter();
			}
			else
			{
				PlayerCamera.SetAnchor(gameObject);
				PlayerCamera.RequestMoveToAnchor();
			}
		}
	}
}