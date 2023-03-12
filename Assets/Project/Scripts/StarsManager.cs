using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StarsManager : MonoBehaviour
{
    public Animator satanicStar02Animator;
    public Animator satanicStar01Animator;
    public VoidsLeft voidsLeft;
    public bool canStart2Stars = false;
    public bool canStart1Star = false;

    float timer;

    void Update()
    {
        if (canStart1Star && canStart2Stars == false)
        {
            satanicStar01Animator.SetBool("CanStartSatanicStar01", true);
        }

        if(voidsLeft.totalVoids <= 8 && canStart2Stars == false)
        {
            satanicStar01Animator.SetBool("CanStartSatanicStar01", false);
            canStart2Stars=true;
        }

        if (canStart2Stars)
        {
            timer += Time.deltaTime;
            if(timer<2)
            {
                satanicStar01Animator.SetBool("CanStartSatanicStar01", false);
                satanicStar02Animator.SetBool("CanStartSatanicStar02", false);
            }
           
            if(timer>2)
            {
                satanicStar01Animator.SetBool("CanStartSatanicStar01", true);
                satanicStar02Animator.SetBool("CanStartSatanicStar02", true);
            }
        }
    }
}
