using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void OnButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
