using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("test");

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
    }
    }
