using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();

        if (btn != null) btn.onClick.AddListener(LoadMenu);
    }

    void LoadMenu()
    {
        LevelController.LoadLevel("MainMenu");
    }
}
