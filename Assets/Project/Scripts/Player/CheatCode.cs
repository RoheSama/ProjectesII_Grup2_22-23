using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    public GameObject playerHealth;

    public KeyCode inmortalKey;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inmortalKey))
        {
            playerHealth.GetComponent<PlayerHealth>().maxHealth = 10000;
            playerHealth.GetComponent<PlayerHealth>().health = playerHealth.GetComponent<PlayerHealth>().maxHealth;
        }
    }
}
