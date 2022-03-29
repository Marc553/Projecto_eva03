using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed = 20f;
    public float rotation = 20f;


    void Update()
    {
        float verticalInput = Input.GetAxis("Verticalmov"); 
        float horizontalInput = Input.GetAxis("Horizontalmov");

        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Rotate(transform.up * rotation * Time.deltaTime * horizontalInput);
    }
}
