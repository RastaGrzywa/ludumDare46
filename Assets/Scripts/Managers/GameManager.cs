using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public WorkersManager workersManager;
    public WorkersController workersController;
    public ResourceManager resourceManager;
    public UpgradesManager upgradesManager;
    public CubesGenerator cubesGenerator;
    
    public GameObject cubePrefab;
    public GameObject welcomeScreen;
    public GameObject lostScreen;
    public GameObject wonScreen;
    public GameObject backDrop;


    public void StartGame()
    {
        upgradesManager.ResetValues();

        playerManager.ResetValues();
        workersController.ResetValues();
        cubesGenerator.ResetValues();
        GameObject cube = Instantiate(cubePrefab);
        welcomeScreen.SetActive(false);
        backDrop.SetActive(false);
        lostScreen.SetActive(false);
        resourceManager.UpdateResourcesUI();
        resourceManager.UpdateHealthBar();

    }

    public void RestartGame()
    {
        playerManager.ResetValues();
        workersController.ResetValues();
        cubesGenerator.ResetValues();
        welcomeScreen.SetActive(false);
        lostScreen.SetActive(false);
        backDrop.SetActive(false);
        GameObject cube = Instantiate(cubePrefab);
        cubesGenerator.ResetValues();
        resourceManager.UpdateResourcesUI();
        resourceManager.UpdateHealthBar();
    }

    internal void ShowEndScreen()
    {
        lostScreen.SetActive(true);
        backDrop.SetActive(true);
    }
    internal void ShowWinnerScreen()
    {
        wonScreen.SetActive(true);
        backDrop.SetActive(true);
    }
}
