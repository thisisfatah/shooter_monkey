using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerCollectable : MonoBehaviour
{
	[SerializeField] int Letter;
	[SerializeField] GameObject HorseObject;
	[SerializeField] Transform horseLocation;
	[SerializeField] float horseColdown = 20f;
	GameObject horse;
	float horseTime;
	bool getHorse = false;

	private void Update()
	{
		if(getHorse)
		{
			if (horseTime < horseColdown) horseTime += Time.deltaTime;

			if (horseTime >= horseColdown)
			{
				horseTime = 0;
				Letter = 0;
				getHorse = false;
				Destroy(horse);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Letter")
		{
			Destroy(collision.gameObject);
			Letter++;
			Debug.Log("Collected Letter = " + Letter.ToString());
			if (Letter >= 5)
			{
				Letter = 0;
				PlayerMovement playerMovement = GetComponent<PlayerMovement>();
				PlayerHealth playerHealth = GetComponent<PlayerHealth>();
				playerHealth.MultipleHealth();
				playerMovement.jump = true;
				playerMovement.multiplierRunSpeed = true;
				getHorse = true;
				StartCoroutine(SpawnDelay());
			}
		}
	}

	IEnumerator SpawnDelay()
	{
		yield return new WaitForSeconds(0.2f);
		horse = Instantiate(HorseObject, horseLocation.position, horseLocation.rotation, horseLocation);
	}
}