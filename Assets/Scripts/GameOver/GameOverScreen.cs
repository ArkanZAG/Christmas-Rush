using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private string mainMenuScene = "MainMenu";
    [SerializeField] private string inGameScene = "SampleScene";

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(LoadMainMenuScreen);
    }

    public void ShowGameOverScreen()
    {
        Debug.Log("Dead");
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
