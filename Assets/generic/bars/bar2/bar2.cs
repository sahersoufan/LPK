using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar2 : MonoBehaviour
{


    private static BoxCollider2D boxCollider;
    private static GameObject stBar;
    private static GameObject stUp;
    GameObject[] a;
    public  GameObject Bar;
    public GameObject upInBar;
    public GameObject downInBar;
    public GameObject leftInBar;
    public GameObject rightInBar;



    private void Start()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
        stBar = Bar;
        stUp = upInBar;

    }



    public static void addUp()
    {
        GameObject g = Instantiate(stUp);
        g.AddComponent<RectTransform>();
        g.GetComponent<RectTransform>().SetParent(stBar.transform);
        g.transform.localScale = new Vector3((float)0.34, (float)0.11, (float)1);
        /*        GameObject[] objects =  FindGameObjectsInLayer(6
        */
        g.layer = 6;
        g.GetComponent<RectTransform>().localPosition = new Vector3((float)-20, (float)37.5, (float)0);
    }


    static GameObject[] FindGameObjectsInLayer(int layer)
    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        var goList = new System.Collections.Generic.List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
    }



}










/*
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.name == "up")
        {
            GameObject g =  Instantiate(upInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(Bar.transform);
            g.transform.localScale = new Vector3((float)0.34, (float)0.11, (float)1);
            g.GetComponent<RectTransform>().localPosition = new Vector3((float)-20, (float)37.5, (float)0);
            }
        else if (other.name == "down")
        {
            GameObject g = Instantiate(downInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(Bar.transform);
            g.transform.localScale = new Vector3((float)0.34, (float)0.11, (float)1);
            g.GetComponent<RectTransform>().localPosition = new Vector3((float)-20, (float)37.5, (float)0);
        }
        else if (other.name == "left")
        {
            GameObject g = Instantiate(leftInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(Bar.transform);
            g.transform.localScale = new Vector3((float)0.34, (float)0.11, (float)1);
            g.GetComponent<RectTransform>().localPosition = new Vector3((float)-20, (float)37.5, (float)0);
        }
        else if (other.name == "right")
        {
            GameObject g = Instantiate(rightInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(Bar.transform);
            g.transform.localScale = new Vector3((float)0.34, (float)0.11, (float)1);
            g.GetComponent<RectTransform>().localPosition = new Vector3((float)-20, (float)37.5, (float)0);
        }
        *//*
        else if (other.name == "rotateLeft")
        {

        }
        else if (other.name == "rotateRight")
        {

        }*//*

    }


}
*/



/*GameObject g = new GameObject();*/
/*   Image i = g.AddComponent<Image>();
i.sprite = UP;
g.GetComponent<RectTransform>().SetParent(Bar.transform);
g.layer = Bar.layer;
g.transform.position = new Vector3(Bar.transform.position.x, Bar.transform.position.y, Bar.transform.position.z);
g.transform.localScale = new Vector3((float) 0.5,(float) 0.5, (float) 0);
g.SetActive(true);*/
