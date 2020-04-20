using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{

    public PlayerManager playerManager;

    public Text earnedHealthPointsText;
    public Text earnedHealthCoinsText;
    public Text currentLvLText;

    public Text pointsToNextLvLText;

    public Text cubesHealth;
    public Image cubesHealthBar;

    private float healthBarWidth;
    private float startRightOffset;

    private void Start()
    {
        UpdateResourcesUI();
        RectTransform rt = cubesHealthBar.GetComponent<RectTransform>();
        healthBarWidth = rt.rect.width;
        startRightOffset = rt.offsetMax.x;
    }

    public void UpdateResourcesUI()
    {
        earnedHealthPointsText.text = playerManager.totalHealthPoints.ToString("F0");
        earnedHealthCoinsText.text = playerManager.totalHealthCoins.ToString("F0");
        currentLvLText.text = playerManager.currentLvl.ToString();
        pointsToNextLvLText.text = playerManager.nextLvlNeededPoints.ToString("F0");
    }

    public void AddHealthPoints(float pointsToAdd)
    {
        playerManager.totalHealthPoints += pointsToAdd;
        UpdateResourcesUI();
    }
    public void AddHealthCoins(float coinsToAdd)
    {
        playerManager.totalHealthCoins += coinsToAdd;
        UpdateResourcesUI();
    }

    public void UpdateHealthBar()
    {
        float factor = playerManager.cubesCurrentHealth / playerManager.cubesMaxHealth;
        RectTransform rt = cubesHealthBar.GetComponent<RectTransform>();
        float right = healthBarWidth * factor;
        rt.offsetMax = new Vector2(right, rt.offsetMax.y);
        cubesHealth.text = playerManager.cubesCurrentHealth.ToString("F1");

        //float factor = playerManager.cubesCurrentHealth / playerManager.cubesMaxHealth;
        //RectTransform rt = cubesHealthBar.GetComponent<RectTransform>();
        //float right = healthBarWidth - (healthBarWidth * factor);
        //rt.offsetMax = new Vector2(startRightOffset - right, rt.offsetMax.y);
        //cubesHealth.text = playerManager.cubesCurrentHealth.ToString("F1");
    }


}
