using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_enemiesxroom : MonoBehaviour
{
    private Game_Manager conexionGame;
    [SerializeField] int totalEnemies;

    private void Start()
    {
        conexionGame = FindObjectOfType<Game_Manager>();
        conexionGame.SpawnEnemies(totalEnemies);
    }

    

    
    // llamar spawn/contar enemigos/ noactivarlos hasta player

}
