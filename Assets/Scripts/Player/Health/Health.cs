using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private int numberofFlashes;
    [SerializeField] private int iFramesDuration;
    [SerializeField] private float currentHealth;
    [SerializeField] private GameOverScreen gameOverScreen;
    private SpriteRenderer spriteRend;
    private bool dead;
    public GameObject playerAudio;
    

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakingDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        playerAudio.GetComponent<PlayerAudio>().playDamageSound();

        if (currentHealth > 0)
        {
            playerAnimator.SetTrigger("Damaged");
        }
        else if (currentHealth == 0)
        {
            if (!dead)
            {
                playerAnimator.SetTrigger("Dead");
                GetComponent<PlayerMechanic>().enabled = false;
                gameOverScreen.ShowGameOverScreen();
                dead = true;
                playerAudio.GetComponent<PlayerAudio>().playDeathSound();
            }
        }
    }

    public void Healing(int value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    public float GetMaxHealth()
    {
        return startingHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6,7,true);
    
        for (int i = 0; i < numberofFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0);
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
        }
        
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
