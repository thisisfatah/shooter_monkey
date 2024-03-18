using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    [SerializeField] bool OpenSetting;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(delegate { OpenSettings(OpenSetting); });
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
}
