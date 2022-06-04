using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //arrays de elementos/elementos exteriores
    public GameObject[] objectsPrefabs;
    public GameObject[] way_points;

    //elementos randoms 
    private GameObject SpawnPosition;
    private int randomEnemy;
    private int randomPosition;
    private float spawnPositionRange = 30;

    private void Update()
    {
        SpawnEnemy();
    }

    //logica de spawn de enemigos
    public void SpawnEnemy()
    {
        //creacion de elementos randoms para la posicion de spawn
        randomEnemy = Random.Range(0, objectsPrefabs.Length);
        randomPosition = Random.Range(0, way_points.Length);
        SpawnPosition = way_points[randomPosition];

        if(randomPosition == 0)
        {
            Instantiate(objectsPrefabs[randomEnemy], SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        }

        if (randomPosition == 1)
        {
            Instantiate(objectsPrefabs[randomEnemy], SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        }

        if (randomPosition == 2)
        {
            Instantiate(objectsPrefabs[randomEnemy], SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        }

        if (randomPosition == 3)
        {
            Instantiate(objectsPrefabs[randomEnemy], SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        }
    }
}
