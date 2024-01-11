using UnityEngine;
using UnityEngine.EventSystems;

public class DoorPointerClickHandler : MonoBehaviour, IPointerClickHandler
{
	[SerializeField]
	bool m_OpenOutward = false;

	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.pointerPressRaycast.distance < 1.0f)
		{
			GetComponentInParent<DoorOpener>().OpenDoor(m_OpenOutward);
		}
	}
}