using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        float verticalInputmov = Input.GetAxis("Verticalmov"); 
        float horizontalInputmov = Input.GetAxis("Horizontalmov");

        transform.Translate(Vector3.forward * speed * verticalInputmov * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInputmov * Time.deltaTime);
    }
}
