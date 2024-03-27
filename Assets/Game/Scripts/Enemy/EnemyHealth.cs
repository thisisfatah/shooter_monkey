using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : CharacterHealth
{
	[SerializeField] int score;
	private void Start()
	{
		OnDieEvent.AddListener(KilledEnemy);
	}

	void KilledEnemy()
	{
		DataScore.Score += score;
		DataScore.Kill += 1;
		Destroy(gameObject);
	}
}
