using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_cabolo : MonoBehaviour
{
    #region VARIALBES
    // Variables cogen datos del propio enemigo
    private NavMeshAgent agent;
 
    private Transform player;
    [SerializeField] private float speed = 5f;
    // Variables del limite de sala 
    private float deteccionLimSala = 57f;
    private bool playerDentroSala;
    [SerializeField] private LayerMask capasLimites;

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
        player = GameObject.Find("Player").transform;
    }


    void Update()
    {
        // Areas de visión
        
        // Detecta si el player esta dentro de la sala para empezar persecucion
        Vector3 pos = transform.position;
        //playerDentroSala = Physics.SphereCast(pos, 0.5f, -transform.right, out RaycastHit hit, deteccionLimSala, capasLimites);
        playerDentroSala = Physics.CheckSphere(pos, deteccionLimSala, capasLimites);

        // Activamos la lógica de persecución 
        if (playerDentroSala) //ni en area de vision 
        {
            Chase();//son paretes del component agent
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

    //logica collisiones
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("espada"))
        {
            Destroy(gameObject);
        }
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