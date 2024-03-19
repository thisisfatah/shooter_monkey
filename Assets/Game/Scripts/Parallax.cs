using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	float length, startPos;
	[SerializeField] GameObject cam;
	[SerializeField] float parallaxEffect;

	private void Start()
	{
		startPos = transform.position.x;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
	}

	private void FixedUpdate()
	{
		float camPositionX = cam.transform.position.x;
		float temp = camPositionX * (1 - parallaxEffect);
		float dist = camPositionX * parallaxEffect;

		transform.position = new Vector3(startPos + dist, transform.position.y,transform.position.z);

		if (temp > startPos + length) startPos += length;
		else if(temp < startPos - length) startPos -= length;
	}
}
