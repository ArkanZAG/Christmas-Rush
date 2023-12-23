using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button exitGameButton;
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private String inGameScene = "SampleScene";

    private void Start()
    {
        startGameButton.onClick.AddListener(LoadInGameScene);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    public void LoadInGameScene()
    {
        Debug.Log("Change Scene!");
        SceneManager.LoadScene(inGameScene);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public GameObject GetMainMenuScreen()
    {
        return mainMenuScreen;
    }
}
