using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    #region VARIALBES
    //arrays de elementos/elementos exteriores
    public GameObject[] objectsPrefabs;
    public GameObject[] way_points;

    //elementos randoms 
    private GameObject SpawnPosition;
    private int randomEnemy;
    private int randomPosition;

    private int cabolosLeft;
    private int canonLeft;

    private AudioSource musicaMazmorra;
    public AudioClip ambienteMazmorra;

    public AudioSource sonidoEfectos;
    public AudioClip efectoEnemigo;
    


#endregion

    private void Start()
    {
        SpawnEnemy();
        musicaMazmorra = GetComponent<AudioSource>();
        musicaMazmorra.PlayOneShot(ambienteMazmorra);

        sonidoEfectos = GameObject.Find("Efectos").GetComponent<AudioSource>();

    }
    #region FUNCIONES
    //logica de spawn de enemigos
    public void SpawnEnemy()
    {
        //creacion de elementos randoms para la posicion de spawn
        randomEnemy = Random.Range(0, objectsPrefabs.Length);
        randomPosition = Random.Range(0, way_points.Length);
        SpawnPosition = way_points[randomPosition];

            Instantiate(objectsPrefabs[randomEnemy], SpawnPosition.transform.position, SpawnPosition.transform.rotation);
    }

    //lleva a cabo la creacion de tantos enemigos como indique el numero(se ejecuta en el script Spawn_enemiesxroom)
    public void SpawnEnemies(int totalenemies)
    {
        for (int i = 0; i < totalenemies; i++)
        {
            SpawnEnemy();
        }
    }

    //lleva a la escena deseada
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
#endregion
}
