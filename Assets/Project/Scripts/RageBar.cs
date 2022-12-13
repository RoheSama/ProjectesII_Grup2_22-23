using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    public Slider rageBar;
    //public float maxRage = 100;
    //public float currentRage = 0;
    int progress = 0;

    // Update is called once per frame
    public void UpdateRageBar()
    {
        progress++;
        rageBar.value = progress;
        Debug.Log("Barrita");
    }
}
