using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    public GameObject audioMenu;
    public GameObject optionsMenu;
    public void BackToOptionsMenu()
    {
        audioMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
