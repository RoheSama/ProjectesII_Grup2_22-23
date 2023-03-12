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
    public GameObject credits;
    public GameObject mainMenuCanvas;

    public GameObject crossGuide;
    public GameObject curaGuide;
    public GameObject studentsGuide;
    public GameObject shadowGuide;
    public GameObject soulReaperGuide;
    public GameObject gloomGuide;

    public GameObject firstCrossVideo;
    public GameObject secondCrossVideo;
    public GameObject thirdCrossVideo;
    public GameObject firstNumberCross;
    public GameObject secondNumberCross;
    public GameObject thirdNumberCross;

    public GameObject firstStudentVideo;
    public GameObject secondStudentVideo;
    public GameObject firstNumberStudent;
    public GameObject secondNumberStudent;
    public GameObject askForTutorialButton;

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            cinematic.SetActive(false);
            mainMenuCanvas.SetActive(false);
            askForTutorialButton.SetActive(true);
        }
        if(activeTimer)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 68)
        {
            mainMenuCanvas.SetActive(false);
            askForTutorialButton.SetActive(true);
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
        activeTimer = true;
        FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
    }

    public void YesButton()
    {
        SceneManager.LoadScene("TopDownMap");
    }

    public void NoButton()
    {
        SceneManager.LoadScene("TutorialScene");
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
        credits.SetActive(false);
        logo.SetActive(true);
    }


    // Button de Credits
    public void Credits()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        credits.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    // Button de BackFromCredits

    public void BackFromCredits()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        mainMenuCanvas.SetActive(true);
        credits.SetActive(false);
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

    // Button de Gloom Guide
    public void GloomGuide()
    {
        gloomGuide.SetActive(true);
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
        gloomGuide.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void NextCrossVideo()
    {
        if (secondCrossVideo.activeSelf)
        {
            secondCrossVideo.SetActive(false);
            thirdCrossVideo.SetActive(true);
            thirdNumberCross.SetActive(true);
            secondNumberCross.SetActive(false);
        }
        else if (firstCrossVideo.activeSelf)
        {
            firstCrossVideo.SetActive(false);
            secondCrossVideo.SetActive(true);
            secondNumberCross.SetActive(true);
            firstNumberCross.SetActive(false);
        }
    }

    public void PreviousCrossVideo()
    {
        if (thirdCrossVideo.activeSelf)
        {
            secondCrossVideo.SetActive(true);
            thirdCrossVideo.SetActive(false);
            thirdNumberCross.SetActive(false);
            secondNumberCross.SetActive(true);
        }
        else if (secondCrossVideo.activeSelf)
        {
            firstCrossVideo.SetActive(true);
            secondCrossVideo.SetActive(false);
            firstNumberCross.SetActive(true);
            secondNumberCross.SetActive(false);
        }
    }

    public void NextStudentVideo()
    {
        if (firstStudentVideo.activeSelf)
        {
            firstStudentVideo.SetActive(false);
            secondStudentVideo.SetActive(true);
            firstNumberStudent.SetActive(false);
            secondNumberStudent.SetActive(true);
        }
    }
    public void PreviousStudentVideo()
    {
        if (secondStudentVideo.activeSelf)
        {
            firstStudentVideo.SetActive(true);
            secondStudentVideo.SetActive(false);
            firstNumberStudent.SetActive(true);
            secondNumberStudent.SetActive(false);
        }
    }
}
