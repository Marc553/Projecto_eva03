using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_canon : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
        Debug.Log(VisionPlayer());
    }


        private bool VisionPlayer()
        {
        Ray ray = new Ray(transform.position, transform.forward);

        float marcaRasho = 10000; 

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * marcaRasho, Color.yellow);

        RaycastHit infoHit;

        if (Physics.Raycast(ray, out infoHit, marcaRasho))
        {  
            
            return infoHit.collider.CompareTag("Player");
        }
        else
        {
            return false;
        }
        }
    }