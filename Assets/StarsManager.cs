using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsManager : MonoBehaviour
{
    public GameObject satanicStar02;
    public VoidsLeft voidsLeft;

    void Update()
    {
        if(voidsLeft.totalVoids == 5)
        {
            satanicStar02.SetActive(false);
        }
    }
}
