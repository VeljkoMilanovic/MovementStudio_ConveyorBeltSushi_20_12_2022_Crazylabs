using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SushiButton : MonoBehaviour
{
    public TextMeshProUGUI sushiButtonCost;
    public MoneyManager moneyManager;
    public UpgradeManager upgradeManager;

    private int[] costLevels = { 0, 100, 300, 600, 1000 };
    private int currentLevel = 0;
    private int maxLevel = 4;

    // Start is called before the first frame update
    void Start()
    {
        updateButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel < maxLevel && moneyManager.getMoney() > costLevels[currentLevel + 1])
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    //purchase an upgrade when the button is clicked
    public void purchase()
    {
        if (moneyManager.getMoney() > costLevels[currentLevel + 1])
        {
            currentLevel++;
            upgradeManager.setSushiLevel(currentLevel);
            moneyManager.addMoney(-costLevels[currentLevel]);
            updateButton();
        }
    }

    //updates the display of the button
    public void updateButton()
    {
        if (currentLevel == maxLevel)
        {
            sushiButtonCost.text = "MAX";
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            sushiButtonCost.text = costLevels[currentLevel + 1].ToString();
        }

    }
}