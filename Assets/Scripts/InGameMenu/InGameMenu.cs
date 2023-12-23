using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private Button sideMenuButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject inGameMenuGameObject;
    [SerializeField] private String mainMenuScene = "MainMenu";
    [SerializeField] private TextMeshProUGUI counterText;

    private void Start()
    {
        sideMenuButton.onClick.AddListener(ShowSideMenuScreen);
        menuButton.onClick.AddListener(MainMenuScene);
        restartButton.onClick.AddListener(RestratButton);
    }

    private void ShowSideMenuScreen()
    {
        inGameMenuGameObject.SetActive(true);
    }

    private void MainMenuScene()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    private void RestratButton()
    {
        
    }
    
    public void AddValueToCounter(int score)
    {
        int currentValue = int.Parse(counterText.text);
        currentValue = currentValue + score;
        counterText.text = currentValue.ToString();
    }
}
