using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;



public class Activate_Info : MonoBehaviour
{
    public GameObject ability1;
    public GameObject ability2;
    public GameObject ability3;


    void Start()
    {
       // ability1.SetActive(true);
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        {
            //DEBUG
            UnityEngine.Debug.Log(mousePos.x);
            //UnityEngine.Debug.Log(mousePos.y);

            //Ability1
            if(mousePos.x > 89 && mousePos.x <204 && mousePos.y > 70 && mousePos.y < 184) 
            {
                ability1.SetActive(true);
                UnityEngine.Debug.Log("1");
            }
            else
                ability1.SetActive(false);

            //Ability2
            if (mousePos.x > 216 && mousePos.x < 328 && mousePos.y > 70 && mousePos.y < 184)
            {
                ability2.SetActive(true);
                UnityEngine.Debug.Log("2");
            }
            else
                ability2.SetActive(false);

            //Ability3
            if (mousePos.x > 360 && mousePos.x < 470 && mousePos.y > 70 && mousePos.y < 184)
            {
                ability3.SetActive(true);
                UnityEngine.Debug.Log("3");
            }
            else
                ability3.SetActive(false);


        }
    }
}
