using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainContainer : MonoBehaviour
{
	public SpriteShapeController shape;

	public int scale = 100;
	public int numOfPoints = 150;
	public float minYPoint = 1.0f;
	public float maxYPoint = 2.0f;

	private void Start()
	{
		shape = GetComponent<SpriteShapeController>();

		shape.spline.SetPosition(2, shape.spline.GetPosition(2) + Vector3.right * scale);
		shape.spline.SetPosition(3, shape.spline.GetPosition(3) + Vector3.right * scale);
		float distanceBwtPoints = (float)scale/(float)numOfPoints;

		for (int i = 0; i < numOfPoints; i++)
		{
			float xPos = shape.spline.GetPosition(i + 1).x + distanceBwtPoints;
			shape.spline.InsertPointAt(i + 2, new Vector3(xPos, Mathf.PerlinNoise(i*Random.Range(minYPoint, maxYPoint),0)));
		}

		for (int i = 0;i < numOfPoints; i++)
		{
			shape.spline.SetTangentMode(i + 1,ShapeTangentMode.Continuous);
			shape.spline.SetLeftTangent(i + 1, new Vector3(-2, 0, 0));
			shape.spline.SetRightTangent(i + 1, new Vector3(2, 0, 0));
		}
	}
}
