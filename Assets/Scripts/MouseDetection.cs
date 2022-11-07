using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    public Vector2 mousePosWorldSpace;
    public GameObject touchedObject;
    void Update()
    {
        MouseCoords();
    }
    void MouseCoords()
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);

       // x = mousePosWorldSpace.x;
       // y = mousePosWorldSpace.y;

       // return x;
    }
}