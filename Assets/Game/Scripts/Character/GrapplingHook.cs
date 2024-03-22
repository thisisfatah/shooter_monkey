using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

	[SerializeField] private float grappleLength;
	[SerializeField] private LayerMask grappleLayer;
	RopeLine rope;

	private Vector3 grapplePoint;
	DistanceJoint2D joint;

	Vector3 ropeLastPoint;
	bool getRope = false;

	// Start is called before the first frame update
	void Start()
	{
		joint = gameObject.GetComponent<DistanceJoint2D>();
		joint.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			if (!getRope)
			{
				RaycastHit2D hit = Physics2D.Raycast(
				origin: transform.position,
				direction: Vector2.zero,
				distance: Mathf.Infinity,
				layerMask: grappleLayer);

				if (hit.collider != null)
				{
					rope = hit.transform.GetComponent<RopeLine>();
					grapplePoint.z = 0;
					joint.enabled = true;
					joint.distance = grappleLength;
					ropeLastPoint = transform.position;
					ropeLastPoint.z = 0;
					grapplePoint = rope.transform.position;
					joint.connectedAnchor = grapplePoint;
					rope.Init(grapplePoint, ropeLastPoint);
					//rope.transform.position = Vector2.zero;
					getRope = true;
				}
			}
		}

		if (Input.GetKeyUp(KeyCode.W))
		{
			if (getRope)
			{
				joint.enabled = false;
				if (rope != null)
				{
					rope.Init(grapplePoint, ropeLastPoint);
					rope = null;
					getRope = false;
				}
			}
		}

		if (getRope)
		{
			Vector3 point = transform.position;
			point.z = 0;
			rope.Init(grapplePoint, point);
		}
	}
}
