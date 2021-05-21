using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Finished : MonoBehaviour
{
    public GameObject levelSelectUI;
    public GameObject levelFinishedUI;


    public void nextLevel()
    {
        //SceneManager.LoadScene("Level2");
        //Cursor.visible = false;
        Debug.Log("Még nincs level2");
    }

    public void ShowLevelSelection()
    {
        levelSelectUI.SetActive(true);
        levelFinishedUI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
