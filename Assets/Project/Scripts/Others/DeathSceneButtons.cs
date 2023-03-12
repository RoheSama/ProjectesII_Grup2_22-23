using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneButtons : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("TopDownMap");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
