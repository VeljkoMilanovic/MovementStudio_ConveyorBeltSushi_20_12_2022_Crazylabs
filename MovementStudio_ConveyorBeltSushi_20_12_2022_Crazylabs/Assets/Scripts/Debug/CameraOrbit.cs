using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 8.0f;

    private Vector3 previousPosition;

    //orbit camera
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally

            cam.transform.position = target.position;

            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
    }
}
