using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float Speed = 20.0f;
    public float MaxTimer = 4.0f;
    public float Timer = 0f;

    private Vector3 rotationVector = new Vector3(0, 0, -1);

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Timer = 0f;
            Speed = 40.0f;
        }

        if (Timer > MaxTimer)
        {
            Speed = 20.0f;
        }

        transform.Rotate(rotationVector * Speed * Time.deltaTime);
    }
}
