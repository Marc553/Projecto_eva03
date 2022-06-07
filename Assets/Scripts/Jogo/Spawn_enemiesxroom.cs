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

    private void Start()
    {
        //conecto la varaible con el script Game manager para llamar al spawn enemies tantas veces como quiera en cada sala diferente
        conexionGame = FindObjectOfType<Game_Manager>();
        conexionGame.SpawnEnemies(totalEnemies);
    }

    private void OnCollision(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //enemigos_cabolos = find
        }
    }

}
