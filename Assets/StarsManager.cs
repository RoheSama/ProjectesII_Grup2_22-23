using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsManager : MonoBehaviour
{
    public Animator satanicStar02Animator;
    public VoidsLeft voidsLeft;

    void Update()
    {
        if(voidsLeft.totalVoids <= 8)
        {
            satanicStar02Animator.SetBool("CanStartSatanicStar02", true);
            satanicStar02Animator.SetBool("CanStartSatanicStar01", false);
        }
    }
}
