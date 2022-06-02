using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_cabolo : MonoBehaviour
{/*
    #region VARIALBES
    // Variables cogen datos del propio enemigo
    private NavMeshAgent agent;
    private Rigidbody enemyRigidbody;
    private Transform player;
    [SerializeField] private float speed = 5f;
 
    // Variables del limite de sala 
    private float deteccionLimSala = 40f;
    private bool playerDentroSala;
    [SerializeField] private LayerMask capasLimites;

    #region CODIGO AGENTE

    // Distancias de las areas
    private float areaVisionAg = 20;
    private float areaAtaqueAg = 10;

    // Bool de si el player esta dentro
    private bool pruevaVisionAg;
    private bool pruevaAtaqueAg;

    // Capa que debe tenerse en cuenta para campos de visión y ataque
    [SerializeField] private LayerMask playerLayer;

    // Ataque
    [SerializeField] private GameObject projectil;
    private float tiempoAtaque = 2f;
    private bool puedePegar = true;
    private float fuerzaAtaqueArriba = 5f;
    private float fuerzaAtaque = 8f;
    #endregion

    #endregion

    #region METODOS
    private void Awake()
    {
        // Guardamos la referencia a la componente NavMeshAgent del Game Object
        agent = GetComponent<NavMeshAgent>();
    }

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
        playerDentroSala = Physics.SphereCast(pos, 0.5f, -transform.right, out RaycastHit hit, deteccionLimSala, capasLimites);
        pruevaAtaqueAg = Physics.CheckSphere(pos, areaAtaqueAg, playerLayer);

        // Activamos la lógica de persecución 
        if (playerDentroSala && !pruevaAtaqueAg) //ni en area de vision pero no ataque
        {
            Chase();//son paretes del component agent
        }

        if (playerDentroSala && pruevaAtaqueAg) //en area de ataque ni de vision
        {
            Attack();//son paretes del component agent
        }
    }

    #endregion

    #region FUNCIONES
    // Lógica de persecución (Agente)
    private void Chase()
    {
        // Fijamos como objetivo al player
        transform.LookAt(player);
        agent.SetDestination(player.position);
        
    }

    // Lógica de ataque (Agente)
    private void Attack()
    {
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
        // Rango de ataque (Agente)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaAtaqueAg);

        // Rango de vision del  limite de la sala (Agente)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, deteccionLimSala);
    }
    
    #endregion
    */
}