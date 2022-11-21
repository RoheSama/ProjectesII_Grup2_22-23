using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
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
        TargetsOrder();
    }

    void FirstTarget()
    {
        if (tabCounter == 0)
        {
            targetedElement = targetsInRange[0];
        }
    }

    void SecondTarget()
    {
        if (tabCounter == 1)
        {
            targetedElement = targetsInRange[1];
        }
    }

    void ThirdTarget()
    {
        if (tabCounter == 2)
        {
            targetedElement = targetsInRange[2];
        }
    }

    void UpdateTab()
    {
        if (Input.GetKeyDown("tab"))
        {
            if (tabCounter <= 2)
            {
                tabCounter++;
            }
            else if (tabCounter > 1)
            {
                tabCounter = 0;
            }
        }
    }

    void TargetsOrder()
    {
        if (targetsInRange[0] != null && targetsInRange[1] == null && targetsInRange[2] == null)
        {
            tabCounter = 0;
        }
        if (targetsInRange[0] == null && targetsInRange[1] != null && targetsInRange[2] == null)
        {
            tabCounter = 1;
        }
        if (targetsInRange[0] == null && targetsInRange[1] == null && targetsInRange[2] != null)
        {
            tabCounter = 2;
        }
    }
}