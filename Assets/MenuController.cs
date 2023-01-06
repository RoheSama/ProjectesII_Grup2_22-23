using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject controlsMenu;
    public GameObject menuAnim;
    
    
    // Button de Play 
    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        SceneManager.LoadScene("BigMap");
    }

    // Button de Options
    public void Options()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        optionsMenu.SetActive(true);
        controlsMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

    // Button de Controls
    public void Controls()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        controlsMenu.SetActive(true);
        optionsMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

    // Button de Back
    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }
    
    // Button de Exit
    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        Application.Quit();
    }
}
