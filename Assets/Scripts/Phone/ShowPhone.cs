using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPhone : MonoBehaviour
{
    Animator anim;

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
        anim.SetBool("canShowPhone", false);
    }
}
