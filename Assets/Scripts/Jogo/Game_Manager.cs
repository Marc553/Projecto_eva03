using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEditor;


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

    //variables sonido / datapersistence
    private AudioSource musicaMazmorra;
    public AudioClip ambienteMazmorra;

    public AudioSource sonidoEfectos;
    public AudioClip efectoEnemigo;
    public AudioClip ganar;

    public TextMeshProUGUI volume; //float

    //detectar que acabaste con todos
    public int enemiesLeftCabolo;
    public int enemiesLeftCanon;

    //variables para el game over
    public bool isGameOver;
    public GameObject gameOverPanel;
    public GameObject winnerPanel;

    public GameObject rasho;

    #endregion

    #region METODOS
    private void Start()
    { //logicas llamadas en otros scripts y la musica por data persistence
        SpawnEnemy();
        musicaMazmorra = GetComponent<AudioSource>();
        musicaMazmorra.PlayOneShot(ambienteMazmorra);

        sonidoEfectos = GameObject.Find("Efectos").GetComponent<AudioSource>();
        
        musicaMazmorra.volume = Data_persistence.SharedInfo.volumenMusica;
        sonidoEfectos.volume = Data_persistence.SharedInfo.volumenEfectos;
        isGameOver = false;
    }

    private void Update()
    {
        if(isGameOver == false)
        {
            enemiesLeftCabolo = FindObjectsOfType<Enemy_cabolo>().Length;
            enemiesLeftCanon = FindObjectsOfType<Enemy_canon>().Length;

           if(enemiesLeftCabolo <= 0 && enemiesLeftCanon <= 0)
           {
                rasho.SetActive(true);
                sonidoEfectos.PlayOneShot(ganar);
                musicaMazmorra.Stop();
           }
        }
            
    }
    #endregion

    #region FUNCIONES

    public void GameOver()
    {
        musicaMazmorra.Stop();
        sonidoEfectos.Stop();
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void YouWin()
    {
        musicaMazmorra.Stop();
        sonidoEfectos.Stop();
        winnerPanel.SetActive(true);
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
