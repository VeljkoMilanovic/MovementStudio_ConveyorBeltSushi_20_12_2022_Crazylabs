using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject plate;
    float Timer = 0;
    public float TimerMax = 2.0f;
    public Transform assignParent;
    public int count;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Timer += 0.5f;
        }

        if (Timer >= TimerMax && count <= 0)
        {
            (Instantiate(plate, transform.position, transform.rotation) as GameObject).transform.parent = assignParent.transform;
            Timer = Timer % TimerMax;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plate")
        {
            count++;
            other.GetComponent<WoodenPlate>().setOverlapping(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Plate")
        {
            count--;
            other.GetComponent<WoodenPlate>().setOverlapping(false);
        }
    }

    public void decreaseCount()
    {
        count--;
    }

}
