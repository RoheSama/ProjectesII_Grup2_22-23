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

    }
    public void PowerButtonTouched()
    {
        Debug.Log("a");
        mainMenu.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SchoolScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
