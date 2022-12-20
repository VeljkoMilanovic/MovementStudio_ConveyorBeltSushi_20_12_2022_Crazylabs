using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public SpawnManager spawnManager;

    private Animator anim;
    private BoxCollider[] colliders;
    private bool isEating = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        colliders = GetComponents<BoxCollider>();
    }

    //detects a plate and starts eating
    private void OnTriggerEnter(Collider other)
    {
        if (!isEating && colliders != null && other.gameObject.tag == "Plate")
        {
            isEating = true;
            other.gameObject.GetComponent<WoodenPlate>().setCustomer(this);
            other.transform.position = transform.TransformPoint(colliders[1].center);
            other.transform.SetParent(null, true);
            Destroy(other.attachedRigidbody);
            other.gameObject.GetComponent<WoodenPlate>().Invoke("checkSpawner", 0.1f);
            other.gameObject.GetComponent<WoodenPlate>().StartCoroutine("eating");
            anim.SetBool("IsEating", true);
        }
    }

    public void setIsEating(bool isEating)
    {
        this.isEating = isEating;
        anim.SetBool("IsEating", isEating);
    }
}
