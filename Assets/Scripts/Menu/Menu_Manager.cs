using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    private AudioSource musicaMenu;
    public AudioClip ambienteMenu;

    private void Start()
    {
        musicaMenu = GetComponent<AudioSource>();
        musicaMenu.PlayOneShot(ambienteMenu);
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
