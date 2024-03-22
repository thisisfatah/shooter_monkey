using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] float bulletSpeed = 20.0f;
	[SerializeField] float bulletDamage = 0.0f;

	[SerializeField] string targetShoot = "Enemy";

	public void Init(Vector3 position, Quaternion rotation, Vector2 direction, float newDamage)
	{
		Destroy(gameObject, 2.0f);
		transform.position = position;
		transform.rotation = rotation;
		GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
		bulletDamage = newDamage;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == targetShoot)
		{
			Debug.Log(bulletDamage.ToString());
			Destroy(gameObject);
		}
	}
}
