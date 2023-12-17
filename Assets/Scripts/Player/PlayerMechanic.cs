using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private int playerMoveSpeed;
    [SerializeField] private int playerJumpHeight;
    void Start()
    {
        
    }
    
    void Update()
    {
        playerRigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * playerMoveSpeed, playerRigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.velocity =
                new Vector2(playerRigidBody.velocity.x, playerJumpHeight);
        }
    }
}
