using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
    private float distanciaRayo = 1000;

    private void Update()
    {
       
    }

    private bool IsPlayerOnSight()
    {
        // Informaci�n del hit del Raycast
        RaycastHit hitData;

        // Ray desde la posici�n del canon en direcci�n hacia adelante
        Ray ray = new Ray(transform.position,transform.forward);

        // RAYCAST VISUAL EN LA SCENE DE UNITY
        Debug.DrawRay(transform.position, transform.forward * distanciaRayo, Color.yellow);

        // Si Physics.Raycast con la distancia devuelve True
        if (Physics.Raycast(ray, out hitData, distanciaRayo))
        {
            
            // Devuelve True or False dependiendo de si est� tocando Player
            return hitData.collider.CompareTag("Player");
        }
        else
        {
            // Devuelve False
            return false;
        }
    }
}
