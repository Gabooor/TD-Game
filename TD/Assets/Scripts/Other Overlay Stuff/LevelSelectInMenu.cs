using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectInMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject LevelSelectUI;

    public void BackToMenu()
    {
        LevelSelectUI.SetActive(false);
        MainMenuUI.SetActive(true);
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
