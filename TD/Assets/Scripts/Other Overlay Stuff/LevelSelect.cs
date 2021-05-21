using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject LevelSelectUI;

    public void BackToMenu()
    {
        LevelSelectUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadTestLevel()
    {
        SceneManager.LoadScene("TestLevel");
        Cursor.visible = false;
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
        Cursor.visible = false;
    }
}
