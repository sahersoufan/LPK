using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForScript : MonoBehaviour
{
    private GameObject b2;
    bool canMove;
    bool dragging;
    Vector3 basePos;

    BoxCollider2D upCollider;

    private void Start()
    {
        b2 = this.transform.parent.parent.parent.Find("bar2").gameObject;
        upCollider = GetComponent<BoxCollider2D>();
        canMove = false;
        dragging = false;
        basePos = this.transform.localPosition;
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

            if (upCollider == Physics2D.OverlapPoint(mousePos))
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
                if (barScript.isInsideEverythingAndAddIt(v, "for") && dragging)
                {
                    dragging = false;
                }
                this.transform.localPosition = basePos;
                dragging = false;
            }
        }

    }


}
