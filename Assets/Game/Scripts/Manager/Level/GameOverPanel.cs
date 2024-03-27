using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI bananaText;
	[SerializeField] TextMeshProUGUI killText;
	[SerializeField] TextMeshProUGUI scoreText;

	private void Start()
	{
		bananaText.text = DataScore.Banana.ToString();
		killText.text = DataScore.Kill.ToString();
		int score = DataScore.Score + (int)GameManager.Instance.Distance();
		scoreText.text = score.ToString();
	}
}