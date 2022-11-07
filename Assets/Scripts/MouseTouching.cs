using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTouching : MonoBehaviour
{
    public Transform touchedObject;
    public Transform Mouse;
    
    void Update()
    {
        if(Mouse.transform == touchedObject.transform)
        {
            Debug.Log("LMAO");
        }
    }
}
