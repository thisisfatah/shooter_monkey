using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeLine : MonoBehaviour
{
	LineRenderer lineRenderer;
	EdgeCollider2D edgeCollider;

	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		edgeCollider = GetComponent<EdgeCollider2D>();
	}

	public void Init(Vector2 point, Vector2 lastPoint)
	{
		lineRenderer.SetPosition(0, point);
		lineRenderer.SetPosition(1, lastPoint);
		lineRenderer.useWorldSpace = true;
	}

	public Vector2 GetPosition()
	{
		return lineRenderer.GetPosition(0);
	}
}
