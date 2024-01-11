using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	Animator m_animator;

	bool m_Aggro = false;

	float m_WalkSpeed = 0.4f;
	float m_TurnSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if(m_Aggro)
		{
			Vector3 PlayerPos = GameSingleton.Instance.PlayerCharacter.transform.position;
			Vector3 ToPlayer = PlayerPos - transform.position;

			float AngleToPlayer = Vector3.Dot(transform.right, ToPlayer.normalized);

			float PlayerInFront = Vector3.Dot(transform.forward, ToPlayer.normalized);
			PlayerInFront = Mathf.Max(0.0f, PlayerInFront);

			Move(0.5f + (PlayerInFront * 0.5f), AngleToPlayer);
		}
		else
		{
			m_animator.speed = 0.2f;
			m_animator.SetFloat("ForwardBack", 0.4f);
		}
	}

	void Move (float Forward, float Turn)
	{
		m_animator.speed = m_WalkSpeed * Forward * 2.0f;
		m_animator.SetFloat("ForwardBack", Forward);
		m_animator.SetFloat("LeftRight", Turn * 0.2f);

		GetComponent<Rigidbody>().velocity = transform.forward * m_WalkSpeed * Forward;
		transform.rotation *= Quaternion.AngleAxis(Turn * m_TurnSpeed, Vector3.up);
	}

	public void OnTriggerEnter(Collider Other)
	{
		if(Other.GetComponentInParent<ThirdPersonTankControl>() != null)
		{
			m_Aggro = true;
		}
	}
}
