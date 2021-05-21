using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isJoggingHash;
    int isRunningHash;
    int isJoggingBackwardHash;
    int isRunningBackwardHash;
    int isJumpingHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        isJoggingHash = Animator.StringToHash("isJogging");
        isRunningHash = Animator.StringToHash("isRunning");
        isJoggingBackwardHash = Animator.StringToHash("isJoggingBackward");
        isRunningBackwardHash = Animator.StringToHash("isRunningBackward");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    void Update()
    {
        if (GManager.GameIsOver == true)
        {
            this.enabled = false;
            return;
        }
         
        bool isJogging = animator.GetBool(isJoggingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJoggingBackward = animator.GetBool(isJoggingBackwardHash);
        bool isRunningBackward = animator.GetBool(isRunningBackwardHash);
        bool isJumping = animator.GetBool(isJumpingHash);

        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        
        //START JOGGING
        if (!isJogging && forwardPressed)
        {
            animator.SetBool(isJoggingHash, true);
        }

        //STOP JOGGING
        if (isJogging && !forwardPressed)
        {
            animator.SetBool(isJoggingHash, false);
        }

        //START RUNNING
        if(!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        //STOP RUNNING
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

        //START JOGGING BACKWARD
        if (!isJoggingBackward && backwardPressed)
        {
            animator.SetBool(isJoggingBackwardHash, true);
        }

        //STOP JOGGING BACKWARD
        if (isJoggingBackward && !backwardPressed)
        {
            animator.SetBool(isJoggingBackwardHash, false);
        }

        //START RUNNING BACKWARD
        if (!isRunningBackward && (backwardPressed && runPressed))
        {
            animator.SetBool(isRunningBackwardHash, true);
        }

        //STOP RUNNING BACKWARD
        if (isRunningBackward && (!backwardPressed || !runPressed))
        {
            animator.SetBool(isRunningBackwardHash, false);
        }

        //JUMP TRUE
        if (jumpPressed)
        {
            animator.SetBool(isJumpingHash, true);
        }

        //JUMP FALSE
        if (isJumping)
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}
