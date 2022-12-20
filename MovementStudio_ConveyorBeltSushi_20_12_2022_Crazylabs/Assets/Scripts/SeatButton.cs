using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeatButton : MonoBehaviour
{
    public TextMeshProUGUI seatButtonCost;
    public MoneyManager moneyManager;
    public UpgradeManager upgradeManager;

    private int[] costLevels = { 0, 0, 0, 0, 100, 300, 600, 1000, 1500, 2100, 2800, 3600, 4500, 5500, 6600, 7800, 9100, 10500, 12000, 13600, 15300, 17100, 19000, 21000 };
    private int currentLevel = 3;
    private int maxLevel = 23;

    // Start is called before the first frame update
    void Start()
    {
        updateButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (moneyManager.getMoney() > costLevels[currentLevel+1])
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
        if (currentLevel < maxLevel && moneyManager.getMoney() > costLevels[currentLevel + 1])
        {
            currentLevel++;
            upgradeManager.setSeatLevel(currentLevel);
            moneyManager.addMoney(-costLevels[currentLevel]);
            updateButton();
        }
    }

    //updates the display of the button
    public void updateButton()
    {
        if (currentLevel == maxLevel)
        {
            seatButtonCost.text = "MAX";
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            seatButtonCost.text = costLevels[currentLevel + 1].ToString();
        }

    }
}