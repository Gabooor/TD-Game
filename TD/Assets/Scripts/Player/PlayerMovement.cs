using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    private float speed = 8f;
    Vector3 velocity;
    private float gravity = -40f;
    private float groundDistance = 0.4f;
    bool isGrounded;
    private float jumpHeight = 3f;

    [Header("Unity Setup Fields")]
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    void Update()
    {
        if(GManager.GameIsOver == true || GManager.LevelFinished == true)
        {
            this.enabled = false;
            return;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float spr = Input.GetAxis("Sprint");

        Vector3 move = transform.right * x + transform.forward * z;

        if(spr == 1)
        {
            controller.Move(move * speed * Time.deltaTime * 1.7f);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}