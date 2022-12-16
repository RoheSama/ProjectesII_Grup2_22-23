using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPhone : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    // Button de Play 
    public void StartGame()
    {
        SceneManager.LoadScene("Oficial ScenePRUEVAS");
    }
    
    public void Options()
    {
        optionsMenu.SetActive(false);
    }

    // Button de Exit
    public void ExitGame()
    {
        Application.Quit();
    }
}
