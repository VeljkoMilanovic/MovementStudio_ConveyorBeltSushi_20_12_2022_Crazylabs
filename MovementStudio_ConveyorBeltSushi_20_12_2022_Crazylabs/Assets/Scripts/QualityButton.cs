using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QualityButton : MonoBehaviour
{
    public TextMeshProUGUI qualityButtonCost;
    public MoneyManager moneyManager;
    public UpgradeManager upgradeManager;

    private int[] costLevels = { 0, 100, 250, 350, 500, 700, 950, 1250, 1600, 2000, 2450, 2950, 3500, 4100, 4750, 5450, 6200 };
    private int currentLevel = 0;
    private int maxLevel = 16;
    private int sushiLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel < maxLevel && currentLevel < sushiLevel * 4 && moneyManager.getMoney() > costLevels[currentLevel + 1])
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
            upgradeManager.setQualityLevel(currentLevel);
            moneyManager.addMoney(-costLevels[currentLevel]);
            updateButton();
        }
    }

    //updates the display of the button
    public void updateButton()
    {
        sushiLevel = upgradeManager.getSushiLevel();
        
        if (currentLevel == maxLevel)
        {
            qualityButtonCost.text = "MAX";
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (currentLevel >= sushiLevel * 4)
        {
            qualityButtonCost.text = "LOCKED";
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            qualityButtonCost.text = costLevels[currentLevel + 1].ToString();
            gameObject.GetComponent<Button>().interactable = true;
        }

    }
}