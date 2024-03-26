using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : CharacterHealth
{
	private void Start()
	{
		OnLandEvent.AddListener(KilledEnemy);
	}

	void KilledEnemy()
	{
		Destroy(gameObject);
	}
}
