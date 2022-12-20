using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    public void SwitchToCamera1()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    public void SwitchToCamera2()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
    }
}
