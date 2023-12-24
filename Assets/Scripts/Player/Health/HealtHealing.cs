using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Health
{
    public class HealtHealing : MonoBehaviour
    {
        [SerializeField] private int healthValue;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private GameObject visual;
        [SerializeField] private Collider2D boxCollider;

        private void OnTriggerEnter2D(Collider2D col)
        {
            PlayerMechanic player = col.gameObject.GetComponent<PlayerMechanic>();
            if (player == null) return;
            
            HealthComponent playerHealth = col.gameObject.GetComponent<HealthComponent>();
            if (playerHealth == null) return;
            
            if (!playerHealth.CanHeal()) return;
            audioSource.clip = audioClip;
            audioSource.Play();
            playerHealth.Healing(healthValue);
            visual.SetActive(false);
            boxCollider.enabled = false;
        }
    }
}