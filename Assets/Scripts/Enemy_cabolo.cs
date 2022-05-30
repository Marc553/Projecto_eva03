using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_cabolo : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody enemyRigidbody;
    private Transform player;
    [SerializeField] private float speed = 5f;

    #region CODIGO AGENTE

    //CODIGO DEL MODO AGENTE
    private float visionRange = 20;
    private float attackRange = 10;

    private bool playerInVisionRange;
    private bool playerInAttackRange;

    // Capa que debe tenerse en cuenta para campos de visión y ataque
    [SerializeField] private LayerMask playerLayer;

    // Ataque
    [SerializeField] private GameObject bullet;
    private float timeBetweenAttacks = 2f;
    private bool canAttack = true;
    private float upAttackForce = 5f;
    private float forwardAttackForce = 8f;
    #endregion

    private void Awake()
    {
        // Guardamos la referencia a la componente NavMeshAgent del Game Object
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
    }


    void Update()
    {
        // Campos de visión y ataque del agente 
        Vector3 pos = transform.position;
        playerInVisionRange = Physics.CheckSphere(pos, visionRange, playerLayer);//mirar de usar el Check cube con forma de ortoedro 
        playerInAttackRange = Physics.CheckSphere(pos, attackRange, playerLayer);

        // Activamos la lógica de persecución 
        if (playerInVisionRange && !playerInAttackRange) //ni en area de vision pero no ataque
        {
            Chase();//son paretes del component agent
        }

        if (playerInVisionRange && playerInAttackRange) //en area de ataque ni de vision
        {
            Attack();//son paretes del component agent
        }
    }
    #region RAY CAST

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

    #endregion

    // Lógica de persecución del agente
    private void Chase()
    {
        // Fijamos como objetivo al player
        transform.LookAt(player);
        agent.SetDestination(player.position);//eta atado al if de antes
        
    }

    // Lógica de ataque del agente
    private void Attack()
    {
        // Paramos al agente para cuando ataque 
        agent.SetDestination(transform.position);
        transform.LookAt(player.position);

        // Si hemos finalizado el Attack Cooldown
        if (canAttack)
        {
            // Disparamos bala con físicas
            Rigidbody rb = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>(); //instanciamiento de la bala para disaparar al player
            rb.AddForce(transform.forward * forwardAttackForce, ForceMode.Impulse); //disparo de la bala, messirve que dispare la bala con fuerzsas, asi se caen 
            rb.AddForce(transform.up * upAttackForce, ForceMode.Impulse);

            // Activamos Attack Cooldown
            canAttack = false;
            StartCoroutine(AttackCooldown());
        }
    }
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }

    // Esta función nos permite dibujar Gizmos
    private void OnDrawGizmos()
    {
        // Rango de visión del agente
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);//usar el DrawWireCube( deformar como ortoedro)

        // Rango de ataque del agente
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}

