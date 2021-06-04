using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upInBar : MonoBehaviour
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
            dragging = false;
            if (this.transform.position.x < 1100)
            {
                Destroy(this.gameObject);
                bar2.removeFromObjects(this.gameObject);
            }
        }

    }
}
