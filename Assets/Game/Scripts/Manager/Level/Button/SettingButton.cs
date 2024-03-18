using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
enum ButtonType
{
	LoadLevel,
	Pause,
	Settings,
	Exit
}

public class SettingButton : MonoBehaviour
{
	[SerializeField] ButtonType buttonType;

	[SerializeField] bool buttonCondition;
	[SerializeField] string goToLevel;

	void Start()
	{
		Button button = GetComponent<Button>();
		switch (buttonType)
		{
			case ButtonType.LoadLevel:
				button.onClick.AddListener(delegate { LoadLevel(goToLevel); });
				break;
			case ButtonType.Pause:
				button.onClick.AddListener(delegate { CheckPauseGame(buttonCondition); });
				break;
			case ButtonType.Settings:
				button.onClick.AddListener(delegate { OpenSettings(buttonCondition); });
				break;
			case ButtonType.Exit:
				ExitGame();
				break;
			default:
				break;
		}
	}

	void LoadLevel(string levelToLoad)
	{
		if (levelToLoad == "") return;

		LevelController.LoadLevel(levelToLoad);
	}

	void CheckPauseGame(bool pause)
	{
		if (pause)
		{
			PauseGame();
		}
		else
		{
			ResumeGame();
		}
	}

	void OpenSettings(bool Open)
	{
		if (Open)
		{
			LevelController.ShowSettingsPanel();
		}
		else
		{
			LevelController.HideSettingsPanel();
		}
	}

	void ExitGame()
	{
		Application.Quit();
	}

	void PauseGame()
	{
		Time.timeScale = 0.0f;
		LevelController.ShowPausePanel();
	}

	void ResumeGame()
	{
		Time.timeScale = 1.0f;
		LevelController.HidePausePanel();
	}
}
