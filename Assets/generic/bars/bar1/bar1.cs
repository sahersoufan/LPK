using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float ScreenX = Screen.width;
        float ScreenY = Screen.height;


        float newBarPosX = ((float) -6.953 * ScreenX) / 100;
        float newBarPosY = ((float) -50 * ScreenY) / 100;
        this.GetComponent<RectTransform>().localPosition = new Vector3(newBarPosX, (float)newBarPosY, (float)0);

        float newBarScaX = (((float)86.09375 * ScreenX) / (float)100) / (float)100;
        float newBarScaY = (((float)27.7777 * ScreenY) / (float)100) / (float)100;
        this.GetComponent<RectTransform>().localScale = new Vector3(newBarScaX, newBarScaY, (float)0);
    }

}
