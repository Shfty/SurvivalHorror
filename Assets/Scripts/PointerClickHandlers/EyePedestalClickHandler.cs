using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class EyePedestalClickHandler : MonoBehaviour, IPointerClickHandler
{
	[SerializeField]
	DoorOpener m_DoorOpener;
	[SerializeField]
	GameObject m_PearlMesh;

	public void OnPointerClick(PointerEventData eventData)
	{
		if(GameSingleton.Instance.EyeObtained)
		{
			m_DoorOpener.Unlock();
			m_PearlMesh.SetActive(true);
		}
	}
}
