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

    private void Start()
    {
        gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(LoadMainMenuScreen);
    }

    public void ShowVictoryScreen()
    {
        Debug.Log("TEST");
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
