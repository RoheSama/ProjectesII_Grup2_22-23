using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPhone : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void PowerButtonTouched()
    {
        Debug.Log("a");
        anim.SetBool("powerButtonTouched", true);
        // SceneManager.LoadScene("SampleScene");
    }
}
