using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class WoodenPlate : MonoBehaviour
{
    public GameObject[] sushiTypes;
    public UpgradeManager upgradeManager;
    public SpawnManager spawnManager;
    public MoneyManager moneyManager;
    public GameObject bilboard;

    private GameObject[] sushi = new GameObject[4];
    private int[] sushiPrice = { 2, 4, 6, 8, 10 };
    private int sushiType = 0;
    private Vector3 offset = new Vector3(0, 0.5f, 0);
    private Vector3 sushiScale = new Vector3(2,2,2);
    private bool overlapping = false;
    private Customer customer;

    // Start is called before the first frame update
    void Start()
    {
        //initialize variables
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        upgradeManager = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
        moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
        sushiType = upgradeManager.getSushiType();

        //spawn sushi on the plate
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();
        for(int i=0; i<4; i++)
        {
            sushi[i] = (GameObject)Instantiate(sushiTypes[sushiType], transforms[i + 1].position, transforms[i + 1].rotation);
            sushi[i].transform.localScale = sushiScale;
            sushi[i].transform.parent = gameObject.transform;
        }
    }

    public void checkSpawner()
    {
        if(overlapping)
        {
            spawnManager.decreaseCount();
        }
    }

    public void setOverlapping(bool x)
    {
        overlapping = x;
    }

    public void setCustomer(Customer customer)
    {
        this.customer = customer;
    }

    //Coroutine that destroys sushi  when a customer starts eating
    IEnumerator eating()
    {
        for(int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1.0f);
            GameObject temp = Instantiate(bilboard, sushi[i].transform.position + offset, Quaternion.identity);
            temp.GetComponent<Bilboard>().setPrice(sushiPrice[sushiType]);
            Destroy(sushi[i]);
            moneyManager.addMoney(sushiPrice[sushiType]);
        }
        customer.setIsEating(false);
        Destroy(this.gameObject);
    }
}
