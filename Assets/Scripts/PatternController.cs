using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public Pattern pattern;
    public GameObject[] pins;
    public PhoneDrawController phoneDrawController;
    public MouseCheck mouseCheck;

    GameObject lastPin;

    void Start()
    {
     
    }

    
    void Update()
    {
        if (phoneDrawController.isDrawing && mouseCheck.overlappedObject == true)
        {
            for(int i = 0; i < pins.Length; i++)
            {
                if (pins[i]!= lastPin)
                {
                    lastPin = pins[i];
                    pins[i] = mouseCheck.overlappedObject;
 
                }
            }
            mouseCheck.overlappedObject.SetActive(false);
        }

       // else if (Input.GetKey(KeyCode.Mouse1))
       //  { 
             
        // }
    }
}


