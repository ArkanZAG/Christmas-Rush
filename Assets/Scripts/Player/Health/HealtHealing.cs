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
        [SerializeField] private global::Health playerHealth;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player" && playerHealth.GetCurrentHealth() != playerHealth.GetMaxHealth())
            {
                audioSource.clip = audioClip;
                audioSource.Play();
                col.gameObject.GetComponent<global::Health>().Healing(healthValue);
                visual.SetActive(false);

                Collider2D coll = GetComponent<Collider2D>();

                if (coll != null)
                {
                    coll.enabled = false;
                }
            }
        }
    }
}