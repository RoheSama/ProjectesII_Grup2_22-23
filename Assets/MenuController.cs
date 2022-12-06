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
    public GameObject backButton;
    
    
    // Button de Play 
    public void StartGame()
    {
        SceneManager.LoadScene("Oficial ScenePRUEVAS");
    }

    // Button de Options
    public void Options()
    {  
        optionsMenu.SetActive(true);
        backButton.SetActive(true);
        menuAnim.SetActive(false);
        controlsMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

    // Button de Controls
    public void Controls()
    { 
        controlsMenu.SetActive(true);
        backButton.SetActive(true);
        optionsMenu.SetActive(false);
        menuAnim.SetActive(false);
        mainMenu.SetActive(false);
    }

    // Button de Back
    public void Back()
    {
        menuAnim.SetActive(true);
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        backButton.SetActive(false);
    }
    
    // Button de Exit
    public void ExitGame()
    {
        Application.Quit();
    }
}
