using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject visual;
    [SerializeField] private InGameMenu inGameMenu;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            inGameMenu.AddValueToCounter(1);
            visual.SetActive(false);
        }
    }
}
