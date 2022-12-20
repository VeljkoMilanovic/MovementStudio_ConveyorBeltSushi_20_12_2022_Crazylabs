using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public QualityButton qualityButton;
    public GameObject referencePosition;
    public GameObject customerFemale;
    public GameObject customerMale;

    private int sushiLevel = 0;
    private int seatLevel = 3;
    private int qualityLevel = 0;

    public int[] probability = new int[5];
    public int[] ranges = new int[5];

    private int[] seats = { 17, 7, 18, 22, 20, 3, 24, 2, 11, 12, 13, 9, 15, 8, 10, 19, 23, 14, 1, 21, 5, 4, 16, 6 };//seat positions
    private int[] customers = { 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1 };//customer genders
    private float angleIncrement = 15.0f;
    private Vector3 rotationCenter = new Vector3(0, 0, 0);
    private Vector3 rotationAxis = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        calculateProbability();

        //spawn initial customers
        for (int i = 0; i <= seatLevel; i++)
        {
            spawnSeat(i);
        }
        
    }

    //returns a random sushi type based on weighted probability
    public int getSushiType()
    {
        int random = Random.Range(1, ranges[sushiLevel]);
        for (int i = 0; i < 5; i++)
        {
            if (random <= ranges[i])
            {
                return i;
            }
        }
        return 0;
    }

    //calculate probability for spawning each type of sushi available based on upgrade levels
    public void calculateProbability()
    {
        for (int i = 0; i < 5; i++)
        {
            probability[i] = 4;
        }

        for (int i = 0; i < qualityLevel; i++)
        {
            probability[(int)Mathf.Floor(i / 4.0f)]--;
        }

        ranges[0] = probability[0];
        for (int i = 1; i < 5; i++)
        {
            ranges[i] = ranges[i-1]+probability[i];
        }
    }

    //spawn a customer
    public void spawnSeat(int i)
    {
        if (customers[i] == 0)
        {
            GameObject temp = Instantiate(customerFemale, referencePosition.transform);
            temp.transform.RotateAround(rotationCenter, rotationAxis, angleIncrement * seats[i]);
        }
        else
        {
            GameObject temp = Instantiate(customerMale, referencePosition.transform);
            temp.transform.RotateAround(rotationCenter, rotationAxis, angleIncrement * seats[i]);
        }
    }

    public void setSushiLevel(int x)
    {
        sushiLevel = x;
        calculateProbability();
        qualityButton.updateButton();
    }

    public void setSeatLevel(int x)
    {
        seatLevel = x;
        spawnSeat(seatLevel);
    }

    public void setQualityLevel(int x)
    {
        qualityLevel = x;
        calculateProbability();
    }

    public int getSushiLevel()
    {
        return sushiLevel;
    }

    public int getSeatLevel()
    {
        return seatLevel;
    }

    public int getQualityLevel()
    {
        return qualityLevel;
    }
}
