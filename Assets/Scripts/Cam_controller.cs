using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Controller : MonoBehaviour
{
    public float xRotation;
    public GameObject playerBody;

    private void Start()
    {
        playerBody = GameObject.Find("Main Cmera");
    }
    void Update()
    {
        float speed = 20f;
       float mouseX = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
       
       xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //playerBody.Rotate(Vector3.up * mouseX);
     
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
