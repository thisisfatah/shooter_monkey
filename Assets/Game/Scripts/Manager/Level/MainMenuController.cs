using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject menuObject;

    public void OpenMenu()
    {
        menuObject.SetActive(true);
    }

    public void CloseMenu()
	{
        menuObject.SetActive(false);
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}
