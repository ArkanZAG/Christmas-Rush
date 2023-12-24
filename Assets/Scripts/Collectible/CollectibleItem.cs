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
    [SerializeField] private VictoryScreen victoryScreen;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            inGameMenu.AddValueToCounter(1);
            visual.SetActive(false);
            VictoryCondition();
            Collider2D coll = GetComponent<Collider2D>();

            if (coll != null)
            {
                coll.enabled = false;
            }
            
        }
    }
    
    public void VictoryCondition()
    {
        Debug.Log("Menang!");
        int counterValue = int.Parse(inGameMenu.GetCounterText().text);
        if (counterValue == 6)
        {
            victoryScreen.ShowVitoryScreen();
        }
        
    }
}
