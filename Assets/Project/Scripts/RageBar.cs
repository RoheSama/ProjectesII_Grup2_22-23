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
    public float maxValue;
    private float timeRemaining = 5f;
    private const float timeMax = 5f;
    public bool raged = false;

    // Update is called once per frame
    void Update()
    {
        if(rageBar.value == maxValue)
        {
            raged = true;
        }

        if (raged)
        {
            rageBar.value = CalculateSliderValue();

            if (rageBar.value == maxValue)
            {
                timeRemaining = timeMax;
                Debug.Log("ZERO");
            }

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
            }

            else if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            if (timeRemaining == 0)
            {
                raged = false;
                Debug.Log("ZERO");
            }
        }
        
     
    }

    public void UpdateRageBar()
    {
        if (!raged)
        {
            progress++;
            rageBar.value = progress;
            Debug.Log("Barrita");
        }
       
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / timeMax) * maxValue;
    }
}
