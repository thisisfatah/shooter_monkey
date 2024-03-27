using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
	[SerializeField] List<GameObject> letterListPrefab = new List<GameObject>();
	int index;
	float timeToSpawn;

	private void Start()
	{
		Spawn();
	}

	private void Update()
	{

		if (index >= letterListPrefab.Count)
		{
			if (timeToSpawn < 30f) timeToSpawn += Time.deltaTime;

			if (timeToSpawn >= 30f)
			{
				GameManager.GetPlayer.GetComponent<PlayerCollectable>().Letter = 0;
				index = 0;
				Spawn();
			}
		}
	}

	void Spawn()
	{
		StartCoroutine(SpawnDelay());
	}

	IEnumerator SpawnDelay()
	{
		while (index < letterListPrefab.Count)
		{
			Instantiate(letterListPrefab[index], transform.position, Quaternion.identity);
			index++;
			yield return new WaitForSeconds(10f);
		}
	}
}
