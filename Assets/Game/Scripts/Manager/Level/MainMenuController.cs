using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject menuObject;
    [SerializeField] GameObject rewardObject;
    [SerializeField] GameObject lSFollowLineObject;
    [SerializeField] GameObject lSKnowHijaiyahObject;


    public void OpenMenu()
    {
        menuObject.SetActive(true);
        rewardObject.SetActive(false);
        lSFollowLineObject.SetActive(false);
        lSKnowHijaiyahObject.SetActive(false);
    }

    public void OpenReward()
    {
        menuObject.SetActive(false);
        rewardObject.SetActive(true);
        lSFollowLineObject.SetActive(false);
        lSKnowHijaiyahObject.SetActive(false);
    }

    public void OpenLevelSelectFL()
    {
        menuObject.SetActive(false);
        rewardObject.SetActive(false);
        lSFollowLineObject.SetActive(true);
        lSKnowHijaiyahObject.SetActive(false);
    }

    public void OpenLevelSelectKH()
    {
        menuObject.SetActive(false);
        rewardObject.SetActive(false);
        lSFollowLineObject.SetActive(false);
        lSKnowHijaiyahObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
