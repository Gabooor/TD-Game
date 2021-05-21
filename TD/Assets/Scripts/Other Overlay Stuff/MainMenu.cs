using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject LevelSelectUI;

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
    }

    public void Play()
    {
        LevelSelectUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
