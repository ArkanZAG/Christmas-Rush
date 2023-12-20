using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMechanic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private int playerMoveSpeed;
    [SerializeField] private float playerJumpHeight;
    [SerializeField] private Animator playerAnimator;
    private int jumpCounter;
    private bool isGrounded;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        playerRigidBody.velocity = new Vector2(horizontalInput * playerMoveSpeed, playerRigidBody.velocity.y);
        
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                jumpCounter = 1;
                isGrounded = false;
            }
            else if (jumpCounter == 1)
            {
                DoubleJump();
                jumpCounter = 2;
            }
        }

        playerAnimator.SetBool("Run", horizontalInput != 0);
        playerAnimator.SetBool("isGrounded", isGrounded);
        playerAnimator.SetBool("DoubleJump", isGrounded);
    }

    private void Jump()
    {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerJumpHeight);
    }

    private void DoubleJump()
    {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerJumpHeight / 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public Rigidbody2D GetPlayerRigidBody2D()
    {
        return playerRigidBody;
    }
}
