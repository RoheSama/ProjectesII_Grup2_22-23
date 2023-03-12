using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    public GameObject playerHealth;

    public KeyCode inmortalKey;
    public KeyCode voidsKey;

    public GameObject voidsNumber;

    void Update()
    {
        if (Input.GetKeyDown(inmortalKey))
        {
            playerHealth.GetComponent<PlayerHealth>().maxHealth = 10000;
            playerHealth.GetComponent<PlayerHealth>().health = playerHealth.GetComponent<PlayerHealth>().maxHealth;
        }

        if (Input.GetKeyDown(voidsKey))
        {
            voidsNumber.GetComponent<VoidsLeft>().totalVoids = 0;
        }
    }
}
