using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum FadeType
{
    Out,
    In
}

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public static event Action OnFadeOutComplete = () => { };
    public static event Action OnFadeInComplete = () => { };

    [SerializeField] Image fadeImg;

    [SerializeField] GameObject SettingsObj;
    [SerializeField] GameObject pauseObj;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        Fade(FadeType.In, 1f);
    }

    public static void LoadLevel(string name)
    {
        if (instance == null) return;

        Fade(FadeType.Out, 2f);

        instance.StartCoroutine(DelayLoadLevel(name));
    }

    static IEnumerator DelayLoadLevel(string name)
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(name);
        Fade(FadeType.In, 2f);
    }

    public static void Fade(FadeType type, float duration)
    {
        if (instance == null) return;

        switch (type)
        {
            case FadeType.Out:
                instance.fadeImg.DOFade(1, duration).From(0).OnComplete(() =>
                {
                    // Callback after fade
                    OnFadeOutComplete();
                });
                break;
            case FadeType.In:
                instance.fadeImg.DOFade(0, duration).From(1).OnComplete(() =>
                {
                    // Callback after fade
                    OnFadeInComplete();
                });
                break;
        }
    }

    public static void ShowSettingsPanel()
    {
        instance.SettingsObj.SetActive(true);
    }

    public static void HideSettingsPanel()
    {
        instance.SettingsObj.SetActive(false);
    }

    public static void ShowPausePanel()
    {
        instance.pauseObj.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public static void HidePausePanel()
    {
        instance.pauseObj.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
