using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    private bool shopView;
    public static bool isShopOpened;

    BuildManager buildManager;

    [Header("Unity Setup Fields")]
    public GameObject playerCamera;
    public GameObject shopCamera1;
    public GameObject shopCamera2;
    public GameObject shopCamera3;
    public GameObject ShopUI;

    void Start()
    {
        shopView = false; 
        buildManager = BuildManager.instance;
    }

    void Update()
    {
        if (!shopView && Input.GetKeyDown(KeyCode.B))
        {
            playerCamera.SetActive(false);
            shopCamera1.SetActive(true);
            shopView = true;
            Cursor.lockState = CursorLockMode.None;
            ShopUI.gameObject.SetActive(true);
            isShopOpened = true;
            Cursor.visible = true;
        }
        else if(shopView && Input.GetKeyDown(KeyCode.B))
        {
            playerCamera.SetActive(true);
            shopCamera1.SetActive(false);
            shopCamera2.SetActive(false);
            shopCamera3.SetActive(false);
            shopView = false;
            Cursor.lockState = CursorLockMode.Locked;
            ShopUI.gameObject.SetActive(false);
            isShopOpened = false;
            Cursor.visible = false; 
            buildManager.SelectTurretToBuild(null);
        }
    }

    public void Camera1()
    {
        shopCamera1.SetActive(true);
        shopCamera2.SetActive(false);
        shopCamera3.SetActive(false);
    }

    public void Camera2()
    {
        shopCamera1.SetActive(false);
        shopCamera2.SetActive(true);
        shopCamera3.SetActive(false);
    }

    public void Camera3()
    {
        shopCamera1.SetActive(false);
        shopCamera2.SetActive(false);
        shopCamera3.SetActive(true);
    }
}
