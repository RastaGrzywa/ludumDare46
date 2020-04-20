using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkersController : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameFactors gameFactors;
    public ResourceManager resourceManager;
    public WorkersManager workersManager;
    public UpgradesManager upgradesManager;

    public WorkersSpawnerController workersSpawnerController;

    public float currentLvl;
    private float basePrice = 100;
    public float nextLvlPrice;
    private float baseClickPower = 11f;
    public float clickPower;
    public float nextClickPower;

    public List<GameObject> workersObjects = new List<GameObject>();

    public void ResetValues()
    {
        nextLvlPrice = basePrice;
        nextClickPower = baseClickPower;
        clickPower = nextClickPower;
        currentLvl = 0;
        workersManager.UpdateWorkersUI();
        Invoke("Work", upgradesManager.workerSpeed);
    }

    void Start()
    {
        nextLvlPrice = basePrice;
        nextClickPower = baseClickPower;
        workersManager.UpdateWorkersUI();
        Invoke("Work", upgradesManager.workerSpeed);
    }

    private void Work()
    {
        Invoke("Work", upgradesManager.workerSpeed);
        if (currentLvl == 0) return;

        playerManager.cubesCurrentHealth += clickPower;
        if (playerManager.cubesCurrentHealth > playerManager.cubesMaxHealth)
            playerManager.cubesCurrentHealth = playerManager.cubesMaxHealth;

        resourceManager.UpdateHealthBar();
        resourceManager.AddHealthPoints(clickPower);
        playerManager.LevelUp();
    }

    public void BuyWorker()
    {
        if (playerManager.totalHealthPoints < nextLvlPrice)
        {
            return;
        }
        currentLvl++;
        playerManager.totalHealthPoints -= nextLvlPrice;
        clickPower = nextClickPower;
        nextLvlPrice = basePrice * Mathf.Pow(gameFactors.workerPrice, currentLvl + 1);
        nextLvlPrice *= upgradesManager.workerPrice;
        nextClickPower = (currentLvl + 1) * baseClickPower * gameFactors.workerJob;
        GameObject worker = workersSpawnerController.SpawnWorker();
        workersObjects.Add(worker);
        resourceManager.UpdateResourcesUI();
        workersManager.UpdateWorkersUI();
    }

    public void StopWorking()
    {
        CancelInvoke("Work");
        foreach (var item in workersObjects)
        {
            Destroy(item);
        }
        workersObjects.Clear();

    }

}
