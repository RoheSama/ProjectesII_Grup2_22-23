using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject target1 = null;
    public GameObject target2;
    public GameObject target3;

    public bool a = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(target1 != null)
        {
            target1.SetActive(false);
        }
    }
}
