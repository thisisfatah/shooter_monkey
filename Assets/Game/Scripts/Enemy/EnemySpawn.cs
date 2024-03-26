using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] float spawnColdown = 20f;
	[SerializeField] int spawnCount;
    float spawnTime = 0;

	private void Update()
	{
		if (spawnTime < spawnColdown) spawnTime += Time.deltaTime;

		if(spawnTime >= spawnColdown)
		{
			spawnTime = 0;
			Spawn();
		}
	}

	private void Spawn()
	{
		//Spawn
		StartCoroutine(SpawnDelay());
	}

	IEnumerator SpawnDelay()
	{
		int index = 0;
		while(index < spawnCount)
		{
			index++;
			Instantiate(spawner, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(0.2f);
		}
	}

	public void SetColdown(float newColdown, int newSpawnCount)
	{
		spawnColdown = newColdown;
		spawnCount = newSpawnCount;
	}
}
