using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMenu : MonoBehaviour
{
    public GameObject screenMenu;
    public GameObject optionsMenu;
    public Toggle fullscreenToggle;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void BackToOptionsMenu()
    {
        AudioManager.Instance.Play("ClickSound", this.gameObject);
        screenMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void Resolution1()
    {
        AudioManager.Instance.Play("ClickSound", this.gameObject);
        fullscreenToggle.isOn = false;
        Screen.SetResolution(720, 480, false);
    }
    public void Resolution2()
    {
        AudioManager.Instance.Play("ClickSound", this.gameObject);
        fullscreenToggle.isOn = false;
        Screen.SetResolution(1280, 720, false);
    }
    public void Resolution3()
    {
        AudioManager.Instance.Play("ClickSound", this.gameObject);
        fullscreenToggle.isOn = false;
        Screen.SetResolution(1920, 1080, false);
    }
    public void Fullscreen()
    {
        AudioManager.Instance.Play("ClickSound", this.gameObject);
        if (!fullscreenToggle.isOn)
        {
            Screen.SetResolution(1920, 1080, false);
        }

       else if (fullscreenToggle.isOn)
        {
            Screen.SetResolution(1920, 1080, true);
        }
    }




}
