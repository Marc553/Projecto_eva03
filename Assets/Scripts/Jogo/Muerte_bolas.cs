using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte_bolas : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("mapa") || other.gameObject.CompareTag("espada"))
        {
            Destroy(gameObject);
        }
    }
}
