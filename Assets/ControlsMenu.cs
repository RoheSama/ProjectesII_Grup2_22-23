using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject mainMenu;

    public void BackToMainMenu()
    {
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
