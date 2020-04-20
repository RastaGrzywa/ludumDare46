using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public ResourceManager resourceManager;
    public WorkersManager workersManager;
    public WorkersController workersController;

    public Text doubleWorkerSpeedCostText;
    public Text increaseHealthCostText;
    public Text fasterSpawnCubeCostText;
    public Text lowerLvlUpCostText;
    public Text lowerHealthDropCostText;
    public Text workerPriceCostText;

    private float upgradesLvL = 0;
    private float upgradesCost = 100;

    public float workerSpeed = 1;
    public float cubeSpawnSpeed = 1;
    public float lvlUpCost = 1;
    public float workerPrice = 1;
    public float healthDrop = 1;

    public void ResetValues()
    {
        workerSpeed = 1;
        cubeSpawnSpeed = 1;
        lvlUpCost = 1;
        workerPrice = 1;
        healthDrop = 1;
        upgradesCost = 100;
        upgradesLvL = 0;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void Upgrade()
    {
        playerManager.totalHealthCoins -= upgradesCost;
        upgradesLvL++;
        upgradesCost += 100;
        UpdateUI();

        resourceManager.UpdateResourcesUI();
        workersManager.UpdateWorkersUI();
    }

    private void UpdateUI()
    {
        doubleWorkerSpeedCostText.text = upgradesCost.ToString();
        increaseHealthCostText.text = upgradesCost.ToString();
        fasterSpawnCubeCostText.text = upgradesCost.ToString();
        lowerLvlUpCostText.text = upgradesCost.ToString();
        lowerHealthDropCostText.text = upgradesCost.ToString();
        workerPriceCostText.text = upgradesCost.ToString();
    }

    public void BuyWorkerSpeed()
    {
        if (playerManager.totalHealthCoins < upgradesCost) return;
        workerSpeed *= .5f;
        if (workerSpeed < .1f) doubleWorkerSpeedCostText.transform.parent.transform.parent.GetComponent<Button>().interactable = false;
        Upgrade();
    }
    public void BuyCubeSpawnSpeed()
    {
        if (playerManager.totalHealthCoins < upgradesCost) return;
        cubeSpawnSpeed *= .8f;
        Upgrade();
    }
    public void BuyLvlUpCost()
    {
        if (playerManager.totalHealthCoins < upgradesCost) return;
        lvlUpCost *= .85f;
        playerManager.nextLvlNeededPoints *= lvlUpCost;
        if (lvlUpCost < .1f) lowerLvlUpCostText.transform.parent.transform.parent.GetComponent<Button>().interactable = false;
        Upgrade();
    }
    public void BuyWorkerPrice()
    {
        if (playerManager.totalHealthCoins < upgradesCost) return;
        workerPrice *= .9f;
        workersController.nextLvlPrice *= workerPrice;
        if (workerPrice < .1f) workerPriceCostText.transform.parent.transform.parent.GetComponent<Button>().interactable = false;
        Upgrade();
    }
    public void BuyHealthDrop()
    {
        if (playerManager.totalHealthCoins < upgradesCost) return;
        healthDrop *= .85f;
        Upgrade();
    }
    public void BuyHealth()
    {
        if (playerManager.totalHealthCoins < upgradesCost) return;
        playerManager.cubesMaxHealth += 1000;
        Upgrade();
    }
}
