using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    #region VARIABLES

    public float speed = 20f;
    private Rigidbody playerBody;
    private float vida = 1;

    private Animator playerAnimator;

    private Collider ataqueCollider;

    private float timeBetweenAttacks = 1;

    private bool canAttack = true;
    #endregion

    #region METODOS
    private void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        ataqueCollider = gameObject.transform.GetChild(2).GetComponent<Collider>();
    }

    void Update()
    {
        float verticalInputmov = Input.GetAxis("Verticalmov"); 
        float horizontalInputmov = Input.GetAxis("Horizontalmov");

        playerBody.AddForce(transform.forward * speed * verticalInputmov);
        playerBody.AddForce(transform.right * speed * horizontalInputmov);

        //reaccion de la vida del personaje
        if (vida <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("Atacar");
        }
    }
#endregion

    #region FUNCIONES
    private void ActivarTrigger()
    {
        ataqueCollider.enabled = true;
    }

    private void DesactivarTrigger()
    {
        ataqueCollider.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cabolo"))
        {
            vida -= 0.5f;
        }

        if (collision.gameObject.CompareTag("Projectil"))
        {
            vida -= 1;
            
            Destroy(collision.gameObject);
        }
    }

    #endregion
}
