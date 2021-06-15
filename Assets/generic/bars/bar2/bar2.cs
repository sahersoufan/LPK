using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar2 : MonoBehaviour
{


    private BoxCollider2D boxCollider;
    private ArrayList objects = new ArrayList();
    public GameObject upInBar;
    public GameObject downInBar;
    public GameObject leftInBar;
    public GameObject rightInBar;
    public GameObject ForInBar;

    private static int counter4SoftwreClibs = 0;
    private float startUpOfClibs;


    private void Start()
    {

        float ScreenX = Screen.width;
        float ScreenY = Screen.height;


        float newBarPosX = (50 * ScreenX) / 100;
        this.GetComponent<RectTransform>().localPosition = new Vector3(newBarPosX, (float)0, (float)0);

        float newBarScaX = (((float)  28.04 * ScreenX) / (float) 100) / (float) 100;
        float newBarScaY = (((float) 100 * ScreenY) / (float)100) / (float)100;
        startUpOfClibs = (newBarScaY / (float) 2) - (float) 4;
        this.GetComponent<RectTransform>().localScale = new Vector3(newBarScaX, newBarScaY, (float)0);
        boxCollider = this.GetComponent<BoxCollider2D>();
    }


    //              UP               //
   
    public void addUp()
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(upInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.GetComponent<upInBar>().setb2(this.gameObject);
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
                g.GetComponent<RectTransform>().localPosition = new Vector3((float)-25, (float)46, (float)0);

            }

            float xColl = boxCollider.offset.x;
            float yColl = boxCollider.offset.y;
            boxCollider.offset = new Vector2(xColl, yColl - 7);
        }
    }

    public  void addUpBetween(GameObject obj)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(upInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.GetComponent<upInBar>().setb2(this.gameObject);

            g.name = "u" + counter4SoftwreClibs;
            counter4SoftwreClibs++;
            g.layer = 6;


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

    //              DOWN                //

    public void addDown()
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(downInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.GetComponent<downInBar>().setb2(this.gameObject);

            if (objects.Count > 0)
            {
                GameObject previos = getFromObjects(objects.Count - 1);
                g.name = "d" + counter4SoftwreClibs;
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
                g.name = "d" + counter4SoftwreClibs;
                counter4SoftwreClibs++;
                g.layer = 6;
                addtoObjects(g);
                g.GetComponent<RectTransform>().localPosition = new Vector3((float)-25, (float)46, (float)0);

            }

            float xColl = boxCollider.offset.x;
            float yColl = boxCollider.offset.y;
            boxCollider.offset = new Vector2(xColl, yColl - 7);
        }
    }

    public  void addDownBetween(GameObject obj)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(downInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.GetComponent<downInBar>().setb2(this.gameObject);

            g.name = "d" + counter4SoftwreClibs;
            counter4SoftwreClibs++;
            g.layer = 6;


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

    //              LEFT             //
    public void addLeft()
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(leftInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.GetComponent<leftInBar>().setb2(this.gameObject);

            if (objects.Count > 0)
            {
                GameObject previos = getFromObjects(objects.Count - 1);
                g.name = "l" + counter4SoftwreClibs;
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
                g.name = "l" + counter4SoftwreClibs;
                counter4SoftwreClibs++;
                g.layer = 6;
                addtoObjects(g);
                g.GetComponent<RectTransform>().localPosition = new Vector3((float)-25, (float)46, (float)0);

            }

            float xColl = boxCollider.offset.x;
            float yColl = boxCollider.offset.y;
            boxCollider.offset = new Vector2(xColl, yColl - 7);
        }
    }

    public void addLeftBetween(GameObject obj)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(leftInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.name = "l" + counter4SoftwreClibs;
            g.GetComponent<leftInBar>().setb2(this.gameObject);

            counter4SoftwreClibs++;
            g.layer = 6;


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

    //              RIGHT                //

    public  void addRight()
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(rightInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.GetComponent<rightInBar>().setb2(this.gameObject);

            if (objects.Count > 0)
            {
                GameObject previos = getFromObjects(objects.Count - 1);
                g.name = "r" + counter4SoftwreClibs;
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
                g.name = "r" + counter4SoftwreClibs;
                counter4SoftwreClibs++;
                g.layer = 6;
                addtoObjects(g);
                g.GetComponent<RectTransform>().localPosition = new Vector3((float)-25, (float)46, (float)0);

            }

            float xColl = boxCollider.offset.x;
            float yColl = boxCollider.offset.y;
            boxCollider.offset = new Vector2(xColl, yColl - 7);
        }
    }

    public void addRightBetween(GameObject obj)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(rightInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.GetComponent<rightInBar>().setb2(this.gameObject);

            g.name = "r" + counter4SoftwreClibs;
            counter4SoftwreClibs++;
            g.layer = 6;


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

    public void addFor()
    {

        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(ForInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.GetComponent<forInBar>().setb2(this.gameObject);

            if (objects.Count > 0)
            {
                GameObject previos = getFromObjects(objects.Count - 1);
                g.name = "f" + counter4SoftwreClibs;
                counter4SoftwreClibs++;
                addtoObjects(g);
                float x = previos.GetComponent<RectTransform>().localPosition.x;
                float y = previos.GetComponent<RectTransform>().localPosition.y;
                float z = previos.GetComponent<RectTransform>().localPosition.z;
                g.GetComponent<RectTransform>().localPosition = new Vector3((float)x, (float)y - 7, (float)z);

            }
            else
            {
                g.name = "f" + counter4SoftwreClibs;
                counter4SoftwreClibs++;
                g.layer = 6;
                addtoObjects(g);
                g.GetComponent<RectTransform>().localPosition = new Vector3((float)-25, (float)46, (float)0);

            }

            float xColl = boxCollider.offset.x;
            float yColl = boxCollider.offset.y;
            boxCollider.offset = new Vector2(xColl, yColl - 7);
        }
    }


    public void addForBetween(GameObject obj)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(ForInBar);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform);
            g.transform.localScale = new Vector3((float)0.27, (float)0.11, (float)1);
            g.GetComponent<forInBar>().setb2(this.gameObject);

            g.name = "f" + counter4SoftwreClibs;
            counter4SoftwreClibs++;
            g.layer = 6;


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
        return point.x < -50 ? true : false;
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

        float xColl = boxCollider.offset.x;
        float yColl = boxCollider.offset.y;
        boxCollider.offset = new Vector2(xColl, yColl + 7);
    }





    // if i drag the object to the last of objects
    public bool isInside(Vector2 point)
    {
        return point == this.gameObject.GetComponent<Collider2D>().ClosestPoint(point) ? true : false;
    }

    public GameObject isInsideAClibs(Vector2 point)
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























    /////////////////// Add To For ////////////////////////

    public GameObject isInsideForBody(Vector2 point)
    {

        for (int i = 0; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            if (temp.name.Contains("f"))
            {
                if (point == temp.GetComponent<forInBar>().getCollider4ForBody().GetComponent<Collider2D>().ClosestPoint(point) &&
                    temp.GetComponent<forInBar>().getCanWork())
                {
                    return temp;
                }

            }
        }
        return null;
    }

    public bool isInsideAForClibsAndAddIt(Vector2 point, string type)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            GameObject obj;
            if (temp.name.Contains("f") && (obj = temp.GetComponent<forInBar>().isInsideAForClibs(point)) != null &&
                    temp.GetComponent<forInBar>().getCanWork())
            {
                if (type.Equals("up"))
                {
                    temp.GetComponent<forInBar>().addUp2ForbetweenClibs(obj);
                }else if (type.Equals("down"))
                {
                    temp.GetComponent<forInBar>().addDown2ForbetweenClibs(obj);
                }
                else if (type.Equals("left"))
                {
                    temp.GetComponent<forInBar>().addLeft2ForbetweenClibs(obj);
                }
                else if (type.Equals("right"))
                {
                    temp.GetComponent<forInBar>().addRight2ForbetweenClibs(obj);
                }
                return true;
            }
        }
        return false;
    }


    public void addUpInForBody(GameObject obj)
    {
        GameObject g = (GameObject)objects[objects.IndexOf(obj)];
        g.GetComponent<forInBar>().addUp2For(g.gameObject.name);
    }

    public void addRightInForBody(GameObject obj)
    {
        GameObject g = (GameObject)objects[objects.IndexOf(obj)];
        g.GetComponent<forInBar>().addRight2For(g.gameObject.name);
    }

    public void addLeftInForBody(GameObject obj)
    {
        GameObject g = (GameObject)objects[objects.IndexOf(obj)];
        g.GetComponent<forInBar>().addLeft2For(g.gameObject.name);
    }

    public void addDownInForBody(GameObject obj)
    {
        GameObject g = (GameObject)objects[objects.IndexOf(obj)];
        g.GetComponent<forInBar>().addDown2For(g.gameObject.name);
    }

}
