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
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject inGameMenuGameObject;
    [SerializeField] private String mainMenuScene = "MainMenu";
    [SerializeField] private TextMeshProUGUI counterText;

    private void Start()
    {
        sideMenuButton.onClick.AddListener(ShowSideMenuScreen);
        menuButton.onClick.AddListener(MainMenuScene);
        closeButton.onClick.AddListener(CloseSideMenuScreen);
        restartButton.onClick.AddListener(RestratButton);
    }

    private void ShowSideMenuScreen()
    {
        inGameMenuGameObject.SetActive(true);
        GetComponent<PlayerMechanic>().enabled = false;
    }

    private void CloseSideMenuScreen()
    {
        inGameMenuGameObject.SetActive(false);
        GetComponent<PlayerMechanic>().enabled = true;
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
