using System.Collections;
using UnityEngine;

public class PlayerCollectable : MonoBehaviour
{
	[HideInInspector] public int Letter;
	[SerializeField] GameObject HorseObject;
	[SerializeField] Transform horseLocation;
	[SerializeField] float horseColdown = 20f;
	GameObject horse;
	float horseTime;
	bool getHorse = false;

	private void Update()
	{
		if (getHorse)
		{
			if (horseTime < horseColdown) horseTime += Time.deltaTime;

			if (horseTime >= 5)
			{
				PlayerController2D controller2D = GetComponent<PlayerController2D>();
				controller2D.m_multipleSpeed = 1.5f;
			}

			if (horseTime >= horseColdown)
			{
				horseTime = 0;
				Letter = 0;
				getHorse = false;
				Destroy(horse);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Letter")
		{
			Letter++;
			Debug.Log("Collected Letter = " + Letter.ToString());
			if (Letter >= 5)
			{
				Letter = 0;
				PlayerMovement playerMovement = GetComponent<PlayerMovement>();
				PlayerController2D controller2D = GetComponent<PlayerController2D>();
				PlayerHealth playerHealth = GetComponent<PlayerHealth>();
				playerHealth.MultipleHealth();
				playerMovement.jump = true;
				playerMovement.multiplierRunSpeed = true;
				controller2D.m_multipleSpeed = 2f;
				getHorse = true;
				StartCoroutine(SpawnDelay());
			}
			Destroy(collision.gameObject);
		}

		if (collision.tag == "Banana")
		{
			DataScore.Score += 2;
			DataScore.Banana += 1;
			Destroy(collision.gameObject);
		}
	}

	IEnumerator SpawnDelay()
	{
		yield return new WaitForSeconds(0.2f);
		horse = Instantiate(HorseObject, horseLocation.position, horseLocation.rotation, horseLocation);
	}
}