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

    public GameObject crossGuide;
    public GameObject curaGuide;
    public GameObject studentsGuide;
    public GameObject shadowGuide;
    public GameObject soulReaperGuide;

    public GameObject firstCrossVideo;
    public GameObject secondCrossVideo;
    public GameObject thirdCrossVideo;

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            cinematic.SetActive(false);
            SceneManager.LoadScene("TutorialScene");
        }
        if(activeTimer)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 68)
        {
            SceneManager.LoadScene("TutorialScene");
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
        logo.SetActive(false);
    }

    // Button de Controls
    public void Controls()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        controlsMenu.SetActive(true);
        optionsMenu.SetActive(false);
        mainMenu.SetActive(false);
        logo.SetActive(false);
    }

    // Button de Back
    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        logo.SetActive(true);
    }
    
    // Button de Exit
    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        Application.Quit();
    }

    // Button de Cross Guide
    public void CrossGuide()
    {
        crossGuide.SetActive(true);
        controlsMenu.SetActive(false);
    }

    // Button de Cura Guide
    public void CuraGuide()
    {
        curaGuide.SetActive(true);
        controlsMenu.SetActive(false);
    }

    // Button de Students Guide
    public void StudentsGuide()
    {
        studentsGuide.SetActive(true);
        controlsMenu.SetActive(false);
    }

    // Button de Shadow Guide
    public void ShadowGuide()
    {
        shadowGuide.SetActive(true);
        controlsMenu.SetActive(false);
    }

    // Button de Soul Reaper Guide
    public void SoulReaperGuide()
    {
        soulReaperGuide.SetActive(true);
        controlsMenu.SetActive(false);
    }

    // Button de Back de las Guides
    public void BackToGuide()
    {
        crossGuide.SetActive(false);
        curaGuide.SetActive(false);
        studentsGuide.SetActive(false);
        shadowGuide.SetActive(false);
        soulReaperGuide.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void NextCrossVideo()
    {
        if (secondCrossVideo.activeSelf)
        {
            secondCrossVideo.SetActive(false);
            thirdCrossVideo.SetActive(true);
        }
        else if (firstCrossVideo.activeSelf)
        {
            firstCrossVideo.SetActive(false);
            secondCrossVideo.SetActive(true);
        }
    }

    public void PreviousCrossVideo()
    {
        if (!secondCrossVideo.activeSelf)
        {
            secondCrossVideo.SetActive(true);
            thirdCrossVideo.SetActive(false);
        }
        else if (!firstCrossVideo.activeSelf)
        {
            firstCrossVideo.SetActive(true);
            secondCrossVideo.SetActive(false);
        }
    }
}
