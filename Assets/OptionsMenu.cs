using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject screenMenu;
    public GameObject audioMenu;
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public void ScreenMenu()
    {
        optionsMenu.SetActive(false);
        screenMenu.SetActive(true);   
    }

    public void AudioMenu()
    {
        optionsMenu.SetActive(false);
        audioMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
