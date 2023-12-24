using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private string mainMenuScene = "MainMenu";
    [SerializeField] private string inGameScene = "SampleScene";
    [SerializeField] private InGameMenu inGameMenu;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(LoadMainMenuScreen);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            VictoryCondition();
        }
    }

    // public void VictoryCondition()
    // {
    //     Debug.Log("Menang!");
    //     int counterValue = int.Parse(inGameMenu.GetCounterText().text);
    //     if (counterValue == 6)
    //     {
    //         ShowVitoryScreen();
    //     }
    //     
    // }
    
    public void VictoryCondition()
    {
        Debug.Log("Menang!");
        TextMeshProUGUI counter = inGameMenu.GetCounterText();
        int counterValue;
        if (int.TryParse(counter.text, out counterValue))
        {
            if (counterValue == 6)
            {
                ShowVitoryScreen();
            }
        }
        
    }

    public void ShowVitoryScreen()
    {
        gameObject.SetActive(true);
    }

    private void LoadMainMenuScreen()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(inGameScene);
    }
}
