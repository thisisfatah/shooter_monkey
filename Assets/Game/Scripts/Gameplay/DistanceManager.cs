using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
	Vector3 startPoint;
	[SerializeField] TextMeshProUGUI distanceText;

	[SerializeField] EnemySpawn enemySpawnSoldier;
	[SerializeField] EnemySpawn enemySpawnSquadLeader;
	[SerializeField] EnemySpawn enemySpawnCommanders;
	[HideInInspector] public double distanceFloor;

	private void Start()
	{
		startPoint = GameManager.GetPlayer.transform.position;
	}

	private void Update()
	{
		float distance = Vector3.Distance(startPoint, GameManager.GetPlayer.transform.position);
		distanceFloor = Math.Floor(distance);
		if (distance >= 0)
		{
			distanceText.text = distanceFloor.ToString();
		}

		if (distanceFloor == 1000)
		{
			enemySpawnSoldier.SetColdown(8, 3);
			enemySpawnSquadLeader.SetColdown(12, 2);
			enemySpawnCommanders.SetColdown(16, 1);
		}

		if (distanceFloor == 3000)
		{
			enemySpawnSoldier.SetColdown(2, 5);
			enemySpawnSquadLeader.SetColdown(4, 3);
			enemySpawnCommanders.SetColdown(8, 2);
		}

		if (distanceFloor == 5000)
		{
			//Win Condition
		}
	}
}
