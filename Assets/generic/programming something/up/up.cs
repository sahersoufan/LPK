using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{

    public GameObject UP;
    static float x = 1;
    static bool t = false;
    // Update is called once per frame
    void Update()
    {
        if (t)
        {
            transform.position = new Vector3(x, 0, 0);
        }
    }
    public static void size()
    {
        x = 300;
        t = true;
    }
}
