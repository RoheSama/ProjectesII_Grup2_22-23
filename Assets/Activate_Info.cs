using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;



public class Activate_Info : MonoBehaviour
{
    public GameObject ability1;
 
    void Start()
    {
       // ability1.SetActive(true);
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        {
            //DEBUG
            //UnityEngine.Debug.Log(mousePos.x);
            UnityEngine.Debug.Log(mousePos.y);

            //Ability1
            if(mousePos.x > 89 && mousePos.x <204 && mousePos.y > 70 && mousePos.y < 184) 
            {
                ability1.SetActive(true);
            }
            else
                ability1.SetActive(false);
        }
    }
}
