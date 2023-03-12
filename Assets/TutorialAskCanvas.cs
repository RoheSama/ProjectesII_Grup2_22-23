using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialAskCanvas : MonoBehaviour
{
    public GameObject YesButton;
    public GameObject NoButton;
    // Update is called once per frame
    
    public void YesOption()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TutorialScene");
    }

    public void NoOption()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TopDownMap");
    }
}
