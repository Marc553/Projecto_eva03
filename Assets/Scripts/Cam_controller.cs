using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_controller : MonoBehaviour
{
    public float camSensibility = 20f;
    public float xRotation;

    void Update()
    {
        float camX = Input.GetAxis("Horizontalcam") * camSensibility * Time.deltaTime;
        float camY = Input.GetAxis("Verticalcam") * camSensibility * Time.deltaTime;

        xRotation -= camY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(transform.up * camX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
