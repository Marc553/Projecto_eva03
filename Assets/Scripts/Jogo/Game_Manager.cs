using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    private int cabolosLeft;
    private int canonLeft;

    private GameObject sala1;
    private GameObject sala2;
    private GameObject sala3;
    private GameObject sala4;


    private void Start()
    {
        SpawnEnemy();
    }
    private void Update()
    {
        //cabolosLeft = FindObjectOfType<Enemy_cabolo>().Length;
        //canonLeft = FindObjectOfType<Enemy_cabolo>().Length;
    }

    //logica de spawn de enemigos
    public void SpawnEnemy()
    {
        //creacion de elementos randoms para la posicion de spawn
        randomEnemy = Random.Range(0, objectsPrefabs.Length);
        randomPosition = Random.Range(0, way_points.Length);
        SpawnPosition = way_points[randomPosition];

            Instantiate(objectsPrefabs[randomEnemy], SpawnPosition.transform.position, SpawnPosition.transform.rotation);
    }

    public void SpawnEnemies(int totalenemies)
    {
        for (int i = 0; i < totalenemies; i++)
        {
            SpawnEnemy();
        }
    }

    public void GoToScene(string sceneName)
    {
        // Cargamos la escena que tenga por nombre sceneName
        SceneManager.LoadScene(sceneName);
    }

    //EXIT
    public void Exit()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
