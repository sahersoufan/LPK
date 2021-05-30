using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar2 : MonoBehaviour
{
    public Sprite UP;
    public GameObject bar;


    public up Up;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");



        if (other.name == "up")
        {
            GameObject g = new GameObject();
            Image i = g.AddComponent<Image>();
            i.sprite = UP;
            g.GetComponent<RectTransform>().SetParent(bar.transform);
            g.SetActive(true);
        }
        else if (other.name == "down")
        {

        }
        else if (other.name == "left")
        {

        }
        else if (other.name == "right")
        {

        }
        else if (other.name == "rotateLeft")
        {

        }
        else if (other.name == "rotateRight")
        {

        }

    }


}
