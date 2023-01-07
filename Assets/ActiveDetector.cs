using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDetector : MonoBehaviour
{
    public GameObject detector;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1)
        {
            detector.SetActive(true);
        }
        if (timer > 2)
        {
            detector.SetActive(false);
            timer = 0;
        }
    }
}
