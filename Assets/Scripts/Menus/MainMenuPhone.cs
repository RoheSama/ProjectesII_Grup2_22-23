using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPhone : MonoBehaviour
{
    public GameObject mainMenu;
    public Animator animator;

    void Start()
    {

    }
    //Button de On 
    public void PowerButtonTouched()
    {
        mainMenu.SetActive(true);
        animator.SetBool("activateEyes", true);
    }

    // Button de Play 
    public void StartGame()
    {
        SceneManager.LoadScene("SchoolScene");
    }
    
    // Button de Exit
    public void ExitGame()
    {
        Application.Quit();
    }
}
