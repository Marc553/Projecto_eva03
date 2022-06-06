using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options_Manager : MonoBehaviour
{
    private AudioSource musicaMenu;
    public AudioClip ambienteMenu;

    private AudioSource sonidoEfectos;
    public AudioClip efecto;

    private void Start()
    {
        musicaMenu = GetComponent<AudioSource>();
        musicaMenu.PlayOneShot(ambienteMenu);

        sonidoEfectos = GameObject.Find("Efectos").GetComponent<AudioSource>();
    }



    private void Update()
    {//preguntar como hacer que suene solo al clicar el slider
        

    }

    //para llegar a la menu scene
    public void GoToScene(string sceneName)
    {
        // Cargamos la escena que tenga por nombre sceneName
        SceneManager.LoadScene(sceneName);
    }
}
