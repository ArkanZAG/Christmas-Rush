using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMechanic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private int playerMoveSpeed;
    [SerializeField] private int playerJumpHeight;
    [SerializeField] private Animator playerAnimator;
    private bool isGrounded;
    void Start()
    {
        
    }
    
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
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        playerAnimator.SetBool("Run", horizontalInput != 0);
        playerAnimator.SetBool("isGrounded", isGrounded);
    }

    private void Jump()
    {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerJumpHeight);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
