using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Collectible;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject visual;
    [SerializeField] private Collider2D boxCollider;
    [SerializeField] private ScoreController score;

    public void Initialize(ScoreController scoreController)
    {
        score = scoreController;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player") return;
        
        audioSource.clip = audioClip;
        audioSource.Play();
        score.AddScore(1);
        visual.SetActive(false);
        boxCollider.enabled = false;
    }
}
