using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] float bulletSpeed = 1.0f;
	Vector3 target;

	private void Update()
	{
		target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
		Vector3 difference = target - transform.position;
		float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		Debug.Log(rotationZ.ToString());
		if (Input.GetMouseButtonDown(0))
		{
			//fire Bullet
			float distance = difference.magnitude;
			Vector2 direction = difference / distance;
			direction.Normalize();
			FireBullet(direction, rotationZ);
		}
	}

	void FireBullet(Vector2 direction, float rotationZ)
	{
		GameObject gO = Instantiate(bulletPrefab) as GameObject;
		gO.transform.position = transform.position;
		gO.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
		gO.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
	}
}
