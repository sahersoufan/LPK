using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifInBar : MonoBehaviour
{
    [SerializeField] GameObject upInIf;
    [SerializeField] GameObject downInIf;
    [SerializeField] GameObject leftInIf;
    [SerializeField] GameObject rightInIf;
    [SerializeField] GameObject forInIf;
    bool canMove;
    bool dragging;
    BoxCollider2D upCollider;

    private GameObject Body;
    private GameObject ifBody;
    private GameObject collider4IfBody;
    private ArrayList objects = new ArrayList();
    int counter4SoftwreClibs = 0;

    private bool canWork = false;
    public GameObject getIfBody()
    {
        return ifBody;
    }

    public GameObject getCollider4IfBody()
    {
        return collider4IfBody;
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
        ifBody = transform.Find("Body").gameObject.transform.Find("ifBody").gameObject;
        collider4IfBody = transform.Find("Body").gameObject.transform.Find("collider4IfBody").gameObject;
        upCollider = GetComponent<BoxCollider2D>();
        canMove = false;
        dragging = false;
        canWork = false;
        ActiveIfBody(false);
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

                if (dragging)
                {
                    canMove = false;
                    float xL = this.GetComponent<RectTransform>().localPosition.x;
                    float yL = this.GetComponent<RectTransform>().localPosition.y;
                    Vector2 vL = new Vector2(xL, yL);
                    float xG = this.GetComponent<RectTransform>().position.x;
                    float yG = this.GetComponent<RectTransform>().position.y;
                    Vector2 vG = new Vector2(xG, yG);

                    if (gameObject.name.Equals("if") && this.transform.parent.name.Equals("bar2"))
                    {
                        var barScript = this.transform.parent.GetComponent<bar2>();
                        GameObject temp;
                        if (barScript.canRemove(vL) && dragging)
                        {
                            barScript.removeFromObjects(this.gameObject);
                            Destroy(this.gameObject);
                            dragging = false;

                        }
                        if (barScript.isInside(vG) && dragging)
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
                                ActiveIfBody(true);
                                canWork = true;
                            }
                            else
                            {
                                ActiveIfBody(false);
                                canWork = false;
                                serachInChildsAndCloseIt();

                            }
                            dragging = false;
                        }
                    }
                    else/* if (this.transform.parent.transform.parent.gameObject.name.Equals("for"))*/
                    {
                        var barScript = this.transform.parent.transform.parent.GetComponent<forInBar>();
                        GameObject temp;
                        if (barScript.canRemove(vL) && dragging)
                        {
                            barScript.removeFromObjects(this.gameObject);
                            Destroy(this.gameObject);
                            dragging = false;

                        }
                        if (barScript.isInside(vG) && dragging)
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
                                ActiveIfBody(true);
                                canWork = true;
                            }
                            else
                            {
                                ActiveIfBody(false);
                                canWork = false;
                            }
                            dragging = false;
                        }
                    }
                }

            }

        }

    }

    public void addUp2If()
    {
            GameObject g = Instantiate(upInIf);
        g.name = "up";
            AddIt(g);
            repairObjectView();
    }

    public void addUp2IfbetweenClibs(GameObject obj)
    {
            GameObject g = Instantiate(upInIf);
        g.name = "up";
            AddItBetweenCLibs(obj, g);
            repairObjectView();
    }


    public void addDown2If()
    {
            GameObject g = Instantiate(downInIf);
        g.name = "down";
            AddIt(g);
            repairObjectView();
    }

    public void addDown2IfbetweenClibs(GameObject obj)
    {
            GameObject g = Instantiate(downInIf);
        g.name = "down";
            AddItBetweenCLibs(obj, g);
            repairObjectView();
    }


    public void addLeft2If()
    {
            GameObject g = Instantiate(leftInIf);
        g.name = "left";
            AddIt(g);
            repairObjectView();
    }

    public void addLeft2IfbetweenClibs(GameObject obj)
    {
            GameObject g = Instantiate(leftInIf);
        g.name = "left";
            AddItBetweenCLibs(obj, g);
            repairObjectView();
    }


    public void addRight2If()
    {
            GameObject g = Instantiate(rightInIf);
        g.name = "right";
            AddIt(g);
            repairObjectView();
    }

    public void addRight2IfbetweenClibs(GameObject obj)
    {
            GameObject g = Instantiate(rightInIf);
        g.name = "right";
            AddItBetweenCLibs(obj, g);
            repairObjectView();
    }

    public void addFor2If()
    {
            GameObject g = Instantiate(forInIf);
        g.name = "for";
            AddIt(g);
            repairObjectView();
    }

    public void addFor2IfbetweenClibs(GameObject obj)
    {
            GameObject g = Instantiate(forInIf);
        g.name = "for";
            AddItBetweenCLibs(obj, g);
            repairObjectView();
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
        if (point.x < -88 || point.x > 88)
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
        float xBack = ifBody.GetComponent<RectTransform>().localPosition.x;
        float yBack = ifBody.GetComponent<RectTransform>().localPosition.y;
        float zBack = ifBody.GetComponent<RectTransform>().localPosition.z;

        ifBody.GetComponent<RectTransform>().localPosition = new Vector3(xBack, yBack + (float)30, zBack);

        float xBackS = ifBody.GetComponent<RectTransform>().localScale.x;
        float yBackS = ifBody.GetComponent<RectTransform>().localScale.y;
        float zBackS = ifBody.GetComponent<RectTransform>().localScale.z;
        ifBody.GetComponent<RectTransform>().localScale = new Vector3(xBackS, yBackS - (float)0.6, zBackS);

        BoxCollider2D boxCollider = collider4IfBody.GetComponent<BoxCollider2D>();
        float xColl = boxCollider.offset.x;
        float yColl = boxCollider.offset.y;
        boxCollider.offset = new Vector2(xColl, yColl + 100);
    }

    // add any object to if
    public bool isInsideEverythingAndAddIt(Vector3 point, string name, int counter)
    {
        Vector2 Point2D = new Vector2(point.x, point.y);
        if (Point2D == collider4IfBody.GetComponent<Collider2D>().ClosestPoint(Point2D) && getCanWork() && counter4SoftwreClibs < counter + 1)
        {
            if (name.Equals("up"))
            {
                addUp2If();
            }
            else if (name.Equals("down"))
            {
                addDown2If();
            }
            else if (name.Equals("right"))
            {
                addRight2If();
            }
            else if (name.Equals("left"))
            {
                addLeft2If();
            }
            else if (name.Equals("for") && this.name.Length < 4 )
            {
                addFor2If();
            }
            return true;
        }

        ArrayList tempObjects = new ArrayList();
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            if (Point2D == temp.GetComponent<Collider2D>().ClosestPoint(Point2D) && getCanWork() && counter4SoftwreClibs < counter + 1)
            {
                if (name.Equals("up"))
                {
                    addUp2IfbetweenClibs(temp);
                }
                else if (name.Equals("down"))
                {
                    addDown2IfbetweenClibs(temp);
                }
                else if (name.Equals("right"))
                {
                    addRight2IfbetweenClibs(temp);

                }
                else if (name.Equals("left"))
                {
                    addLeft2IfbetweenClibs(temp);

                }
                else if (name.Equals("for") && this.name.Length < 4)
                {
                    addFor2IfbetweenClibs(temp);

                }
                return true;
            }

            if (temp.name.Equals("for"))
            {
                tempObjects.Add(temp);
            }
        }


        for (int i = 0; i < tempObjects.Count; i++)
        {
            GameObject temp = (GameObject)tempObjects[i];
            if (temp.GetComponent<forInBar>().isInsideEverythingAndAddIt(point, name, counter - (objects.IndexOf(temp))))
            {
                return true;
            }
        }


        return false;
    }



    public bool isInside(Vector2 point)
    {
        if (point == collider4IfBody.GetComponent<Collider2D>().ClosestPoint(point))
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




    private void AddIt(GameObject obj)
    {
        obj.AddComponent<RectTransform>();
        obj.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
        obj.transform.localScale = new Vector3((float)0.95, (float)0.95, (float)1);
        counter4SoftwreClibs++;
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
        g.AddComponent<RectTransform>();
        g.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
        g.transform.localScale = new Vector3((float)0.95, (float)0.95, (float)1);
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
            temp.GetComponent<RectTransform>().localPosition = new Vector3(x1, y1 - 60, z1);
        }
        objects.Insert(objects.IndexOf(obj), g);
    }


    private void repairObjectView()
    {
        float xBack = ifBody.GetComponent<RectTransform>().localPosition.x;
        float yBack = ifBody.GetComponent<RectTransform>().localPosition.y;
        float zBack = ifBody.GetComponent<RectTransform>().localPosition.z;

        ifBody.GetComponent<RectTransform>().localPosition = new Vector3(xBack, yBack - (float)30, zBack);

        float xBackS = ifBody.GetComponent<RectTransform>().localScale.x;
        float yBackS = ifBody.GetComponent<RectTransform>().localScale.y;
        float zBackS = ifBody.GetComponent<RectTransform>().localScale.z;
        ifBody.GetComponent<RectTransform>().localScale = new Vector3(xBackS, yBackS + (float)0.6, zBackS);




        BoxCollider2D boxCollider = collider4IfBody.GetComponent<BoxCollider2D>();
        float xColl = boxCollider.offset.x;
        float yColl = boxCollider.offset.y;
        boxCollider.offset = new Vector2(xColl, yColl - 100);
    }

    public void ActiveIfBody(bool active)
    {
        Body.SetActive(active);
    }

    void serachInChildsAndCloseIt()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            if (temp.name.Equals("for"))
            {
                temp.GetComponent<forInBar>().setCanWork(false);
                temp.GetComponent<forInBar>().ActiveForBody(false);
            }
        }
    }
}
