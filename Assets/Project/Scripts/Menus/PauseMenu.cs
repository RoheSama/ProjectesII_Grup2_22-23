using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject ResumeButton;
    public GameObject MenuButton;
    public GameObject QuitButton;
    public GameObject VolumeButton;
    public GameObject VolumeSliders;

    //Rendering
    public RenderPipelineAsset powerUpAsset;
    public RenderPipelineAsset normalAsset;

    public GameObject shadow;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //Freeze Game
        GameIsPaused = false;
        if (shadow.activeSelf)
        {
            GraphicsSettings.renderPipelineAsset = powerUpAsset;
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //Freeze Game
        GameIsPaused = true;
        GraphicsSettings.renderPipelineAsset = normalAsset;
    }

    public void LoadMenu()
    {
        Debug.Log("Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void EnterVolume()
    {
        Debug.Log("Volume");
        VolumeButton.SetActive(false);
        ResumeButton.SetActive(false);
        VolumeSliders.SetActive(true);
        MenuButton.SetActive(false);
        QuitButton.SetActive(false);
        
    }

    public void BackButton()
    {
        Debug.Log("Volume");
        VolumeButton.SetActive(true);
        ResumeButton.SetActive(true);
        VolumeSliders.SetActive(false);
        MenuButton.SetActive(true);
        QuitButton.SetActive(true);

    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
