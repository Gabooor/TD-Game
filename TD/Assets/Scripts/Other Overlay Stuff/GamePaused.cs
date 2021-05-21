using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour
{
    public GameObject GamePausedUI;
    /*
    [Header("Unity Setup Fields")]
    public GameObject playerCamera;
    public GameObject shopCamera1;
    public GameObject shopCamera2;
    public GameObject shopCamera3;*/

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        GamePausedUI.SetActive(!GamePausedUI.activeSelf);

        if (GamePausedUI.activeSelf)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            if (!ShopView.isShopOpened)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }

    public void Restart()
    {
        PauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        Cursor.visible = false;
        //Time.timeScale = 1f;
    }

    public void Menu()
    {
        ShopView.isShopOpened = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
