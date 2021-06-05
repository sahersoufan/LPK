using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar2 : MonoBehaviour
{


    private static BoxCollider2D boxCollider;
    private static GameObject stBar;
    private static GameObject stUp;
    private static ArrayList objects = new ArrayList();
    public GameObject Bar;
    public GameObject upInBar;
    public GameObject downInBar;
    public GameObject leftInBar;
    public GameObject rightInBar;

    private static int counter4SoftwreClibs = 0;



    private void Start()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
        stBar = Bar;
        stUp = upInBar;

    }


   
    public static void addUp()
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(stUp);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(stBar.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            if (objects.Count > 0)
            {
                GameObject previos = getFromObjects(objects.Count - 1);
                g.name = "u" + counter4SoftwreClibs;
                counter4SoftwreClibs++;
                g.layer = 6;
                addtoObjects(g);
                float x = previos.GetComponent<RectTransform>().localPosition.x;
                float y = previos.GetComponent<RectTransform>().localPosition.y;
                float z = previos.GetComponent<RectTransform>().localPosition.z;
                g.GetComponent<RectTransform>().localPosition = new Vector3((float)x, (float)y - 7, (float)z);

            }
            else
            {
                g.name = "u" + counter4SoftwreClibs;
                counter4SoftwreClibs++;
                g.layer = 6;
                addtoObjects(g);
                g.GetComponent<RectTransform>().localPosition = new Vector3((float)-26.5, (float)37.5, (float)0);

            }

            float xColl = boxCollider.offset.x;
            float yColl = boxCollider.offset.y;
            boxCollider.offset = new Vector2(xColl, yColl - 7);
        }
    }

    private static void addtoObjects(GameObject obj)
    {
        objects.Add(obj);
    }

    private static GameObject getFromObjects(int index)
    {
        return (GameObject)objects[index];
    }

    public static void removeFromObjects(GameObject g)
    {
        
        for(int i = objects.IndexOf(g) + 1 ; i < objects.Count ; i++)
        {
            GameObject temp = (GameObject) objects[i];
            float x = temp.GetComponent<RectTransform>().localPosition.x;
            float y = temp.GetComponent<RectTransform>().localPosition.y;
            float z = temp.GetComponent<RectTransform>().localPosition.z;
            temp.GetComponent<RectTransform>().localPosition = new Vector3(x, y + 7, z);
        }
        objects.Remove(g);

        float xColl = boxCollider.offset.x;
        float yColl = boxCollider.offset.y;
        boxCollider.offset = new Vector2(xColl, yColl + 7);
    }





    // if i drag the object to the last of objects
    public static bool isInside(Vector2 point)
    {
        return point == stBar.GetComponent<Collider2D>().ClosestPoint(point) ? true : false;
    }

    public static GameObject isInsideAClibs(Vector2 point)
    {
        for(int i = 0; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            if(point == temp.GetComponent<Collider2D>().ClosestPoint(point))
            {
                return temp;
            }
        }
        return null;
    }

    public static void changeObjectPosition(GameObject obj)
    {
        for (int i = objects.IndexOf(obj) + 1 ; i < objects.Count ; i++)
        {
            GameObject temp = (GameObject)objects[i];
            float x = temp.GetComponent<RectTransform>().localPosition.x;
            float y = temp.GetComponent<RectTransform>().localPosition.y;
            float z = temp.GetComponent<RectTransform>().localPosition.z;
            temp.GetComponent<RectTransform>().localPosition = new Vector3(x, y + 7, z);
        }
        objects.Remove(obj);

        if (objects.Count > 0)
        {
            GameObject temp1 = (GameObject)objects[objects.Count - 1];
            float x1 = temp1.GetComponent<RectTransform>().localPosition.x;
            float y1 = temp1.GetComponent<RectTransform>().localPosition.y;
            float z1 = temp1.GetComponent<RectTransform>().localPosition.z;
            obj.GetComponent<RectTransform>().localPosition = new Vector3(x1, y1 - 7, z1);
        }
        else
        {
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)-26.5, (float)37.5, (float)0);
        }
        objects.Add(obj);
    }


    public static void makeItAsDefault(GameObject obj)
    {
        int count = objects.Count;
        int i = objects.IndexOf(obj);
        if (i > 0)
        {
            GameObject temp = (GameObject)objects[i - 1];
            float y = temp.GetComponent<RectTransform>().localPosition.y;
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)-26.5, y - 7, (float) 0 );
        }
        else if(i == 0)
        {
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)-26.5, (float)37.5, (float)0);

        }
    }

    public static void addUpBetween( GameObject obj)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(stUp);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(stBar.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.name = "u" + counter4SoftwreClibs;
            counter4SoftwreClibs++;
            g.layer = 6;


            float x = obj.GetComponent<RectTransform>().localPosition.x;
            float y = obj.GetComponent<RectTransform>().localPosition.y;
            float z = obj.GetComponent<RectTransform>().localPosition.z;
            g.GetComponent<RectTransform>().localPosition = new Vector3((float)x, (float)y, (float)z);



            for (int i = objects.IndexOf(obj); i < objects.Count; i ++)
            {
                GameObject temp = (GameObject)objects[i];
                float x1 = temp.GetComponent<RectTransform>().localPosition.x;
                float y1 = temp.GetComponent<RectTransform>().localPosition.y;
                float z1 = temp.GetComponent<RectTransform>().localPosition.z;
                obj.GetComponent<RectTransform>().localPosition = new Vector3(x1, y1 - 7, z1);
            }

           
            objects.Insert(objects.IndexOf(obj), g);



        }

    }
}
