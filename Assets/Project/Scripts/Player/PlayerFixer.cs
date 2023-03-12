using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFixer : MonoBehaviour
{
    public GameObject shadow;
    public GameObject violet;

    void Update()
    {
        if (FindObjectOfType<AbilityUI>().powerUpActivated == false)
        {
            shadow.transform.position = violet.transform.position;
        }
        else
        {
            violet.transform.position = shadow.transform.position;
        }
    }
}
