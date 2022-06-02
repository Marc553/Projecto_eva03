using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody playerBody;

    private Animator playerAnimator;


    private void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float verticalInputmov = Input.GetAxis("Verticalmov"); 
        float horizontalInputmov = Input.GetAxis("Horizontalmov");

        playerBody.AddForce(transform.forward * speed * verticalInputmov);
        playerBody.AddForce(transform.right * speed * horizontalInputmov);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("Atacar");
        }

    }

}
