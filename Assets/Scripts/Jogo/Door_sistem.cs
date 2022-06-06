using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_sistem : MonoBehaviour
{
    //entra dentro de su hijo(la puerta como tal) y le ordena activarse al detectar pasar al player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
