using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte_bolas : MonoBehaviour
{
    //para que lasd particulas se destrullan al no chocar con el player
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("mapa") || other.gameObject.CompareTag("espada"))
        {
            Destroy(gameObject);
        }
    }
}
