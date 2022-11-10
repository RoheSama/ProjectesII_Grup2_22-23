using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPhone : MonoBehaviour
{
    public GameObject mainMenu;
    public AudioSource audioSource;

    void Start()
    {

    }
    public void PowerButtonTouched()
    {
        Debug.Log("a");
        mainMenu.SetActive(true);
        audioSource.Play();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SchoolScene");
        audioSource.Play();
    }
    public void ExitGame()
    {
        Application.Quit();
        audioSource.Play();
    }
}
