using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{
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

            if(canMove) { dragging = true; }
        }

        if (dragging)
        {

            this.transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
            if(this.transform.position.x >= 1100)
            {
                bar2.addUp();
                Debug.Log(this.transform.position.x);
            }
            this.transform.position = basePos;
        }

    }

}
