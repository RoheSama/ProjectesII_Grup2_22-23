using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPhone : MonoBehaviour
{
    Animator anim;
    public bool phoneIsActive = false;
    public GameObject triggers;

    //Momenatni pel prototip
    public AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void ShowPhoneFuntion()
    {
        anim.SetBool("canShowPhone", true);
        phoneIsActive = true;
        triggers.SetActive(false);
        audioSource.Play();
    }

    public void HidePhoneFuntion()
    {
        anim.SetBool("canShowPhone", false);
        phoneIsActive = false;
        triggers.SetActive(true);
        audioSource.Play();
    }
}