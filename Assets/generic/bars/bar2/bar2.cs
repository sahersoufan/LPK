using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar2 : MonoBehaviour
{
    public Sprite UP;
    public GameObject Bar;
    public GameObject test;

    public up Up;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "up")
        {

            /*GameObject g = new GameObject();*/
            GameObject g =  Instantiate(test);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(Bar.transform);
            g.transform.localScale = new Vector3((float)0.34, (float)0.11, (float)1);
            g.GetComponent<RectTransform>().localPosition = new Vector3((float)-20, (float)37.5, (float)0);
            /*   Image i = g.AddComponent<Image>();
            i.sprite = UP;
            g.GetComponent<RectTransform>().SetParent(Bar.transform);
            g.layer = Bar.layer;
            g.transform.position = new Vector3(Bar.transform.position.x, Bar.transform.position.y, Bar.transform.position.z);
            g.transform.localScale = new Vector3((float) 0.5,(float) 0.5, (float) 0);
            g.SetActive(true);*/
        }
        else if (other.name == "down")
        {
            GameObject g = new GameObject();
            Image i = g.AddComponent<Image>();
            i.sprite = UP;
            g.GetComponent<RectTransform>().SetParent(Bar.transform);
            g.SetActive(true);
        }
        else if (other.name == "left")
        {
            GameObject g = new GameObject();
            Image i = g.AddComponent<Image>();
            i.sprite = UP;
            g.GetComponent<RectTransform>().SetParent(Bar.transform);
            g.SetActive(true);
        }
        else if (other.name == "right")
        {
            GameObject g = new GameObject();
            Image i = g.AddComponent<Image>();
            i.sprite = UP;
            g.GetComponent<RectTransform>().SetParent(Bar.transform);
            g.SetActive(true);
        }
        /*
        else if (other.name == "rotateLeft")
        {

        }
        else if (other.name == "rotateRight")
        {

        }*/

    }


}
