using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftInBar : MonoBehaviour
{
    private GameObject b2;

    bool canMove;
    bool dragging;

    BoxCollider2D leftCollider;

    void Start()
    {
        leftCollider = GetComponent<BoxCollider2D>();
        canMove = false;
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {

            if (leftCollider == Physics2D.OverlapPoint(mousePos))
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
            var barScript = b2.GetComponent<bar2>();

            canMove = false;
            float x = this.GetComponent<RectTransform>().position.x;
            float y = this.GetComponent<RectTransform>().position.y;
            Vector2 v = new Vector2(x, y);
            GameObject temp;

            if (this.transform.position.x < 1100 && dragging)
            {
                Destroy(this.gameObject);
                barScript.removeFromObjects(this.gameObject);
            }
            if (barScript.isInside(v) && dragging)
            {
                barScript.changeObjectPosition(this.gameObject);
            }
            else if ((temp = barScript.isInsideAClibs4InBarClibs(this.gameObject)) && dragging)
            {

                barScript.changeObjectPositionbetweenClibs(this.gameObject, temp);
            }
            else if (dragging)
            {
                barScript.makeItAsDefault(this.gameObject);
            }


            dragging = false;

        }


    }

    public void setb2(GameObject b2)
    {
        this.b2 = b2;
    }
}
