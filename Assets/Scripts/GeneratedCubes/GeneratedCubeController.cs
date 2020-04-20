using UnityEngine;

public class GeneratedCubeController : MonoBehaviour
{
    private ResourceManager resourceManager;
    private PlayerManager playerManager;
    private Animator animator;

    private bool died = false;

    private void Start()
    {
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
    }

    public void Die()
    {
        died = true;
        CancelInvoke("LooseHealth");
        animator.SetBool("die", true);
    }


    public void OnCubeDie()
    {
        Destroy(gameObject);
    }

    public void HandleClick()
    {
        if (died)
            return;

        playerManager.cubesCurrentHealth += playerManager.regenerationHealthClick;

        if (playerManager.cubesCurrentHealth > playerManager.cubesMaxHealth)
            playerManager.cubesCurrentHealth = playerManager.cubesMaxHealth;

        resourceManager.UpdateHealthBar();
        resourceManager.AddHealthPoints(playerManager.regenerationHealthClick);
    }

}
