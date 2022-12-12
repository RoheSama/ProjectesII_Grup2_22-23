using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMenu : MonoBehaviour
{
    public GameObject screenMenu;
    public GameObject optionsMenu;

    public void BackToOptionsMenu()
    {
        screenMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
}
