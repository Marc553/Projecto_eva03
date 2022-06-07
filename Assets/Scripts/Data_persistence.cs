using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_persistence : MonoBehaviour
{
    public static Data_persistence SharedInfo;

    public float volumenMusica; //valor del slider de volumen
    public float volumenEfectos; //valor del slider de volumen

    public int SceneChanges; //escena actual 
    public int PreviousSceneChanges; //escena anterior

    //Para que la instancia sea única
    private void Awake()
    {

        //Si la instancia no existe
        if (SharedInfo == null)
        {
            //Configuramos la instancia
            SharedInfo = this;
            //Nos aseguramos de que no sea destruida con el cambio de escena
            DontDestroyOnLoad(SharedInfo);
        }
        else
        {
            //Como ya existe una instancia, destruimos la copia
            Destroy(this);
        }
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey("MUSICA"))
        {
            volumenMusica = PlayerPrefs.GetFloat("MUSICA");
            volumenEfectos = PlayerPrefs.GetFloat("EFECTOS");

        }
        else
        {
            volumenMusica = 0.75f;
            volumenEfectos = 0.75f;

        }
    }
    public void SaveForFutureGames()
    {
        //volumen
        PlayerPrefs.SetFloat("MUSICA", volumenMusica);

        PlayerPrefs.SetFloat("EFECTOS", volumenEfectos);

        //escenas actuales
        PlayerPrefs.SetInt("ESCENACTUAL", SceneChanges);

        //ecena anterior
        PlayerPrefs.SetInt("ESCENANTERIOR", PreviousSceneChanges);

    }
}
