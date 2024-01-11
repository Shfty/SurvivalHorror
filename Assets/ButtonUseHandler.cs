using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

using InControl;

public class ButtonUseHandler : MonoBehaviour {
	List<GameObject> m_clickHandlers = new List<GameObject>();

	// Use this for initialization
	void Update()
	{
		if(InputManager.ActiveDevice.Action4.WasPressed)
		{
			GameObject ClosestObject = null;
			float ClosestDistance = 10000.0f;

			foreach(GameObject ClickHandler in m_clickHandlers)
			{
				if(ClickHandler != null)
				{
					float Distance = Vector3.Dot(ClickHandler.transform.position, transform.forward);
					if(Distance > 0.0f && Distance < ClosestDistance)
					{
						ClosestDistance = Distance;
						ClosestObject = ClickHandler;
					}
				}
			}

			if(ClosestObject != null)
			{
				ClosestObject.GetComponent<IPointerClickHandler>().OnPointerClick(new PointerEventData(EventSystem.current));
			}
		}
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider Collider)
	{
		IPointerClickHandler[] foo = Collider.gameObject.GetComponents<IPointerClickHandler>();

		if(foo.Length > 0)
		{
			m_clickHandlers.Add(Collider.gameObject);
		}
	}

	void OnTriggerExit(Collider Collider)
	{
		if(m_clickHandlers.Contains(Collider.gameObject))
		{
			m_clickHandlers.Remove(Collider.gameObject);
		}
	}
}
