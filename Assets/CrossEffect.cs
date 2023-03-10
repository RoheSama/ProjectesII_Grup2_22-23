using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossEffect : MonoBehaviour
{
    public TopDownMovement topDownMovement;
    public GameObject crossEnabledRange;
    public Animator animator;

    //Audio 
    public AudioSourceCross[] audioSourceCrosses;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CrossEnabledRange"))
        {
            for(int i = 0;i < audioSourceCrosses.Length;i++)
            {
                audioSourceCrosses[i].areaCross();
            }
            topDownMovement.shadowSpeed = 4;
            crossEnabledRange = other.gameObject;
            animator = crossEnabledRange.transform.parent.GetComponent<Animator>();
            animator.SetBool("CanShine", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CrossEnabledRange"))
        {
            crossEnabledRange = other.gameObject;
            animator = crossEnabledRange.transform.parent.GetComponent<Animator>();
            animator.SetBool("CanShine", false);
        }
    }
}
