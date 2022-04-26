using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward_movement : MonoBehaviour
{
    public float speed = 30;
    private void Update()
    {
        transform.Translate(Vector3.forward * speed *Time.deltaTime);
    }
}
