using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button exitGameButton;
    [SerializeField] private GameObject mainMenuScreen;

    private void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        mainMenuScreen.SetActive(false);
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
