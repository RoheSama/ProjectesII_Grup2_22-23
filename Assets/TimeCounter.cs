using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public float gameTime;

    public string timeValue = "Time";

    void Update()
    {
        gameTime += Time.deltaTime;
        PlayerPrefs.SetFloat(timeValue, 33);
    }
}
