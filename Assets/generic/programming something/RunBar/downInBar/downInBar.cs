using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downInBar : MonoBehaviour
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
                    dragging = false;
                }

            }
        }


    }
}
