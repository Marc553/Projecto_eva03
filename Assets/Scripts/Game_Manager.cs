using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject door;

    void Start()
    {
        player = GameObject.Find("Player");
    }
}
