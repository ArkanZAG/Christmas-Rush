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
    private bool isWalking = false;
    public GameObject playerAudio;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        playerRigidBody.velocity = new Vector2(horizontalInput * playerMoveSpeed, playerRigidBody.velocity.y);
        isWalking = false;
        if (horizontalInput > 0.01f)
        {
            isWalking = true;
            transform.localScale = Vector3.one;
            if (!playerAudio.GetComponent<PlayerAudio>().FootstepSound.isPlaying && isGrounded) {
                playerAudio.GetComponent<PlayerAudio>().playFootstepSound();
            }
        }
        else if (horizontalInput < -0.01f)
        {
            isWalking = true;
            transform.localScale = new Vector3(-1, 1, 1);
            if (!playerAudio.GetComponent<PlayerAudio>().FootstepSound.isPlaying && isGrounded) {
                playerAudio.GetComponent<PlayerAudio>().playFootstepSound();
            }
        }

        if (!isWalking) {
            playerAudio.GetComponent<PlayerAudio>().stopFootstepSound();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) {
                Jump();
            } else {
                DoubleJump();
            }
        }

        playerAnimator.SetBool("Run", horizontalInput != 0);
        playerAnimator.SetBool("isGrounded", isGrounded);
    }

    private void Jump()
    {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerJumpHeight);
        isGrounded = false;
        playerAudio.GetComponent<PlayerAudio>().playJumpSound();
    }

    private void DoubleJump()
    {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerJumpHeight / 0.5f);
        isGrounded = false;
        playerAudio.GetComponent<PlayerAudio>().playDoubleJumpSound();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public Rigidbody2D GetPlayerRigidBody2D()
    {
        return playerRigidBody;
    }
}
