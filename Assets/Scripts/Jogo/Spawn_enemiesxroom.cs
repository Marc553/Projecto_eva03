using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_enemiesxroom : MonoBehaviour
{
    //variables en uso 
    private Game_Manager conexionGame;
    [SerializeField] int totalEnemies;

    private int enemigos_cabolos;
    private int enemigos_canon;

    private bool salavacia;
    public GameObject door;


    private void Start()
    {
        //conecto la varaible con el script Game manager para llamar al spawn enemies tantas veces como quiera en cada sala diferente
        conexionGame = FindObjectOfType<Game_Manager>();
        conexionGame.SpawnEnemies(totalEnemies);
    }

    private void OnTriggerStay(Collider collision)
    {
        /*if(collision.gameObject.CompareTag("cabolo")/* || /*collision.gameObject.CompareTag("canon"))
        {
            salavacia = true;
            Debug.Log("siuuu");
        }
        
        else
        {
            salavacia = false;
            AbrirPuertas();
            
        }*/
        //Debug.Log(collision.gameObject.CompareTag(collision.gameObject));
    }

    public void AbrirPuertas()
    {
        if(salavacia == false)
        {
            door.SetActive(false);
        }
    }

}
