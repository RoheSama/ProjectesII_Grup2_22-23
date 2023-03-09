using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCross : MonoBehaviour
{
    public GameObject violet;

    public GameObject cross;
    public GameObject crossEnabled;
    public GameObject crossDisabled;

    public float timer;

    //Audio 
    public AudioSourceCross audioSourceCross;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer>= 0.3f )
        {
            audioSourceCross.flipCrossOff();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CrossEnabled") && violet.activeSelf)
        {
            audioSourceCross.flipCross();
            cross = other.gameObject;
            cross.tag = "CrossDisabled";
            crossEnabled = cross.transform.GetChild(0).gameObject;
            crossEnabled.SetActive(false);
            crossDisabled = cross.transform.GetChild(1).gameObject;
            crossDisabled.SetActive(true);

            crossEnabled = null;
            crossDisabled = null;
            cross = null;
            timer = 0;
            
        }
    }
}
