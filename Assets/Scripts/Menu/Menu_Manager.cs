using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEditor;


public class Menu_Manager : MonoBehaviour
{
    private AudioSource musicaMenu;
    public AudioClip ambienteMenu;

    public TextMeshProUGUI volume; //float

    private void Start()
    {
        musicaMenu = GetComponent<AudioSource>();
        musicaMenu.PlayOneShot(ambienteMenu);

        musicaMenu.volume = Data_persistence.SharedInfo.volumenMusica;
    }


    #region FUNCIONES DEL MENU
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
