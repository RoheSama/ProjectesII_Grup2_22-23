using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    public GameObject audioMenu;
    public GameObject optionsMenu;
    public void BackToOptionsMenu()
    {
        AudioManager.Instance.Play("ClickSound", this.gameObject);
        audioMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
