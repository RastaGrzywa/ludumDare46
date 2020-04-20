using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public WorkersController workersController;
    public GameFactors gameFactors;
    public UpgradesManager upgradesManager;
    public GameManager gameManager;

    public float totalHealthPoints;
    public float totalHealthCoins;
    public float currentLvl;

    public float cubesMaxHealth = 100;
    public float cubesCurrentHealth;
    public float regenerationHealthClick = 10f;
    public float baseRegenerationHealthClick = 10f;

    public float nextLvlNeededPoints;
    public float baseLvlNeededPoints = 100;

    public bool gameOver = false;

    public void ResetValues()
    {
        currentLvl = 0;
        totalHealthCoins = 0;
        totalHealthPoints = 0;
        baseRegenerationHealthClick = 10f;
        regenerationHealthClick = 10f;
        cubesMaxHealth = 100;
        cubesCurrentHealth = cubesMaxHealth;
        nextLvlNeededPoints = baseLvlNeededPoints;
    }

    private void Awake()
    {
        cubesCurrentHealth = cubesMaxHealth;
        nextLvlNeededPoints = baseLvlNeededPoints;
    }

    public void LevelUp()
    {
        if (totalHealthPoints < nextLvlNeededPoints) return;

        currentLvl++;
        regenerationHealthClick = baseRegenerationHealthClick * currentLvl * gameFactors.clickFactor;
        nextLvlNeededPoints = baseLvlNeededPoints * Mathf.Pow(gameFactors.playerLvlUpNeededPoints, currentLvl + 1);
        nextLvlNeededPoints *= upgradesManager.lvlUpCost;
        AddCoins();
        if (currentLvl == 100)
        {
            gameManager.ShowWinnerScreen();
        }
    }

    private void AddCoins()
    {
        if (currentLvl < 10)
        {
            totalHealthCoins += 10;
            return;
        }
        if (currentLvl < 15)
        {
            totalHealthCoins += 20;
            return;
        }
        if (currentLvl < 20)
        {
            totalHealthCoins += 25;
            return;
        }
        if (currentLvl < 25)
        {
            totalHealthCoins += 35;
            return;
        }
        if (currentLvl < 30)
        {
            totalHealthCoins += 50;
            return;
        }
        if (currentLvl < 35)
        {
            totalHealthCoins += 100;
            return;
        }
        if (currentLvl < 40)
        {
            totalHealthCoins += 250;
            return;
        }
        if (currentLvl < 50)
        {
            totalHealthCoins += 500;
            return;
        }
        if (currentLvl < 60)
        {
            totalHealthCoins += 1000;
            return;
        }
        if (currentLvl < 75)
        {
            totalHealthCoins += 4000;
            return;
        }
        if (currentLvl < 86)
        {
            totalHealthCoins += 10000;
            return;
        }
        if (currentLvl < 90)
        {
            totalHealthCoins += 20000;
            return;
        }
        if (currentLvl < 96)
        {
            totalHealthCoins += 50000;
            return;
        }
        if (currentLvl < 100)
        {
            totalHealthCoins += 100000;
            return;
        }
        totalHealthCoins += 1000000;
    }

    public void FinishGame()
    {
        gameOver = true;
        workersController.StopWorking();
    }
}
