using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
	[SerializeField] GameObject bulletPrefab;

	bool m_FacingRight;

	float fireTimer = 0f;

	Vector3 target;

	private void Update()
	{
		target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
		Vector3 difference = target - transform.position;
		float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler(0, 0, rotationZ);

		if (Mathf.Abs(rotationZ) < 90.01f && m_FacingRight)
		{
			Flip();
		}
		else if (Mathf.Abs(rotationZ) > 90.01f && !m_FacingRight)
		{
			Flip();
		}

		if (GameManager.GetAmmo > 0)
		{
			if (Input.GetMouseButton(0) && fireTimer <= 0)
			{
				//fire Bullet
				float distance = difference.magnitude;
				Vector2 direction = difference / distance;
				direction.Normalize();
				fireTimer = GameManager.ShootDelay();
				FireBullet(direction, rotationZ);
			}
			else
			{
				fireTimer -= Time.deltaTime;
			}
		}
	}

	void FireBullet(Vector2 direction, float rotationZ)
	{
		StartCoroutine(Shoot(direction, rotationZ));
	}

	IEnumerator Shoot(Vector2 direction, float rotationZ)
	{
		int index = 0;
		while (index < GameManager.BulletSpawnCount())
		{
			index++;
			if (GameManager.GetAmmo > 0)
			{
				GameObject gO = Instantiate(bulletPrefab) as GameObject;
				gO.GetComponent<Bullet>().Init(transform.position, Quaternion.Euler(0.0f, 0.0f, rotationZ), direction, GameManager.GetBulletDamage);
				GameManager.DecreaseAmmo();
			}
			yield return new WaitForSeconds(0.1f);
		}
	}

	void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
	}
}
