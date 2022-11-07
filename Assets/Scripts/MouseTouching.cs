using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTouching : MonoBehaviour
{
    public Vector2 mousePosWorldSpace;
    public Collider2D touchedObjectCollider;
    public Animator animator;

    void Update()
    {
        MouseCoords();
    }
    void MouseCoords()
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);
       
        if (touchedObjectCollider == Physics2D.OverlapPoint(mousePosWorldSpace))
        {
           animator.SetBool("startAnim", true);
        }
    }
}