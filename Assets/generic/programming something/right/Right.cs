using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{

    private static GameObject stDown;
    bool canMove;
    bool dragging;
    Vector3 basePos;

    BoxCollider2D collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        canMove = false;
        dragging = false;
        basePos = this.transform.position;
        stDown = this.gameObject;
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {

            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = transform;
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
            float x = this.GetComponent<RectTransform>().position.x;
            float y = this.GetComponent<RectTransform>().position.y;
            Vector2 v = new Vector2(x, y);
            GameObject objInList = bar2.isInsideAClibs(v);
            if (bar2.isInside(v) && dragging)
            {
                bar2.addRight();
            }
            else if (objInList != null && dragging)
            {
                bar2.addRightBetween(objInList);
            }




            this.transform.position = basePos;
            dragging = false;

        }

    }


}
