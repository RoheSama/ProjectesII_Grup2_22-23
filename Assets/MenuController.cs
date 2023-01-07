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
    public GameObject cinematic;
    public GameObject title;
    public GameObject logo;
    public GameObject version;
    public GameObject panel;
    public GameObject skipCinematic;
    public float timer;
    bool activeTimer = false;

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            cinematic.SetActive(false);
            SceneManager.LoadScene("BigMap");
        }
        if(activeTimer)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 58)
        {
            SceneManager.LoadScene("BigMap");
        }
    }

    // Button de Play 
    public void StartGame()
    {

        FindObjectOfType<AudioManager>().Play("ClickSound");
        menuAnim.SetActive(false);
        cinematic.SetActive(true);
        mainMenu.SetActive(false);
        title.SetActive(false);
        version.SetActive(false);
        logo.SetActive(false);
        panel.SetActive(false);
        skipCinematic.SetActive(true);
        activeTimer= true;
        FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
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
