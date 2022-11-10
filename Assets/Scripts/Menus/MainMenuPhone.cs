using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPhone : MonoBehaviour
{
    //Animator anim;
    public GameObject mainMenu;

    void Start()
    {
      //  anim = GetComponent<Animator>();
    }
    public void PowerButtonTouched()
    {
        Debug.Log("a");
       // anim.SetBool("powerButtonTouched", true);
        mainMenu.SetActive(true);
        // SceneManager.LoadScene("SampleScene")
    }
}
