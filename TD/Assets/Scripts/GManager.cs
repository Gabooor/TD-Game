using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool LevelFinished;

    public GameObject gameOverUI;

    void Start()
    {
        GameIsOver = false;
        LevelFinished = false;
    }
        
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            EndGame();
        }

        if(PlayerStats.Health <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Cursor.lockState = CursorLockMode.None; 
        Time.timeScale = 0.25f;
        GameIsOver = true;
        gameOverUI.SetActive(true);
        Cursor.visible = true;
    }
}
