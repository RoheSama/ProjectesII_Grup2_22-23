using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject mainMenu;

    public void BackToMainMenu()
    {
        AudioManager.Instance.Play("ClickSound", this.gameObject);
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
