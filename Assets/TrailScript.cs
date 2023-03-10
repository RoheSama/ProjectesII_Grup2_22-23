using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{

    public GameObject shadow;
    public TrailRenderer trailRenderer;

    void Update()
    {
        if(shadow.activeSelf)
        {
            trailRenderer.sortingOrder = 1;
        }
        else 
            trailRenderer.sortingOrder = -2;
    }
}
