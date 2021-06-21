using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downInFor : MonoBehaviour
{
    bool canMove;
    bool dragging;
    BoxCollider2D downCollider;



    void Start()
    {
        downCollider = GetComponent<BoxCollider2D>();
        canMove = false;
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {

            if (downCollider == Physics2D.OverlapPoint(mousePos))
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
            var ForScript = this.transform.parent.transform.parent.GetComponent<forInBar>();

            canMove = false;
            GameObject temp;
            float xL = this.GetComponent<RectTransform>().localPosition.x;
            float yL = this.GetComponent<RectTransform>().localPosition.y;
            Vector2 vL = new Vector2(xL, yL);
            float xG = this.GetComponent<RectTransform>().position.x;
            float yG = this.GetComponent<RectTransform>().position.y;
            Vector2 vG = new Vector2(xG, yG);
            if (ForScript.canRemove(vL) && dragging)
            {
                ForScript.removeFromObjects(this.gameObject);
                Destroy(this.gameObject);
                dragging = false;
            }
            if (ForScript.isInside(vG) && dragging)
            {
                ForScript.changeObjectPosition(this.gameObject);
                dragging = false;
            }
            if ((temp = ForScript.isInsideAClibs4InBarClibs(this.gameObject)) && dragging)
            {
                ForScript.changeObjectPositionbetweenClibs(this.gameObject, temp);
                dragging = false;
            }

            if (dragging)
            {
                ForScript.makeItAsDefault(this.gameObject);
                dragging = false;
            }


            dragging = false;

        }


    }
}
