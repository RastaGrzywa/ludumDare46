using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkersManager : MonoBehaviour
{
    public WorkersController workersController;

    public Text nextLvlCostText;
    public Text nextLvlPowerText;
    public Text currentLvlText;
    public Text currentPowerText;

    public void UpdateWorkersUI()
    {
        nextLvlCostText.text = "Price:\n" + workersController.nextLvlPrice.ToString();
        nextLvlPowerText.text = "Power:\n" + workersController.nextClickPower.ToString();
        currentLvlText.text = workersController.currentLvl.ToString();
        currentPowerText.text = workersController.clickPower.ToString();
    }
}
