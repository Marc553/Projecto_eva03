using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_cotroller : MonoBehaviour
{
    private GameObject player;
    private float distanciaRayo = 1000;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.LookAt(player.transform.position);

        IsPlayerOnSight();
    }

    private bool IsPlayerOnSight()
    {
        // Información del hit del Raycast
        RaycastHit hitData;

        // Ray desde la posición del canon en dirección hacia adelante
        Ray ray = new Ray(transform.position, transform.forward);

        // RAYCAST VISUAL EN LA SCENE DE UNITY
        Debug.DrawRay(transform.position, transform.forward * distanciaRayo, Color.yellow);

        // Si Physics.Raycast con la distancia devuelve True
        if (Physics.Raycast(ray, out hitData, distanciaRayo))
        {

            // Devuelve True or False dependiendo de si está tocando Player
            return hitData.collider.CompareTag("Player");
        }
        else
        {
            // Devuelve False
            return false;
        }
    }
}
