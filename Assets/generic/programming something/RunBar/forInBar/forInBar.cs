using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forInBar : MonoBehaviour
{
    [SerializeField] GameObject upInFor;
    [SerializeField] GameObject downInFor;
    [SerializeField] GameObject leftInFor;
    [SerializeField] GameObject rightInFor;
    bool canMove;
    bool dragging;
    BoxCollider2D upCollider;

    private GameObject Body;
    private GameObject forBody;
    private GameObject collider4ForBody;
    private ArrayList objects = new ArrayList();
    int counter4SoftwreClibs = 0;

    private bool canWork = false;
    public GameObject getForBody()
    {
        return forBody;
    }

    public GameObject getCollider4ForBody()
    {
        return collider4ForBody;
    }
    public void setCanWork(bool canWork)
    {
        this.canWork = canWork;
    }

    public bool getCanWork()
    {
        return canWork;
    }

    void Start()
    {
        Body = transform.Find("Body").gameObject;
        forBody = transform.Find("Body").gameObject.transform.Find("ForBody").gameObject;
        collider4ForBody = transform.Find("Body").gameObject.transform.Find("collider4ForBody").gameObject;
        upCollider = GetComponent<BoxCollider2D>();
        canMove = false;
        dragging = false;
        canWork = false;
        ActiveForBody(false);
    }



    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {

            if (upCollider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = this.transform;
            }
            else
            {
                canMove = false;
            }

            if (canMove) { dragging = true; }
        }

        if (dragging)
        {

            this.transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            if (dragging)
            {
                var barScript = this.transform.parent.GetComponent<bar2>();
                float x = this.GetComponent<RectTransform>().localPosition.x;
                float y = this.GetComponent<RectTransform>().localPosition.y;
                Vector2 v = new Vector2(x, y);
                GameObject temp;
                if (barScript.canRemove(v) && dragging)
                {
                    barScript.removeFromObjects(this.gameObject);
                    Destroy(this.gameObject);
                    dragging = false;

                }
                if (barScript.isInside(v) && dragging)
                {
                    barScript.changeObjectPosition(this.gameObject);
                    dragging = false;
                }
                if ((temp = barScript.isInsideAClibs4InBarClibs(this.gameObject)) && dragging)
                {

                    barScript.changeObjectPositionbetweenClibs(this.gameObject, temp);
                    dragging = false;

                }
                if (dragging)
                {
                    barScript.makeItAsDefault(this.gameObject);
                    if (Body.active == false)
                    {
                        ActiveForBody(true);
                        canWork = true;
                    }
                    else
                    {
                        ActiveForBody(false);
                        canWork = false;
                    }
                    dragging = false;
                }
            }

           GameObject button =  this.transform.Find("header").gameObject.transform.Find("num").gameObject;
           button.GetComponent<num>().setMaxNum(3);

        }
        
    }

    public void addUp2For(string name)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(upInFor);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
            g.transform.localScale = new Vector3((float)0.95, (float)0.95, (float)1);
            g.name = name + "u" + counter4SoftwreClibs++;
            AddIt(g);
            repairObjectView();
        }
    }

    public void addUp2ForbetweenClibs(GameObject obj)
    {
        if (counter4SoftwreClibs < 11 )
        {
            GameObject g = Instantiate(upInFor);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
            g.transform.localScale = new Vector3((float)0.95, (float)0.95, (float)1);
            g.name = name + "u" + counter4SoftwreClibs++;
            AddItBetweenCLibs(obj, g);
            repairObjectView();

        }
    }


    public void addDown2For(string name)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(downInFor);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
            g.transform.localScale = new Vector3((float)0.95, (float)0.95, (float)1);
            g.name = name + "d" + counter4SoftwreClibs++;
            AddIt(g);
            repairObjectView();
        }
    }

    public void addDown2ForbetweenClibs(GameObject obj)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(downInFor);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
            g.transform.localScale = new Vector3((float)0.95, (float)0.95, (float)1);
            g.name = name + "d" + counter4SoftwreClibs++;
            AddItBetweenCLibs(obj, g);
            repairObjectView();

        }
    }


    public void addLeft2For(string name)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(leftInFor);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
            g.transform.localScale = new Vector3((float)0.95, (float)0.95, (float)1);
            g.name = name + "l" + counter4SoftwreClibs++;
            AddIt(g);
            repairObjectView();
        }
    }

    public void addLeft2ForbetweenClibs(GameObject obj)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(leftInFor);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
            g.transform.localScale = new Vector3((float)0.95, (float)0.95, (float)1);
            g.name = name + "l" + counter4SoftwreClibs++;
            AddItBetweenCLibs(obj, g);
            repairObjectView();

        }
    }


    public void addRight2For(string name)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(rightInFor);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
            g.transform.localScale = new Vector3((float)0.95, (float)0.95, (float)1);
            g.name = name + "r" + counter4SoftwreClibs++;
            AddIt(g);
            repairObjectView();
        }
    }

    public void addRight2ForbetweenClibs(GameObject obj)
    {
        if (counter4SoftwreClibs < 11)
        {
            GameObject g = Instantiate(rightInFor);
            g.AddComponent<RectTransform>();
            g.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
            g.transform.localScale = new Vector3((float)0.95, (float)0.95, (float)1);
            g.name = name + "r" + counter4SoftwreClibs++;
            AddItBetweenCLibs(obj, g);
            repairObjectView();

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
        if(point.x < -88 || point.x > 88)
        {
            return true;
        }
        return false;
    }
    public void removeFromObjects(GameObject g)
    {

        for (int i = objects.IndexOf(g) + 1; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            float x = temp.GetComponent<RectTransform>().localPosition.x;
            float y = temp.GetComponent<RectTransform>().localPosition.y;
            float z = temp.GetComponent<RectTransform>().localPosition.z;
            temp.GetComponent<RectTransform>().localPosition = new Vector3(x, y + 60, z);
        }
        objects.Remove(g);
        counter4SoftwreClibs--;
        float xBack = forBody.GetComponent<RectTransform>().localPosition.x;
        float yBack = forBody.GetComponent<RectTransform>().localPosition.y;
        float zBack = forBody.GetComponent<RectTransform>().localPosition.z;

        forBody.GetComponent<RectTransform>().localPosition = new Vector3(xBack, yBack + (float)30, zBack);

        float xBackS = forBody.GetComponent<RectTransform>().localScale.x;
        float yBackS = forBody.GetComponent<RectTransform>().localScale.y;
        float zBackS = forBody.GetComponent<RectTransform>().localScale.z;
        forBody.GetComponent<RectTransform>().localScale = new Vector3(xBackS, yBackS - (float)0.6, zBackS);

        BoxCollider2D boxCollider = collider4ForBody.GetComponent<BoxCollider2D>();
        float xColl = boxCollider.offset.x;
        float yColl = boxCollider.offset.y;
        boxCollider.offset = new Vector2(xColl, yColl + 100);
    }

    public bool isInside(Vector2 point)
    {
        if (point == collider4ForBody.GetComponent<Collider2D>().ClosestPoint(point))
        {
            return true;
        }

        return false;
    }
    public void changeObjectPosition(GameObject obj)
    {
        for (int i = objects.IndexOf(obj) + 1; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            float x = temp.GetComponent<RectTransform>().localPosition.x;
            float y = temp.GetComponent<RectTransform>().localPosition.y;
            float z = temp.GetComponent<RectTransform>().localPosition.z;
            temp.GetComponent<RectTransform>().localPosition = new Vector3(x, y + 60, z);
        }
        objects.Remove(obj);

        if (objects.Count > 0)
        {
            GameObject temp1 = (GameObject)objects[objects.Count - 1];
            float x1 = temp1.GetComponent<RectTransform>().localPosition.x;
            float y1 = temp1.GetComponent<RectTransform>().localPosition.y;
            float z1 = temp1.GetComponent<RectTransform>().localPosition.z;
            obj.GetComponent<RectTransform>().localPosition = new Vector3(x1, y1 - 60, z1);
        }
        else
        {
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)0, (float)0, (float)0);
        }
        objects.Add(obj);
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
                temp.GetComponent<RectTransform>().localPosition = new Vector3((float)x, (float)y + 60, (float)z);
            }
            objects.Remove(obj);

            GameObject temp2 = (GameObject)objects[objects.IndexOf(obj2)];
            float x1 = temp2.GetComponent<RectTransform>().localPosition.x;
            float y1 = temp2.GetComponent<RectTransform>().localPosition.y;
            float z1 = temp2.GetComponent<RectTransform>().localPosition.z;
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)x1, (float)y1 - 60, (float)z1);
            objects.Insert(objects.IndexOf(obj2) + 1, obj);
        }
        else if (i - 1 > objects.IndexOf(obj2))
        {
            i -= 2;
            for (; i >= objects.IndexOf(obj2); i--)
            {
                GameObject temp = (GameObject)objects[i];
                float x = temp.GetComponent<RectTransform>().localPosition.x;
                float y = temp.GetComponent<RectTransform>().localPosition.y;
                float z = temp.GetComponent<RectTransform>().localPosition.z;
                temp.GetComponent<RectTransform>().localPosition = new Vector3((float)x, (float)y - 60, (float)z);
            }
            objects.Remove(obj);

            GameObject temp2 = (GameObject)objects[objects.IndexOf(obj2)];
            float x1 = temp2.GetComponent<RectTransform>().localPosition.x;
            float y1 = temp2.GetComponent<RectTransform>().localPosition.y;
            float z1 = temp2.GetComponent<RectTransform>().localPosition.z;
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)x1, (float)y1 + 60, (float)z1);
            objects.Insert(objects.IndexOf(obj2), obj);

        }
    }


    public void makeItAsDefault(GameObject obj)
    {
        int count = objects.Count;
        int i = objects.IndexOf(obj);
        if (i > 0)
        {
            GameObject temp = (GameObject)objects[i - 1];
            float y = temp.GetComponent<RectTransform>().localPosition.y;
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)0, y - 60, (float)0);
        }
        else if (i == 0)
        {
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)0, (float)0, (float)0);

        }
    }

    public GameObject isInsideAForClibs(Vector2 point)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            if (point == temp.GetComponent<Collider2D>().ClosestPoint(point))
            {
                return temp;
            }
        }
        return null;
    }

    public void ActiveForBody(bool active)
    {
        Body.SetActive(active);
    }


    private void AddIt(GameObject obj)
    {
        if (objects.Count > 0)
        {
            GameObject previos = getFromObjects(objects.Count - 1);
            addtoObjects(obj);
            float x = previos.GetComponent<RectTransform>().localPosition.x;
            float y = previos.GetComponent<RectTransform>().localPosition.y;
            float z = previos.GetComponent<RectTransform>().localPosition.z;
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)x, (float)y - 60, (float)z);
        }
        else
        {
            addtoObjects(obj);
            obj.GetComponent<RectTransform>().localPosition = new Vector3((float)0, (float)0, (float)0);
        }
    }

    private void AddItBetweenCLibs(GameObject obj, GameObject g)
    {
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
            temp.GetComponent<RectTransform>().localPosition = new Vector3(x1, y1 - 60, z1);
        }
        objects.Insert(objects.IndexOf(obj), g);
    }


    private void repairObjectView()
    {
        float xBack = forBody.GetComponent<RectTransform>().localPosition.x;
        float yBack = forBody.GetComponent<RectTransform>().localPosition.y;
        float zBack = forBody.GetComponent<RectTransform>().localPosition.z;

        forBody.GetComponent<RectTransform>().localPosition = new Vector3(xBack, yBack - (float)30, zBack);

        float xBackS = forBody.GetComponent<RectTransform>().localScale.x;
        float yBackS = forBody.GetComponent<RectTransform>().localScale.y;
        float zBackS = forBody.GetComponent<RectTransform>().localScale.z;
        forBody.GetComponent<RectTransform>().localScale = new Vector3(xBackS, yBackS + (float)0.6, zBackS);




        BoxCollider2D boxCollider = collider4ForBody.GetComponent<BoxCollider2D>();
        float xColl = boxCollider.offset.x;
        float yColl = boxCollider.offset.y;
        boxCollider.offset = new Vector2(xColl, yColl - 100);
    }

}