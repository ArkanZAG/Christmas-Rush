using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private Animator playerAnimator;
    private bool dead;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void TakingDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        
        currentHealth = currentHealth - damage;

        if (currentHealth > 0)
        {
            playerAnimator.SetTrigger("Damaged");
        }
        else
        {
            if (!dead)
            {
                playerAnimator.SetTrigger("Dead");
                GetComponent<PlayerMechanic>().enabled = false; 
                dead = true;
            }
        }
    }
}
