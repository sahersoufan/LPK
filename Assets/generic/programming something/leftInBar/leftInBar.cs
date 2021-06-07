using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftInBar : MonoBehaviour
{

    bool canMove;
    bool dragging;

    BoxCollider2D collider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        canMove = false;
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {

            if (collider == Physics2D.OverlapPoint(mousePos))
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
            float x = this.GetComponent<RectTransform>().position.x;
            float y = this.GetComponent<RectTransform>().position.y;
            Vector2 v = new Vector2(x, y);
            GameObject temp;

            if (this.transform.position.x < 1100 && dragging)
            {
                Destroy(this.gameObject);
                bar2.removeFromObjects(this.gameObject);
            }
            if (bar2.isInside(v) && dragging)
            {
                bar2.changeObjectPosition(this.gameObject);
            }
            else if ((temp = bar2.isInsideAClibs4InBarClibs(this.gameObject)) && dragging)
            {

                bar2.changeObjectPositionbetweenClibs(this.gameObject, temp);
            }
            else if (dragging)
            {
                bar2.makeItAsDefault(this.gameObject);
            }


            dragging = false;

        }


    }
}
