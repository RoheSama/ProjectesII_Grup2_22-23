using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PhoneController : MonoBehaviour
{
    //GameObjects del mòbil
    public GameObject messageApp;
    public GameObject callApp;
    public GameObject tinderApp;
    public GameObject bookApp;
    public GameObject cursesApp;
    public GameObject mapApp;
    public GameObject settingsApp;
    public GameObject buttons;
    public GameObject apps;

    public GameObject closePhoneButton;

  
    public void CloseApp()
    {
        cursesApp.SetActive(false);
        buttons.SetActive(true);
        closePhoneButton.SetActive(true);
    }

    public void OpenCursesApp()
    {
        cursesApp.SetActive(true);
        buttons.SetActive(false);
        closePhoneButton.SetActive(false);
    }
    public void OpenMessageApp()
    {
        //messageApp.SetActive(true);
        //closePhoneButton.SetActive(false);
    }

    public void OpenCallApp()
    {
    //    callApp.SetActive(true);
    //    closePhoneButton.SetActive(false);
    }

    public void OpenTinderApp()
    {
        //tinderApp.SetActive(true);
        //closePhoneButton.SetActive(false);
    }

    public void OpenBookApp()
    {
        //bookApp.SetActive(true);
        //closePhoneButton.SetActive(false);
    }

   

    public void OpenMapApp()
    {
        //mapApp.SetActive(true);
        //closePhoneButton.SetActive(false);
    }

    public void OpenSettingsApp()
    {
        //settingsApp.SetActive(true);
        //closePhoneButton.SetActive(false);
    }

}


