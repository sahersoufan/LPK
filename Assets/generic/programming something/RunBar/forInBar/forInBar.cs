using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forInBar : MonoBehaviour
{
    [SerializeField] GameObject upInFor;
    [SerializeField] GameObject downInFor;
    [SerializeField] GameObject leftInFor;
    [SerializeField] GameObject rightInFor;
    [SerializeField] GameObject ifInFor;
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

                if (dragging)
                {
                    canMove = false;
                    float xL = this.GetComponent<RectTransform>().localPosition.x;
                    float yL = this.GetComponent<RectTransform>().localPosition.y;
                    Vector2 vL = new Vector2(xL, yL);
                    float xG = this.GetComponent<RectTransform>().position.x;
                    float yG = this.GetComponent<RectTransform>().position.y;
                    Vector2 vG = new Vector2(xG, yG);

                    if (gameObject.name.Equals("for") && this.transform.parent.name.Equals("bar2"))
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
                                ActiveForBody(true);
                                canWork = true;
                            }
                            else
                            {
                                ActiveForBody(false);
                                canWork = false;
                                serachInChildsAndCloseIt();
                            }
                            dragging = false;
                        }
                    }else/* if (this.transform.parent.transform.parent.gameObject.name.Equals("if"))*/
                    {
                        var barScript = this.transform.parent.transform.parent.GetComponent<ifInBar>();
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
                }

            }

           GameObject button =  this.transform.Find("header").gameObject.transform.Find("num").gameObject;
           button.GetComponent<num>().setMaxNum(3);

        }
        
    }

    public void addUp2For()
    {
            GameObject g = Instantiate(upInFor);
        g.name = "up";
            AddIt(g);
            repairObjectView();
    }

    public void addUp2ForbetweenClibs(GameObject obj)
    {
            GameObject g = Instantiate(upInFor);
        g.name = "up";
            AddItBetweenCLibs(obj, g);
            repairObjectView();
    }


    public void addDown2For()
    {
            GameObject g = Instantiate(downInFor);
        g.name = "down";
            AddIt(g);
            repairObjectView();
    }

    public void addDown2ForbetweenClibs(GameObject obj)
    {
            GameObject g = Instantiate(downInFor);
        g.name = "down";
            AddItBetweenCLibs(obj, g);
            repairObjectView();
    }


    public void addLeft2For()
    {
            GameObject g = Instantiate(leftInFor);
        g.name = "left";
            AddIt(g);
            repairObjectView();
    }

    public void addLeft2ForbetweenClibs(GameObject obj)
    {
            GameObject g = Instantiate(leftInFor);
        g.name = "left";
            AddItBetweenCLibs(obj, g);
            repairObjectView();
    }


    public void addRight2For()
    {
            GameObject g = Instantiate(rightInFor);
        g.name = "right";
            AddIt(g);
            repairObjectView();
    }

    public void addRight2ForbetweenClibs(GameObject obj)
    {
            GameObject g = Instantiate(rightInFor);
        g.name = "right";
            AddItBetweenCLibs(obj, g);
            repairObjectView();
    }


    public void addIf2For()
    {
            GameObject g = Instantiate(ifInFor);
        g.name = "if";
            AddIt(g);
            repairObjectView();
    }

    public void addIf2ForbetweenClibs(GameObject obj)
    {
            GameObject g = Instantiate(ifInFor);
        g.name = "if";
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

    // add any object to for
    public bool isInsideEverythingAndAddIt(Vector3 point, string name, int counter)
    {
        Vector2 Point2D = new Vector2(point.x, point.y);
        if (Point2D == collider4ForBody.GetComponent<Collider2D>().ClosestPoint(Point2D) && 
            getCanWork() && 
            counter4SoftwreClibs < counter + 1)
        {

            if (name.Equals("up"))
            {
                addUp2For();
            }
            else if (name.Equals("down"))
            {
                addDown2For();
            }
            else if (name.Equals("right"))
            {
                addRight2For();
            }
            else if (name.Equals("left"))
            {
                addLeft2For();
            }
            else if (name.Equals("if") && this.name.Length < 4 )
            {
                addIf2For();
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
                    addUp2ForbetweenClibs(temp);
                }
                else if (name.Equals("down"))
                {
                    addDown2ForbetweenClibs(temp);
                }
                else if (name.Equals("right"))
                {
                    addRight2ForbetweenClibs(temp);

                }
                else if (name.Equals("left"))
                {
                    addLeft2ForbetweenClibs(temp);

                }
                else if (name.Equals("if") && this.name.Length < 4)
                {
                    addIf2ForbetweenClibs(temp);

                }
                return true;
            }

            if (temp.name.Equals("if"))
            {
                tempObjects.Add(temp);
            }
        }


        for (int i = 0; i < tempObjects.Count; i++)
        {
            GameObject temp = (GameObject)tempObjects[i];
            if (temp.GetComponent<ifInBar>().isInsideEverythingAndAddIt(point, name, counter - (objects.IndexOf(temp) )))
            {
                return true;
            }
        }


        return false;
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

    public void ActiveForBody(bool active)
    {
        Body.SetActive(active);
    }


    private void AddIt(GameObject obj)
    {
        obj.AddComponent<RectTransform>();
        obj.GetComponent<RectTransform>().SetParent(this.gameObject.transform.Find("Body"));
        obj.GetComponent<RectTransform>().localScale = new Vector3((float)0.95, (float)0.95, (float)1);
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
        g.GetComponent<RectTransform>().localScale = new Vector3((float)0.95, (float)0.95, (float)1);
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

    void serachInChildsAndCloseIt()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            GameObject temp = (GameObject)objects[i];
            if (temp.name.Equals("if"))
            {
                temp.GetComponent<ifInBar>().setCanWork(false);
                temp.GetComponent<ifInBar>().ActiveIfBody(false) ;
            }
        }
    }

}