using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PhoneController : MonoBehaviour
{
    public GameObject messageApp;
    public GameObject callApp;
    public GameObject tinderApp;
    public GameObject bookApp;
    public GameObject cursesApp;
    public GameObject mapApp;
    public GameObject settingsApp;
    public GameObject buttons;
    public GameObject apps;
    void Start()
    {
       
    }

    void Update()
    {
        
    }


    public void CloseApp()
    {
        cursesApp.SetActive(false);
        buttons.SetActive(true);
    }

    public void OpenMessageApp()
    {
        messageApp.SetActive(true);
    }

    public void OpenCallApp()
    {
        callApp.SetActive(true);
    }

    public void OpenTinderApp()
    {
        tinderApp.SetActive(true);
    }

    public void OpenBookApp()
    {
        bookApp.SetActive(true);
    }

    public void OpenCursesApp()
    {
        cursesApp.SetActive(true);
        buttons.SetActive(false);
    }

    public void OpenMapApp()
    {
        mapApp.SetActive(true);
    }

    public void OpenSettingsApp()
    {
        settingsApp.SetActive(true);
    }

}


