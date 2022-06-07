using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    #region VARIABLES
    
    //variables del player
    public float speed = 20f;
    private Rigidbody playerBody;
    private float vida = 20;

    //animacion ataque 
    private Animator playerAnimator;

    private Collider ataqueCollider;

    private Game_Manager scriptGame;


    #endregion

    #region METODOS
    private void Start()
    { 
        //conecto las variables con sus respectivos elementos
        playerBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        ataqueCollider = gameObject.transform.GetChild(2).GetComponent<Collider>();//busco al hijo para entrar en su collider

        scriptGame = FindObjectOfType<Game_Manager>();
    }

    void Update()
    {
        //movimineto por fuerzas del player
        float verticalInputmov = Input.GetAxis("Verticalmov"); 
        float horizontalInputmov = Input.GetAxis("Horizontalmov");

        playerBody.AddForce(transform.forward * speed * verticalInputmov);
        playerBody.AddForce(transform.right * speed * horizontalInputmov);

        //reaccion de la vida del personaje
        if (vida <= 0)
        {
            Destroy(gameObject);
            scriptGame.GameOver();
        }

        //logica ataque(aqui solo invoco la aniamción al atacar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("Atacar");
            scriptGame.sonidoEfectos.PlayOneShot(scriptGame.efectoEnemigo);
        }
    }
#endregion

    #region FUNCIONES

    //creo la logica del collider de la espada

    private void ActivarTrigger()
    {
        ataqueCollider.enabled = true;//activa el collider desactivado al iniciar la animacion(atado mediante las propias funciones de unity, sin codigo)
    }

    private void DesactivarTrigger()
    {
        ataqueCollider.enabled = false;//desactiva el collider activado al acabar la animacion(atado mediante las propias funciones de unity, sin codigo)
    }

    //interaccion del player con los enemigos
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
