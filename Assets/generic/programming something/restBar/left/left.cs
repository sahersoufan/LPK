using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
{
    private GameObject b2;

    private static GameObject stDown;
    bool canMove;
    bool dragging;
    Vector3 basePos;

    BoxCollider2D leftCollider;

    private void Start()
    {
        b2 = this.transform.parent.parent.parent.Find("bar2").gameObject;
        leftCollider = GetComponent<BoxCollider2D>();
        canMove = false;
        dragging = false;
        basePos = this.transform.localPosition;
        stDown = this.gameObject;
    }

    void Update()
    {

        var barScript = b2.GetComponent<bar2>();

        float x = this.GetComponent<RectTransform>().position.x;
        float y = this.GetComponent<RectTransform>().position.y;
        Vector2 v = new Vector2(x, y);
        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {

            if (leftCollider == Physics2D.OverlapPoint(mousePos))
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

            if (dragging)
            {
                GameObject temp;
                if (barScript.isInside(v) && dragging)
                {
                    barScript.addLeft();
                    dragging = false;
                }
                if (dragging && (temp = barScript.isInsideAClibs(v)) != null)
                {
                    barScript.addLeftBetween(temp);
                    dragging = false;
                }
                if ((temp = barScript.isInsideForBody(v)) != null && dragging)
                {
                    barScript.addLeftInForBody(temp);
                    dragging = false;
                }

                if (barScript.isInsideAForClibsAndAddIt(v, "left") && dragging)
                {
                    dragging = false;
                }
                this.transform.localPosition = basePos;
                dragging = false;
            }
        }

    }



}
