using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossEffect : MonoBehaviour
{
    public TopDownMovement topDownMovement;
    public GameObject crossEnabledRange;
    public Animator animator;

    //Audio 
    public AudioSourceCross audioSourceCross;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CrossEnabledRange"))
        {
            audioSourceCross.areaCross();

            topDownMovement.shadowSpeed = 1;
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
