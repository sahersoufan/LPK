using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downInIf : MonoBehaviour
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
            var ifScript = this.transform.parent.transform.parent.GetComponent<ifInBar>();

            canMove = false;
            GameObject temp;
            float xL = this.GetComponent<RectTransform>().localPosition.x;
            float yL = this.GetComponent<RectTransform>().localPosition.y;
            Vector2 vL = new Vector2(xL, yL);
            float xG = this.GetComponent<RectTransform>().position.x;
            float yG = this.GetComponent<RectTransform>().position.y;
            Vector2 vG = new Vector2(xG, yG);
            if (ifScript.canRemove(vL) && dragging)
            {
                ifScript.removeFromObjects(this.gameObject);
                Destroy(this.gameObject);
                dragging = false;
            }
            if (ifScript.isInside(vG) && dragging)
            {
                ifScript.changeObjectPosition(this.gameObject);
                dragging = false;
            }
            if ((temp = ifScript.isInsideAClibs4InBarClibs(this.gameObject)) && dragging)
            {
                ifScript.changeObjectPositionbetweenClibs(this.gameObject, temp);
                dragging = false;
            }

            if (dragging)
            {
                ifScript.makeItAsDefault(this.gameObject);
                dragging = false;
            }


            dragging = false;

        }


    }
}
