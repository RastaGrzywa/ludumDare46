using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    private ResourceManager resourceManager;
    private PlayerManager playerManager;
    private GameFactors gameFactors;
    private UpgradesManager upgradesManager;
    private GameManager gameManager;

    private CubesGenerator cubesGenerator;
    

    public Canvas mainCanvas;
    public GameObject parentTextPrefab;


    private Animator animator;

    private float baseHalthLoseSpeed = 1;
    private float baseHealth = 100f;
    private float health;
    private float timeToNextLvl = 5;

    private float losingHealthSpeed = 1f;
    private float currentLvl = 0;

    private bool died = false;

    private List<GameObject> cubesToDie = new List<GameObject>();

    private void Start()
    {
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        gameFactors = GameObject.Find("GameFactors").GetComponent<GameFactors>();
        cubesGenerator = GameObject.Find("CubesGenerator").GetComponent<CubesGenerator>();
        upgradesManager = GameObject.Find("UpgradesManager").GetComponent<UpgradesManager>();
        mainCanvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        animator = GetComponent<Animator>();
        health = baseHealth;


        InvokeRepeating("LooseHealth", 1.0f, .01f);
        Invoke("CubeLvlUp", timeToNextLvl);
    }



    private void CubeLvlUp()
    {
        switch (currentLvl)
        {
            case 2: timeToNextLvl = 5; break;
            case 5: timeToNextLvl = 5; break;
            case 10: timeToNextLvl = 10; break;
            case 20: timeToNextLvl = 15; break;
            case 30: timeToNextLvl = 20; break;
            case 50: timeToNextLvl = 35; break;
            case 70: timeToNextLvl = 60; break;
            case 90: timeToNextLvl = 120; break;
            case 95: timeToNextLvl = 240; break;
            case 99: timeToNextLvl = 360; break;
        }

        currentLvl++;
        playerManager.cubesMaxHealth = baseHealth * currentLvl * gameFactors.cubeHealthRise;
        CalculateCubeVariables();
        cubesToDie.Add(cubesGenerator.GenerateCube());
        timeToNextLvl *= upgradesManager.cubeSpawnSpeed;
        Invoke("CubeLvlUp", timeToNextLvl);
    }

    private void CalculateCubeVariables()
    {
        health = baseHealth * currentLvl * gameFactors.cubeHealthRise;
        losingHealthSpeed = baseHalthLoseSpeed * Mathf.Pow(gameFactors.healthDrop, currentLvl);
    }
    
    private void LooseHealth()
    {
        playerManager.cubesCurrentHealth -= (losingHealthSpeed / 10) * upgradesManager.healthDrop;
        resourceManager.UpdateHealthBar();

        if (playerManager.cubesCurrentHealth <= 0)
        {
            playerManager.FinishGame();
            died = true;
            CancelInvoke("LooseHealth");
            CancelInvoke("CubeLvlUp");
            animator.SetBool("die", true);
            foreach (var item in cubesToDie)
            {
                item.GetComponent<GeneratedCubeController>().Die();
            }
        }
    }

    public void OnCubeDie()
    {
        Destroy(gameObject);
        gameManager.ShowEndScreen();
    }

    public void HandleClick()
    {
        if (died)
            return;


        playerManager.cubesCurrentHealth += playerManager.regenerationHealthClick;

        if (playerManager.cubesCurrentHealth > playerManager.cubesMaxHealth)
            playerManager.cubesCurrentHealth = playerManager.cubesMaxHealth;

        resourceManager.UpdateHealthBar();
        SpawnHealthText(playerManager.regenerationHealthClick);
        resourceManager.AddHealthPoints(playerManager.regenerationHealthClick);
        playerManager.LevelUp();

    }

    private void SpawnHealthText(float regenerationHealthAmount)
    {
        GameObject parentText = Instantiate(parentTextPrefab);
        parentText.transform.SetParent(mainCanvas.transform, false);
        parentText.transform.position = Input.mousePosition;
        parentText.GetComponentInChildren<Text>().text = regenerationHealthAmount.ToString();
    }
    private void SpawnLevelUpText(float regenerationHealthAmount)
    {
        GameObject parentText = Instantiate(parentTextPrefab);
        Vector2 screePosition = Camera.main.WorldToScreenPoint(transform.position + Vector3.up);
        parentText.transform.SetParent(mainCanvas.transform, false);
        parentText.transform.position = screePosition;
        parentText.GetComponentInChildren<Text>().text = regenerationHealthAmount.ToString();
    }
}
