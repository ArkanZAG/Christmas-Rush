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
    public PlayerAudio playerAudio;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        playerRigidBody.velocity = new Vector2(horizontalInput * playerMoveSpeed, playerRigidBody.velocity.y);
        /*isWalking = false;
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
        }*/

        isWalking = Mathf.Abs(horizontalInput) > 0f;
        if (isWalking)
        {
            float direction = horizontalInput > 0f ? 1f : -1f;

            transform.localScale = new Vector3(direction, 1f, 1f);
            if (!playerAudio.FootstepSound.isPlaying && isGrounded) {
                playerAudio.playFootstepSound();
            }
        }
        else
        {
            playerAudio.stopFootstepSound();
        }

        /*if (!isWalking) {
            playerAudio.GetComponent<PlayerAudio>().stopFootstepSound();
        }*/
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCounter++;
            if (jumpCounter == 1) {
                Jump();
            } else if (jumpCounter == 2) {
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
        playerAudio.playJumpSound();
    }

    private void DoubleJump()
    {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerJumpHeight / 0.5f);
        isGrounded = false;
        playerAudio.playDoubleJumpSound();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            var platformY = col.transform.position.y;
            var playerY = transform.position.y;
            if (playerY < platformY) return;
            isGrounded = true;
            jumpCounter = 0;
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
