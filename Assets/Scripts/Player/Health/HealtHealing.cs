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
        [SerializeField] private global::Health health;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            
            if (col.gameObject.tag == "Player" && health.currentHealth != health.GetMaxHealth())
            {
                Debug.Log("Audio will be play");
                audioSource.clip = audioClip;
                audioSource.Play();
                Debug.Log("Audio Played");
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