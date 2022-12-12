using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    public Slider rageBar;
    public float maxRage = 100;
    public float currentRage = 0;

    public void Start()
    {
        rageBar.value = currentRage;
    }
    // Update is called once per frame
    public void UpdateRageBar()
    {
        currentRage =+ 20;
        Debug.Log("Barrita");
    }
}
