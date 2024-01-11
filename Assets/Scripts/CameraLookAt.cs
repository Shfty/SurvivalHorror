using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour
{
	void Update()
	{
		transform.rotation = Quaternion.LookRotation(GameSingleton.Instance.PlayerHead.position - transform.position);
	}
}
