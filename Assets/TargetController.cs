using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject target1 = null;
    public GameObject target2 = null;
    public GameObject target3 = null;

    public GameObject targetedElement = null;


    void Start()
    {
        
    }

    void Update()
    {
        if(target1 != null)
        {
            targetedElement = target1;
        }

        
    }
}
