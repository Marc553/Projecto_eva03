using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_sistem : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
