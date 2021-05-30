using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{

    public GameObject UP;
    static float x = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x,0,0);
    }
    public static void size()
    {
        x = 300;
    }
}
