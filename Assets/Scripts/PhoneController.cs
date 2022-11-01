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

    void Start()
    {
       
    }

    void Update()
    {
        
    }


    public void CloseApp()
    {
        messageApp.SetActive(false);
        callApp.SetActive(false);
        tinderApp.SetActive(false);
        bookApp.SetActive(false);
        cursesApp.SetActive(false);
        mapApp.SetActive(false);
        settingsApp.SetActive(false);
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


