using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upInFor : MonoBehaviour
{
    private GameObject For;
    bool canMove;
    bool dragging;
    BoxCollider2D upCollider;


    public void setFor(GameObject For)
    {
        this.For = For;
    }

    public GameObject getFor()
    {
        return this.gameObject;
    }



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
            var ForScript = For.GetComponent<forInBar>();

            canMove = false;
            GameObject temp;
            float x = this.GetComponent<RectTransform>().localPosition.x;
            float y = this.GetComponent<RectTransform>().localPosition.y;
            Vector2 v = new Vector2(x, y);
            if (ForScript.canRemove(v) && dragging)
            {
                ForScript.removeFromObjects(this.gameObject);
                Destroy(this.gameObject);
                dragging = false;
            }
            x = this.GetComponent<RectTransform>().position.x;
            y = this.GetComponent<RectTransform>().position.y;
            v = new Vector2(x, y);
            if (ForScript.isInside(v) && dragging)
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
