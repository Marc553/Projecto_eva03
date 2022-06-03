using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody playerBody;

    private Animator playerAnimator;

    private Collider ataqueCollider;

    private float timeBetweenAttacks = 1;

    private bool canAttack = true;


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

        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            AtacarCollider();
            playerAnimator.SetTrigger("Atacar");
            

            canAttack = false;
            StartCoroutine(AttackCooldown());

        }
    }

    public void AtacarCollider()
    {
        ataqueCollider.enabled = true; 
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        ataqueCollider.enabled = false;
        canAttack = true;
    }

}
