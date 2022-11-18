using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPhone : MonoBehaviour
{
    Animator anim;
    public bool phoneIsActive = false;
    public GameObject triggers;
    bool canShowPhone = true;
    bool canHidePhone = true;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ShowOrHidePhone();
    }

    // Desplegar i amagar telèfon
   void ShowOrHidePhone()
    {
        if (Input.GetKeyDown("space"))
        {
            if (phoneIsActive == false && canShowPhone)
            {
                anim.SetBool("canShowPhone", true);
                phoneIsActive = true;
            }
            else if (phoneIsActive && canHidePhone)
            {
                anim.SetBool("canShowPhone", false);
                phoneIsActive = false;
            }
        }
    }
}