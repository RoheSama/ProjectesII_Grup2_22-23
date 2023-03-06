using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCross : MonoBehaviour
{
    public GameObject violet;

    public GameObject cross;
    public GameObject crossEnabled;
    public GameObject crossDisabled;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CrossEnabled") && violet.activeSelf)
        {
            cross= other.gameObject;
            cross.tag = "CrossDisabled";
            crossEnabled = cross.transform.GetChild(0).gameObject;
            crossEnabled.SetActive(false);
            crossDisabled = cross.transform.GetChild(1).gameObject;
            crossDisabled.SetActive(true);

            crossEnabled = null;
            crossDisabled = null;
            cross = null;
        }
    }
}
