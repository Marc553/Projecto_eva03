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

    //public List<Collider> TriggerList = new List<Collider>();

    private void Start()
    {
        //conecto la varaible con el script Game manager para llamar al spawn enemies tantas veces como quiera en cada sala diferente
        conexionGame = FindObjectOfType<Game_Manager>();
        conexionGame.SpawnEnemies(totalEnemies);
    }

    /*public void OnTriggerEnter(Collider other)
    {
        //if the object is not already in the list
        if (other.gameObject.CompareTag("cabolo") || other.gameObject.CompareTag("canon"))
        {
            //add the object to the list
            TriggerList.Add(other);

            Debug.Log(TriggerList);
        }

        
    }*/

    

}
