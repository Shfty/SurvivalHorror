using UnityEngine;
using System.Collections;

public class DoorCloseHandler : MonoBehaviour
{

	// Use this for initialization
	void OnTriggerExit(Collider Other)
	{
		if(Other.gameObject == GameSingleton.Instance.PlayerCharacter)
		{
			GetComponentInParent<DoorOpener>().CloseDoor();
		}
	}
}
