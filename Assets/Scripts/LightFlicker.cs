using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
	[SerializeField]
	float m_flickerIntensityScale = 2.0f;
	[SerializeField]
	float m_intensityLerpSpeed = 4.0f;

	[SerializeField]
	float m_flickerDurationLowerBound = 0.01f;
	[SerializeField]
	float m_flickerDurationUpperBound = 0.2f;
	[SerializeField]
	float m_waitDurationLowerBound = 0.1f;
	[SerializeField]
	float m_waitDurationUpperBound = 2.0f;

	float m_timeLeft = 0.0f;
	Light m_light;

	bool m_flickering = false;
	float m_cachedIntensity;
	float m_targetIntensity;

	// Use this for initialization
	void Start()
	{
		m_light = GetComponent<Light>();
		m_cachedIntensity = m_light.intensity;
		m_targetIntensity = m_cachedIntensity;
	}

	// Update is called once per frame
	void Update()
	{
		if(m_timeLeft > 0.0f)
		{
			m_timeLeft -= Time.deltaTime;
		}
		else
		{
			m_flickering = !m_flickering;

			if(m_flickering)
			{
				m_timeLeft = Random.Range(m_flickerDurationLowerBound, m_flickerDurationUpperBound);
				m_targetIntensity = m_cachedIntensity * m_flickerIntensityScale;
			}
			else
			{
				m_timeLeft = Random.Range(m_waitDurationLowerBound, m_waitDurationUpperBound);
				m_targetIntensity = m_cachedIntensity;
			}
		}

		m_light.intensity = Mathf.Lerp(m_light.intensity, m_targetIntensity, Time.deltaTime * m_intensityLerpSpeed);
	}
}
