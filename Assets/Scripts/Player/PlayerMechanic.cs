using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private int playerMoveSpeed;
    [SerializeField] private int playerJumpHeight;
    [SerializeField] private Animator playerAnimator;
    void Start()
    {
        
    }
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        playerRigidBody.velocity = new Vector2(horizontalInput * playerMoveSpeed, playerRigidBody.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.velocity =
                new Vector2(playerRigidBody.velocity.x, playerJumpHeight);
        }
        
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        playerAnimator.SetBool("Run", horizontalInput != 0);
    }
}
