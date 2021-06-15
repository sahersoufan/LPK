using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down : MonoBehaviour
{
    [SerializeField] GameObject b2;

    private static GameObject stDown;
    bool canMove;
    bool dragging;
    Vector3 basePos;

    BoxCollider2D downCollider;

    private void Start()
    {
        downCollider = GetComponent<BoxCollider2D>();
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

            if (downCollider == Physics2D.OverlapPoint(mousePos))
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

            if (barScript.isInside(v) && dragging)
            {
                barScript.addDown();
                dragging = false;
            }
            GameObject objInList;

            if (dragging && (objInList = barScript.isInsideAClibs(v)) != null)
            {
                barScript.addDownBetween(objInList);
                dragging = false;
            }
            GameObject ForObject;
            if ((ForObject = barScript.isInsideForBody(v)) != null && dragging)
            {
                barScript.addDownInForBody(ForObject);
                dragging = false;
            }
            if (barScript.isInsideAForClibsAndAddIt(v, "down") && dragging)
            {
                dragging = false;
            }


            this.transform.localPosition = basePos;
            dragging = false;

        }

    }



}
