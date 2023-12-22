using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private Button sideMenuButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject inGameMenuGameObject;
    [SerializeField] private MainMenu mainMenu;

    private void Start()
    {
        sideMenuButton.onClick.AddListener(ShowSideMenuScree);
        menuButton.onClick.AddListener(MenuButton);
        restartButton.onClick.AddListener(RestratButton);
    }

    private void ShowSideMenuScree()
    {
        inGameMenuGameObject.SetActive(true);
    }

    private void RestratButton()
    {
        
    }

    private void MenuButton()
    {
        mainMenu.GetMainMenuScreen().SetActive(true);
    }
}
