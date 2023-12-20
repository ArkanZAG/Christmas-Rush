using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyPlatform : MonoBehaviour
{
    [SerializeField] private PlayerMechanic playerMechanic;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private float slipperySpeed;


    private void Start()
    {
        playerRigidBody = playerMechanic.GetPlayerRigidBody2D();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            Debug.Log("Licin boyz");
            Debug.Log(playerRigidBody.velocity);
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x * slipperySpeed, playerRigidBody.velocity.y);
        }
    }
}
