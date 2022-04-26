using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed = 20f;
    public GameObject[] door;

    void Update()
    {
        float verticalInputmov = Input.GetAxis("Verticalmov"); 
        float horizontalInputmov = Input.GetAxis("Horizontalmov");

        transform.Translate(Vector3.forward * speed * verticalInputmov * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInputmov * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider roomDoor)
    {
        if (roomDoor.gameObject.CompareTag("entrada_sala1"))
        { 
            door[0].SetActive(true);
        }
        
        if (roomDoor.gameObject.CompareTag("entrada_sala2"))
        { 
            door[1].SetActive(true);
        }
        
        if (roomDoor.gameObject.CompareTag("entrada_sala3"))
        { 
            door[2].SetActive(true);
        }
        
        if (roomDoor.gameObject.CompareTag("entrada_sala4"))
        { 
            door[3].SetActive(true);
        }
    }
}
