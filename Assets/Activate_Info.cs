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
    public GameObject studentsAlive;
    public GameObject alertLevel;
    public GameObject violet;
    public GameObject shadow;
    public GameObject hp;
    public GameObject remainingTime;


    public GameObject shadowIcon;

    void Start()
    {
       // ability1.SetActive(true);
    }

    void Update()
    {
        studentsAlive.SetActive(true);
        Vector3 mousePos = Input.mousePosition;
        {
            //DEBUG
            //UnityEngine.Debug.Log(mousePos.x);
            UnityEngine.Debug.Log(mousePos.y);

            //Ability1
            if (mousePos.x > 89 && mousePos.x <204 && mousePos.y > 70 && mousePos.y < 184) 
            {
                ability1.SetActive(true);
            }
            else
                ability1.SetActive(false);

            //Ability2
            if (mousePos.x > 216 && mousePos.x < 328 && mousePos.y > 70 && mousePos.y < 184)
            {
                ability2.SetActive(true);
            }
            else
                ability2.SetActive(false);

            //Ability3
            if (mousePos.x > 360 && mousePos.x < 470 && mousePos.y > 70 && mousePos.y < 184)
            {
                ability3.SetActive(true);
            }
            else
                ability3.SetActive(false);


            //Students Alive
            if (mousePos.x > 1660 && mousePos.x < 1770 && mousePos.y > 60 && mousePos.y < 165)
            {
                studentsAlive.SetActive(true);
            }
            else
                studentsAlive.SetActive(false);


            //Alert Level
            if (mousePos.x > 1520 && mousePos.x < 1900 && mousePos.y > 860 && mousePos.y < 1060)
            {
                alertLevel.SetActive(true);
            }
            else
                alertLevel.SetActive(false);

            //Violet
            if (mousePos.x > 60 && mousePos.x < 200 && mousePos.y > 890 && mousePos.y < 1050)
            {
                if(!shadowIcon.activeSelf)
                {
                    violet.SetActive(true);
                    shadow.SetActive(false);
                }
            }
            else
                violet.SetActive(false);

            //Shadow
            if (mousePos.x > 60 && mousePos.x < 200 && mousePos.y > 890 && mousePos.y < 1050)
            {
                if (shadowIcon.activeSelf)
                {
                    shadow.SetActive(true);
                    violet.SetActive(false);
                }
            }
            else
                shadow.SetActive(false);


            //HP
            if (mousePos.x > 200 && mousePos.x < 600 && mousePos.y > 975 && mousePos.y < 1000)
            {
                hp.SetActive(true);
            }
            else
                hp.SetActive(false);

            //Remaining Time
            if (mousePos.x > 200 && mousePos.x < 600 && mousePos.y > 950 && mousePos.y < 975)
            {
                remainingTime.SetActive(true);
            }
            else
                remainingTime.SetActive(false);
        }
    }
}
