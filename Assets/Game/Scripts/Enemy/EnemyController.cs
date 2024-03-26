using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] float speed = 20f;
	[SerializeField] Rigidbody2D rb;
	bool m_FacingRight;

	Vector3 m_Velocity = Vector3.zero;

	[Space(10)]
	[Header("Firing")]
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] float firingColdown;
	[SerializeField] float damage;
	float firingTimer;

	void Start()
	{
		firingTimer = firingColdown;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Vector2 difference = (Vector2)GameManager.GetPlayer.transform.position - (Vector2)transform.position;
		Vector2 direction = difference.normalized;
		float move = direction.x * speed * Time.fixedDeltaTime;
		Vector3 targetVelocity = new Vector2(move * 10, rb.velocity.y);

		float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		if (move > 0.01f && m_FacingRight)
		{
			Flip();
		}
		else if (move < 0.01f && !m_FacingRight)
		{
			Flip();
		}

		float distance = Vector2.Distance(rb.position, (Vector2)GameManager.GetPlayer.transform.position);

		if (distance > 5)
		{
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, 0.09f);
		}
		else
		{
			if (firingTimer < firingColdown) firingTimer += Time.deltaTime;

			if (firingTimer >= firingColdown)
			{
				firingTimer = 0;
				//Firing
				FireBullet(direction, rotationZ);
			}
		}
	}

	private void FireBullet(Vector2 direction, float rotationZ)
	{
		GameObject gO = Instantiate(bulletPrefab) as GameObject;
		gO.GetComponent<Bullet>().Init(transform.position, Quaternion.Euler(0.0f, 0.0f, rotationZ), direction, damage);
	}

	void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
