using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    // public GameObject target1 = null;
    // public GameObject target2 = null;
    // public GameObject target3 = null;

    public GameObject[] targetsInRange;

    public GameObject targetedElement = null;

    int tabCounter = 0;


    void Start()
    {
        
    }

    void Update()
    {
        UpdateTab();
        FirstTarget();
        SecondTarget();
        ThirdTarget();
    }

    void FirstTarget()
    {
        if (tabCounter == 1)
        {
            targetedElement = targetsInRange[0];
        }    
    }

    void SecondTarget()
    {
        if (tabCounter == 2)
        {
            targetedElement = targetsInRange[1];
        }
    }

    void ThirdTarget()
    {
        if (tabCounter == 3)
        {
            targetedElement = targetsInRange[2];
        }
    }

    void UpdateTab()
    {
        if (Input.GetKeyDown("tab"))
        {
            tabCounter++;
        }
          
    }

}
