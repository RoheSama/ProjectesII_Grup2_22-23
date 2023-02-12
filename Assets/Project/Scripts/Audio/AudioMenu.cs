using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    public GameObject audioMenu;
    public GameObject optionsMenu;
    public void BackToOptionsMenu()
    {
        FindObjectOfType<AudioManager>().Play("ClickSound");
        audioMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
