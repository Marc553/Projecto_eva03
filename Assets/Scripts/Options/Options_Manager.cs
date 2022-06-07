using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEditor;


public class Options_Manager : MonoBehaviour
{
    #region VARAIBLES
    private AudioSource musicaMenu;
    public AudioClip ambienteMenu;

    private AudioSource sonidoEfectos;
    public AudioClip efecto;


    public Slider volumeSliderMusica; //donde sacaremos el valor (float)
    public Slider volumeSliderEfectos; //donde sacaremos el valor (float)

    private float numeroVolumenMusica;//valor del slider (float)
    private float numeroVolumenEfectos;//valor del slider (float)


    public TextMeshProUGUI SceneChanges;
    public TextMeshProUGUI LastSceneChanges;
    #endregion

    #region METODOS
    private void Start()
    {
        musicaMenu = GetComponent<AudioSource>();
        musicaMenu.PlayOneShot(ambienteMenu);

        sonidoEfectos = GameObject.Find("Efectos").GetComponent<AudioSource>();

        LoadUserOptions();
        SaveUserOptions();
    }

    private void Update()
    {//preguntar como hacer que suene solo al clicar el slider
        

    }
    #endregion

    #region FUNCIONES

    public void SaveUserOptions() //cuando se ejecuta guarda en el data persitance las variables en su respectiva caja
    {
        //persistencia de datos entre escenas

        Data_persistence.SharedInfo.volumenMusica = numeroVolumenMusica;
        Data_persistence.SharedInfo.volumenEfectos = numeroVolumenEfectos;

        //persistencia de datos entre partidas
        Data_persistence.SharedInfo.SaveForFutureGames();
    }

    public void LoadUserOptions()
    {
        //si tiene esta clave, entonces tiene todas

            numeroVolumenMusica = Data_persistence.SharedInfo.volumenMusica;//coge el último valor que ha tenido el slider

            numeroVolumenEfectos = Data_persistence.SharedInfo.volumenEfectos;//coge el último valor que ha tenido el slider
            
            LoadVolume();

            //guarda la persistencia de datos entre partidas
            //Data_persistence.SharedInfo.SaveForFutureGames();
        
    }

    #region UpdateVolume
    public void LoadVolume() //metemos el valor de numeroVolumen en el slider del menú de opciones, para cargar el volumen que se tenia configurado en otras partidas
    {
        volumeSliderMusica.GetComponent<Slider>().value = numeroVolumenMusica;
        volumeSliderEfectos.GetComponent<Slider>().value = numeroVolumenEfectos;
    }
    public void VolumeSelection(float V) //para que cuando cambiemos el valor del slider guardemos el valor para pasarlo al datapersistance
    {
        numeroVolumenMusica = V;
    }
    public void VolumeSelection2(float V) //para que cuando cambiemos el valor del slider guardemos el valor para pasarlo al datapersistance
    {
        numeroVolumenEfectos = V;
    }
    #endregion


    //para llegar a la menu scene
    public void GoToScene(string sceneName)
    {
        // Cargamos la escena que tenga por nombre sceneName
        SceneManager.LoadScene(sceneName);
    }

    #endregion

    public void PruebaEfectos()
    {
        Debug.Log("si");
        //sonidoEfectos.PlayOneShot(efecto,numeroVolumenEfectos);
    }
}
