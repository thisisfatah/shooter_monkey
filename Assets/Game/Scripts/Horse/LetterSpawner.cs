using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
	[SerializeField] List<GameObject> letterListPrefab = new List<GameObject>();
	int index;

	private void Start()
	{
		Spawn();
	}

	void Spawn()
	{
		StartCoroutine(SpawnDelay());
	}

	IEnumerator SpawnDelay()
	{
		while(index < letterListPrefab.Count)
		{
			Instantiate(letterListPrefab[index], transform.position, Quaternion.identity);
			index++;
			yield return new WaitForSeconds(10f);
		}
	}
}
