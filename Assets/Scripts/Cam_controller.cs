using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_controller : MonoBehaviour
{
    public float xRotation;
    public GameObject playerBody;
    public float speed = 100f;

    private void Start()
    {
        playerBody = GameObject.Find("Player");
    }
    void Update()
    {
       float mouseX = Input.GetAxis("Horizontalcam") * speed * Time.deltaTime;
       float mouseY = Input.GetAxis("Verticalcam") * speed * Time.deltaTime;
       
       xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

       playerBody.transform.Rotate(Vector3.up * mouseX);
     
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
