using UnityEngine;
using System.Collections;

public class GameSingleton : MonoBehaviour
{
	public static GameSingleton Instance = null;

	[SerializeField]
	public GameObject PlayerCharacter;
	[SerializeField]
	public GameObject PlayerCamera;
	[SerializeField]
	public Transform PlayerHead;
	[SerializeField]
	public GameObject PlayerWeapons;
	[SerializeField]
	public Vector3 GazePoint;

	public bool EyeObtained = false;
	public bool ShotgunObtained = false;

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if(Instance == null)
		{
			//if not, set instance to this
			Instance = this;
		}
		//If instance already exists and it's not this:
		else if(Instance != this)
		{
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);
		}

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if(Input.GetMouseButtonDown(0))
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}