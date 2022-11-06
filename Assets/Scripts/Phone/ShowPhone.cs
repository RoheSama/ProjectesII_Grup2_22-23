using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPhone : MonoBehaviour
{
    Animator anim;
    public GameObject buttons;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


   public void ShowPhoneFuntion()
    {
        anim.SetBool("canShowPhone", true);
    }
   public void HidePhoneFuntion()
    {
        if (buttons.active == true)
        {
            anim.SetBool("canShowPhone", false);
        } 
    }
}
