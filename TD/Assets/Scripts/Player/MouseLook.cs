using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class MouseLook : MonoBehaviour
{
    private float mouseSensitivity = 200f;
    private float xRotation = 0f;

    [Header("Unity Setup Fields")]
    public Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        if (GManager.GameIsOver == true || GManager.LevelFinished == true)
        {
            this.enabled = false;
            return;
        }

        if (ShopView.isShopOpened == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
