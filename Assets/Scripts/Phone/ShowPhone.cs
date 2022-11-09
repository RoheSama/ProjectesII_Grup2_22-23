using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPhone : MonoBehaviour
{
    Animator anim;
    public bool phoneIsActive = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void ShowPhoneFuntion()
    {
        anim.SetBool("canShowPhone", true);
        phoneIsActive = true;
    }

    public void HidePhoneFuntion()
    {
        anim.SetBool("canShowPhone", false);
        phoneIsActive = false;
    }
}