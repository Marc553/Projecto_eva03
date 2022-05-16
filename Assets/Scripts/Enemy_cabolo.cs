using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_cabolo : MonoBehaviour
{

    private Rigidbody enemyRigidbody;
    private GameObject player;
    [SerializeField] private float speed = 5f;
    

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {
        

    }

    private bool VisionPlayer()
    {
        Vector3 ray = transform.position;

        float marcaRasho = 10000;

        /*Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * marcaRasho, Color.yellow);

        RaycastHit infoHit;

        if (Physics.Raycast(ray, out infoHit, marcaRasho))
        {
            return 
        }*/

        Physics.Raycast(ray, transform.forward, out RaycastHit infoHit, marcaRasho);

        Color raycastColor = infoHit.collider != null ? Color.green : Color.black;

        Debug.DrawRay(ray, Vector3.forward * marcaRasho, raycastColor, 0, false);
        return infoHit.collider != null; 
    }

}   

