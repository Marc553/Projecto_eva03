using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_canon : MonoBehaviour
{
    #region VARIALBES
    // Variables cogen datos del propio enemigo
    
    private Rigidbody enemyRigidbody;
    private Transform player;
    [SerializeField] private float speed = 5f;

    // Variables del limite de sala 
    private float deteccionLimSala = 40f;
    private bool playerDentroSala;
    [SerializeField] private LayerMask capasLimites;

    // Ataque
    [SerializeField] private GameObject projectil;
    private float tiempoAtaque = 2f;
    private bool puedePegar = true;
   
    private float fuerzaAtaque = 20f;

    #endregion

    #region METODOS
   
    void Start()
    {
        // Enlazo las variables con los componentes del enemy
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
    }


    void Update()
    {
        // Areas de visión/ataque del agente

        // Detecta si el player esta dentro de la sala para empezar persecucion/ataque
        Vector3 pos = transform.position;
        //playerDentroSala = Physics.SphereCast(pos, 0.5f, transform.forward, out RaycastHit hit, deteccionLimSala, capasLimites);

        playerDentroSala = Physics.CheckSphere(pos, deteccionLimSala, capasLimites);

        // Activamos la lógica de persecución 
        
        if (playerDentroSala) //en area de ataque ni de vision
        {
            Attack();//son paretes del component agent
        }
    }

    #endregion

    #region FUNCIONES

    // Lógica de ataque (Agente)
    private void Attack()
    {
        transform.LookAt(player.transform.position);
        // Si hemos finalizado el Attack Cooldown
        if (puedePegar)
        {
            // Disparamos bala con físicas
            Rigidbody rb = Instantiate(projectil, transform.position, Quaternion.identity).GetComponent<Rigidbody>(); //instancia la bala para disaparar al player
            rb.AddForce(transform.forward * fuerzaAtaque, ForceMode.Impulse); //disparo de la bala

            // Activamos Attack Cooldown
            puedePegar = false;
            StartCoroutine(AttackCooldown());
        }
    }
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(tiempoAtaque);
        puedePegar = true;
    }

    // Gizmos
    private void OnDrawGizmos()
    {
        // Rango de vision del  limite de la sala (Agente)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, deteccionLimSala);
    }

    #endregion
}
