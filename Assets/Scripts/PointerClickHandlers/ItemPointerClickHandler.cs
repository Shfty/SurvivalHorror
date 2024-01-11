using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPointerClickHandler : MonoBehaviour, IPointerClickHandler
{
	[SerializeField]
	bool m_GiveEye = false;
	[SerializeField]
	bool m_GiveShotgun = false;
	[SerializeField]
	GameObject[] m_ActivateZombies;

	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.pointerPressRaycast.distance < 1.0f)
		{
			if(m_GiveEye)
			{
				GameSingleton.Instance.EyeObtained = true;
			}

			if(m_GiveShotgun)
			{
				GameSingleton.Instance.ShotgunObtained = true;
			}

			foreach(GameObject Zombie in m_ActivateZombies)
			{
				Zombie.SetActive(true);
			}

			Destroy(gameObject);
		}
	}
}