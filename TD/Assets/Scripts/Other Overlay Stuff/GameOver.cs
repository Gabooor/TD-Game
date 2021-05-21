using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false; 
       // Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
