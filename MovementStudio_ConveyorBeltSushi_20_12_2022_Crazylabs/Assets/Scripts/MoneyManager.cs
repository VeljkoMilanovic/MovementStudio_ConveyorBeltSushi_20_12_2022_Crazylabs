using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private int money = 0;

    public int getMoney()
    {
        return money;
    }

    public void addMoney(int x)
    {
        money += x;
        updateText();
    }

    public void debugAddMoney()
    {
        money += 1000000;
        updateText();
    }

    //updates text display
    public void updateText()
    {
        if(money < 1000)
        {
            moneyText.text = money.ToString(new CultureInfo("en-US"));
        }
        else if(money < 1000000)
        {
            moneyText.text = ((float)money/1000).ToString("0.0", new CultureInfo("en-US")) + "K";
        }
        else
        {
            moneyText.text = ((float)money/1000000).ToString("0.0", new CultureInfo("en-US")) + "M";
        }
    }
}
