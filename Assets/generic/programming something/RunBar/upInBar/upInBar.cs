using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upInBar : MonoBehaviour
{
    bool canMove;
    bool dragging;
    BoxCollider2D upCollider;

  
    void Start()
    {

        upCollider = GetComponent<BoxCollider2D>();
        canMove = false;
        dragging = false;
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
            if (dragging)
            {
                canMove = false;
                float xL = this.GetComponent<RectTransform>().localPosition.x;
                float yL = this.GetComponent<RectTransform>().localPosition.y;
                Vector2 vL = new Vector2(xL, yL);
                float xG = this.GetComponent<RectTransform>().position.x;
                float yG = this.GetComponent<RectTransform>().position.y;
                Vector2 vG = new Vector2(xG, yG);

                if (gameObject.name.Equals("up") && this.transform.parent.name.Equals("bar2"))
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
                        dragging = false;
                    }
                }else if (this.transform.parent.transform.parent.gameObject.name.Equals("for"))
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
                        dragging = false;
                    }
                }
                else if (this.transform.parent.transform.parent.gameObject.name.Equals("if"))
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
                        dragging = false;
                    }
                }
            }

        }


    }
}
