using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCheck : MonoBehaviour
{
    public Vector2 mousePosWorldSpace;
    public bool hasOverlappedObject = false;
    public GameObject overlappedObject;
    public PhoneDrawController phoneDrawController;
     
    void Update()
    {
        CheckIfOverlappingObject();
    }
      
    // Comprovar si el MouseCheck passa per sobre d' un collider d'un tag en concret i estàs fent click
    void CheckIfOverlappingObject()
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);

        Collider2D col = Physics2D.OverlapPoint(mousePosWorldSpace);
        if(col != null && col.tag == "Selectable" && Input.GetKey(KeyCode.Mouse0))
        {
            hasOverlappedObject = true;
            overlappedObject = col.gameObject;
        }
        else
        {
            hasOverlappedObject = false;
        }
    }
}
