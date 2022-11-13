using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPhone : MonoBehaviour
{
    Animator anim;
    public bool phoneIsActive = false;
    public GameObject triggers;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Desplegar el telèfon
    public void ShowPhoneFuntion()
    {
        anim.SetBool("canShowPhone", true);
        phoneIsActive = true;
    }

    // Amagar el telèfon
    public void HidePhoneFuntion()
    {
        anim.SetBool("canShowPhone", false);
        phoneIsActive = false;
    }
}