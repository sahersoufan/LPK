using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar2 : MonoBehaviour
{


    private BoxCollider2D boxCollider;
    private ArrayList objects = new ArrayList();
    [SerializeField] GameObject upInBar;
    [SerializeField] GameObject downInBar;
    [SerializeField] GameObject leftInBar;
    [SerializeField] GameObject rightInBar;
    [SerializeField] GameObject ForInBar;
    [SerializeField] GameObject ifInBar;

    private int counter4SoftwreClibs = 0;
    private int Maxcounter = 12;

/*    private float startUpOfClibs;
*/

    private void Start()
    {

        float ScreenX = Screen.width;
        float ScreenY = Screen.height;


        float newBarPosX = (50 * ScreenX) / 100;
        this.GetComponent<RectTransform>().localPosition = new Vector3(newBarPosX, (float)0, (float)0);

        float newBarScaX = (((float)  28.04 * ScreenX) / (float) 100) / (float) 100;
        float newBarScaY = (((float) 100 * ScreenY) / (float)100) / (float)100;
/*        startUpOfClibs = (newBarScaY / (float) 2) - (float) 4;
*/        this.GetComponent<RectTransform>().localScale = new Vector3(newBarScaX, newBarScaY, (float)0);
        boxCollider = this.GetComponent<BoxCollider2D>();
    }


    //              UP               //
   
    public void addUp()
    {

        GameObject g = Instantiate(upInBar);
        g.name = "up";
        addObjToBar(g);
        
    }

    public  void addUpBetween(GameObject obj)
    {
        GameObject g = Instantiate(upInBar);
        g.name = "up";
        AddObjBetweenCLibsInBar(g, obj);

    }

    //              DOWN                //

    public void addDown()
    {

            GameObject g = Instantiate(downInBar);
            g.name = "down";
            addObjToBar(g);
        
    }

    public  void addDownBetween(GameObject obj)
    {
            GameObject g = Instantiate(downInBar);
            g.name = "down";
            AddObjBetweenCLibsInBar(g, obj);

    }

    //              LEFT             //
    public void addLeft()
    {
            GameObject g = Instantiate(leftInBar);
        g.name = "left";
            addObjToBar(g);
        
    }

    public void addLeftBetween(GameObject obj)
    {

            GameObject g = Instantiate(leftInBar);
            g.name = "left";
            AddObjBetweenCLibsInBar(g, obj);
        

    }

    //              RIGHT                //

    public  void addRight()
    {

            GameObject g = Instantiate(rightInBar);
        g.name = "right";
            addObjToBar(g);
        
    }

    public void addRightBetween(GameObject obj)
    {
            GameObject g = Instantiate(rightInBar);
            g.name = "right";
            AddObjBetweenCLibsInBar(g, obj);
        

    }

    public void addFor()
    {
            GameObject g = Instantiate(ForInBar);
            g.name = "for";
            addObjToBar(g);
    }


    public void addForBetween(GameObject obj)
    {
            GameObject g = Instantiate(ForInBar);
            g.name = "for";
            AddObjBetweenCLibsInBar(g, obj);

    }


    public void addIf()
    {
            GameObject g = Instantiate(ifInBar);
            g.name = "if";
            addObjToBar(g);
    }


    public void addIfBetween(GameObject obj)
    {
            GameObject g = Instantiate(ifInBar);
            g.name = "if";
            AddObjBetweenCLibsInBar(g, obj);

    }
















    // DEAL WITH OBJECTS LIST //

    private void addtoObjects(GameObject obj)
    {
        objects.Add(obj);
    }

    private GameObject getFromObjects(int index)
    {
        return (GameObject)objects[index];
    }


    public bool canRemove(Vector2 point)
    {
        return point.x < (float) -50 ? true : false;
    }
    public void removeFromObjects(GameObject g)
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
        counter4SoftwreClibs--;
        float xColl = boxCollider.offset.x;
        float yColl = boxCollider.offset.y;
        boxCollider.offset = new Vector2(xColl, yColl + 7);
    }

    // is inside for everything
    public bool isInsideEverythingAndAddIt(Vector3 point, string name)
    {
        Vector2 Point2D = new Vector2(point.x, point.y);
        if(Point2D == this.gameObject.GetComponent<Collider2D>().ClosestPoint(Point2D) && counter4SoftwreClibs < Maxcounter)
        {
            if (name.Equals("up"))
            {
                addUp();
            }else if (name.Equals("down"))
            {
                addDown();
            }
            else if (name.Equals("right"))
            {
                addRight();
            }
            else if (name.Equals("left"))
            {
                addLeft();
            }
            else if (name.Equals("for"))
            {
                addFor();
            }
            else if (name.Equals("if"))
            {
                addIf();
            }
            return true;
        }

        ArrayList tempObjects = new ArrayList();
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            if (Point2D == temp.GetComponent<Collider2D>().ClosestPoint(Point2D) && counter4SoftwreClibs < Maxcounter )
            {
                if (name.Equals("up"))
                {
                    addUpBetween(temp);
                }
                else if (name.Equals("down"))
                {
                    addDownBetween(temp);
                }
                else if (name.Equals("right"))
                {
                    addRightBetween(temp);

                }
                else if (name.Equals("left"))
                {
                    addLeftBetween(temp);

                }
                else if (name.Equals("for"))
                {
                    addForBetween(temp);

                }
                else if (name.Equals("if"))
                {
                    addIfBetween(temp);

                }
                return true;
            }

            if(temp.name.Equals("for") || temp.name.Equals("if"))
            {
                tempObjects.Add(temp);
            }
        }

        for(int i = 0; i <tempObjects.Count; i++)
        {
            GameObject temp = (GameObject)tempObjects[i];
            if (temp.name.Equals("for"))
            {
                if (temp.GetComponent<forInBar>().isInsideEverythingAndAddIt(point, name, Maxcounter - (objects.IndexOf(temp) + 1)))
                {
                    return true;
                }
            }else if (temp.name.Equals("if"))
            {
                if (temp.GetComponent<ifInBar>().isInsideEverythingAndAddIt(point, name, Maxcounter - (objects.IndexOf(temp) + 1)))
                {
                    return true;
                }
            }
        }
        return false;
    }



    // if i drag the object to the last of objects
    public bool isInside(Vector2 point)
    {
        return point == this.gameObject.GetComponent<Collider2D>().ClosestPoint(point) ? true : false;
    }

    public GameObject isInsideAClibs4InBarClibs(GameObject obj)
    {

        float x = obj.GetComponent<RectTransform>().position.x;
        float y = obj.GetComponent<RectTransform>().position.y;
        Vector2 point = new Vector2(x, y);
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            if (point == temp.GetComponent<Collider2D>().ClosestPoint(point) && !temp.Equals(obj))
            {
                return temp;
            }
        }
        return null;
    }


    public void changeObjectPosition(GameObject obj)
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
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)-25, (float)46, (float)0);
        }
        objects.Add(obj);
    }


    public void makeItAsDefault(GameObject obj)
    {
        int count = objects.Count;
        int i = objects.IndexOf(obj);
        if (i > 0)
        {
            GameObject temp = (GameObject)objects[i - 1];
            float y = temp.GetComponent<RectTransform>().localPosition.y;
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)-25, y - 7, (float) 0 );
        }
        else if(i == 0)
        {
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)-25, (float)46, (float)0);

        }
    }

    public void changeObjectPositionbetweenClibs(GameObject obj, GameObject obj2)
    {
        int i = objects.IndexOf(obj) + 1;
        if (i - 1 < objects.IndexOf(obj2))
        {
            for (; i <= objects.IndexOf(obj2); i++)
            {
                GameObject temp = (GameObject)objects[i];
                float x = temp.GetComponent<RectTransform>().localPosition.x;
                float y = temp.GetComponent<RectTransform>().localPosition.y;
                float z = temp.GetComponent<RectTransform>().localPosition.z;
                temp.GetComponent<RectTransform>().localPosition = new Vector3((float)x, (float)y + 7, (float)z);
            }
            objects.Remove(obj);

            GameObject temp2 = (GameObject)objects[objects.IndexOf(obj2)];
            float x1 = temp2.GetComponent<RectTransform>().localPosition.x;
            float y1 = temp2.GetComponent<RectTransform>().localPosition.y;
            float z1 = temp2.GetComponent<RectTransform>().localPosition.z;
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)x1, (float)y1 - 7, (float)z1);
            objects.Insert(objects.IndexOf(obj2) + 1, obj);
        }
        else if (i - 1 > objects.IndexOf(obj2))
        {
            i -= 2;
            for(; i >= objects.IndexOf(obj2); i--)
            {
                GameObject temp = (GameObject)objects[i];
                float x = temp.GetComponent<RectTransform>().localPosition.x;
                float y = temp.GetComponent<RectTransform>().localPosition.y;
                float z = temp.GetComponent<RectTransform>().localPosition.z;
                temp.GetComponent<RectTransform>().localPosition = new Vector3((float)x, (float)y - 7, (float)z);
            }
            objects.Remove(obj);

            GameObject temp2 = (GameObject)objects[objects.IndexOf(obj2)];
            float x1 = temp2.GetComponent<RectTransform>().localPosition.x;
            float y1 = temp2.GetComponent<RectTransform>().localPosition.y;
            float z1 = temp2.GetComponent<RectTransform>().localPosition.z;
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)x1, (float)y1 + 7, (float)z1);
            objects.Insert(objects.IndexOf(obj2), obj);

        }
    }






////////////////// Add to Bar ///////////////////////
private void addObjToBar(GameObject g)
    {
        g.AddComponent<RectTransform>();
        g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
        g.GetComponent<RectTransform>().localScale = new Vector3((float)0.27, (float)0.11, (float)1);
        counter4SoftwreClibs++;

        if (objects.Count > 0)
        {
            GameObject previos = getFromObjects(objects.Count - 1);
            float x = previos.GetComponent<RectTransform>().localPosition.x;
            float y = previos.GetComponent<RectTransform>().localPosition.y;
            float z = previos.GetComponent<RectTransform>().localPosition.z;
            g.GetComponent<RectTransform>().localPosition = new Vector3((float)x, (float)y - 7, (float)z);

        }
        else
        {
            g.GetComponent<RectTransform>().localPosition = new Vector3((float)-25, (float)46, (float)0);
        }
        addtoObjects(g);

        float xColl = boxCollider.offset.x;
        float yColl = boxCollider.offset.y;
        boxCollider.offset = new Vector2(xColl, yColl - 7);
    }

    private void AddObjBetweenCLibsInBar(GameObject g, GameObject obj)
    {

        g.AddComponent<RectTransform>();
        g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
        g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
        counter4SoftwreClibs++;

        float x = obj.GetComponent<RectTransform>().localPosition.x;
        float y = obj.GetComponent<RectTransform>().localPosition.y;
        float z = obj.GetComponent<RectTransform>().localPosition.z;
        g.GetComponent<RectTransform>().localPosition = new Vector3((float)x, (float)y, (float)z);



        for (int i = objects.IndexOf(obj); i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            float x1 = temp.GetComponent<RectTransform>().localPosition.x;
            float y1 = temp.GetComponent<RectTransform>().localPosition.y;
            float z1 = temp.GetComponent<RectTransform>().localPosition.z;
            temp.GetComponent<RectTransform>().localPosition = new Vector3(x1, y1 - 7, z1);
        }


        objects.Insert(objects.IndexOf(obj), g);

        float xColl = boxCollider.offset.x;
        float yColl = boxCollider.offset.y;
        boxCollider.offset = new Vector2(xColl, yColl - 7);

    }



}




