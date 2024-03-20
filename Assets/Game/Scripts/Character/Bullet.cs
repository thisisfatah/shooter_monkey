using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] float bulletSpeed = 20.0f;

	public void Init(Vector3 position, Quaternion rotation, Vector2 direction)
	{
		Destroy(gameObject, 2.0f);
		transform.position = position;
		transform.rotation = rotation;
		GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
	}
}
