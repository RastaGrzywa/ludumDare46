using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsManager : MonoBehaviour
{
    public GameObject workersPanel;
    public GameObject UpgradesPanel;

    private bool workersShowed = false;
    private bool upgradesShowed = false;

    public void HandleWorkersPanelButton()
    {
        if (workersShowed)
        {
            workersPanel.transform.position = new Vector2(workersPanel.transform.position.x, workersPanel.transform.position.y - 100);
        }
        else
        {
            workersPanel.transform.position = new Vector2(workersPanel.transform.position.x, workersPanel.transform.position.y + 100);
        }

        workersShowed = !workersShowed;
    }
    public void HandleUpgradesPanelButton()
    {
        if (upgradesShowed)
        {
            UpgradesPanel.transform.position = new Vector2(UpgradesPanel.transform.position.x + 185, UpgradesPanel.transform.position.y);
        }
        else
        {
            UpgradesPanel.transform.position = new Vector2(UpgradesPanel.transform.position.x - 185, UpgradesPanel.transform.position.y);
        }

        upgradesShowed = !upgradesShowed;
    }
}
