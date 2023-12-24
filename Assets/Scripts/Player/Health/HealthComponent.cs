using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private int numberofFlashes;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float currentHealth;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private SpriteRenderer spriteRend;
    private bool dead;
    private bool isInvulnerable = false;
    public GameObject playerAudio;
    

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakingDamage(int damage)
    {
        if (isInvulnerable) return;
        
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        playerAudio.GetComponent<PlayerAudio>().playDamageSound();

        if (currentHealth > 0)
        {
            playerAnimator.SetTrigger("Damaged");
            StartCoroutine(Invulnerability());
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

    public bool CanHeal()
    {
        return GetCurrentHealth() < GetMaxHealth();
    }

    private IEnumerator Invulnerability()
    {
        isInvulnerable = true;
    
        for (int i = 0; i < numberofFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0);
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
        }
        
        isInvulnerable = false;
    }
}
