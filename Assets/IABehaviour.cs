using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public SpriteRenderer character;
  
    //---Follow Waypoints
    bool followWaypointsLevel0 = true;

    //Waypoints for FollowWaypoints
    public GameObject[] waypoints;
    int waypointsIndex = 0;

    //Timer
    public int[] timeWaypoints;
    int timeWaypointsIndex = 0;

    float waypointsTimer = 0;
    bool waypointsTimerReached = false;

    //Icono Danger
    public GameObject dangerIcon;
    public GameObject shadowIcon;

    //LEVELS
    bool level0 = true;
    bool level1 = false;
    bool level2 = false;
    bool level3 = false;

    // Satanic Stars
    public GameObject satanicStar01;

    // Detector
    public GameObject detector;
    int detectorIncrement = 0;
    //Rincon de llorar

    //Waypoints for Rincon De Llorar Function

    bool goToRinconDeLlorar = true;
    public GameObject myRinconDeLlorar;


    // Rincon de Llorar Timer
    float rinconDeLlorarTimer = 0;
    public int timeInRinconDeLlorar;


    //Avoid Students
    bool canAvoidStudents = false;
    float avoidTemp = 0;
    float avoidStudentsTemp = 0;

    //Hide
    bool goToHide = true;
    bool canHide = false;
    float hideTimer = 0;
    public int timeHidden;
    public GameObject myHidePlace;
    public GameObject myHideIcon;


    void Start()
    {
      dangerIcon.SetActive(false);
    }

    void Update()
    {
        //CHECK THE LEVEL
       
   

        //Level 0
        if (satanicStar01.activeInHierarchy == false)
        {
            level0= false;
            level1= true;
        }
        if (level0)
        {
            if (followWaypointsLevel0)
            {
                FollowWaypointsLevel0();
            }
            else if(dangerIcon.activeSelf)
            {
                RinconDeLlorarLevel0(); 
            }
        }

        //Level 1
        if (level1)
        {
            if (followWaypointsLevel0)
            {
                FollowWaypointsLevel0();
            }
            else if(canAvoidStudents)
            {
                AvoidStudents();
            }
            else if(dangerIcon.activeSelf)
            {
                HideInHidePlace();
            }
            //else if (dangerIcon.activeSelf)
            //{
            //    RinconDeLlorarLevel0();
           // }
        }
    }

    void FollowWaypointsLevel0()
    {
        // Anar cap al waypoint
        navMeshAgent.destination = waypoints[waypointsIndex].transform.position;

        // Si el waypoint == al waypoint final -1, torna a comen�ar la ruta de waypoints
        if (waypointsIndex == waypoints.Length - 1)
        {
            // Reset Index
            waypointsIndex = 0;
            timeWaypointsIndex = 0;
        }

        // Si arribes al waypoint
        else if (transform.position == navMeshAgent.destination)
        {
            if (!waypointsTimerReached)
            {
                //Comen�ar temporitzador
                waypointsTimer += Time.deltaTime;
            }

            if (!waypointsTimerReached && waypointsTimer >= timeWaypoints[timeWaypointsIndex])
            {
                // Index++
                waypointsIndex++;
                timeWaypointsIndex++;

                waypointsTimerReached = true;
            }

            // Si arribes al waypointsTimer
            if (waypointsTimerReached)
            {
                waypointsTimerReached = false;
                waypointsTimer = 0;
            }
        }
    }
   
    
    void RinconDeLlorarLevel0()
    {
        rinconDeLlorarTimer += Time.deltaTime;
        if(myRinconDeLlorar == null)
        {
            detector.transform.localScale= new Vector3(detectorIncrement, 1, 1);
            detectorIncrement++;
        }
        else
        {
            detector.transform.localScale = new Vector3(1, 1, 1);
            navMeshAgent.destination = myRinconDeLlorar.transform.position;
            navMeshAgent.speed = 3;
        }

        if(rinconDeLlorarTimer >= timeInRinconDeLlorar)
        {
            dangerIcon.SetActive(false);
            rinconDeLlorarTimer = 0;

        }
       
        //Vuelta a la normalidad
        if(dangerIcon.activeInHierarchy == false)
        {
            myRinconDeLlorar.SetActive(true);
            myRinconDeLlorar = null;
            followWaypointsLevel0 = true;
            navMeshAgent.speed = 2;
            if (satanicStar01.activeSelf)
            {
                satanicStar01.SetActive(false);
            }
        }
    }


    void AvoidStudents()
    {
        //waypointsIndex++;
        avoidStudentsTemp+= Time.deltaTime;
        navMeshAgent.speed = 4;

        if (avoidStudentsTemp >=3)
        {
            avoidStudentsTemp = 0;
            canAvoidStudents = false;
            followWaypointsLevel0 = true;
            navMeshAgent.speed = 2; 
        }
    }

    void HideInHidePlace()
    {
        hideTimer += Time.deltaTime;
        if (myHidePlace == null)
        {
            detector.transform.localScale = new Vector3(detectorIncrement, 1, 1);
            detectorIncrement++;
        }
        else
        {
            detector.transform.localScale = new Vector3(1, 1, 1);
            navMeshAgent.destination = myHidePlace.transform.position;
            navMeshAgent.speed = 3;
        }

        if(navMeshAgent.transform.position.x < myHidePlace.transform.position.x +1 && navMeshAgent.transform.position.x > myHidePlace.transform.position.x -1
            && navMeshAgent.transform.position.y < myHidePlace.transform.position.y + 1 && navMeshAgent.transform.position.y > myHidePlace.transform.position.y - 1)
        {
            character.enabled = false;
            myHideIcon = myHidePlace.transform.GetChild(0).gameObject;
            myHideIcon.SetActive(true);
            navMeshAgent.speed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(level0)
        {
            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                dangerIcon.SetActive(true);
                followWaypointsLevel0 = false;
            }

            else if (goToRinconDeLlorar)
            {
                if (other.CompareTag("Rincon_De_Llorar"))
                {
                    myRinconDeLlorar = other.gameObject;
                    other.gameObject.SetActive(false);
                }
            }
        }

        if (level1)
        {
            if (other.CompareTag("Target")|| other.CompareTag("Player"))
            {

                avoidTemp += Time.deltaTime;
                if (avoidTemp >= 1)
                {
                    followWaypointsLevel0 = false;
                    canAvoidStudents = true;
                    avoidTemp = 0;
                }
            }

            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                dangerIcon.SetActive(true);
                followWaypointsLevel0 = false;
            }

            else if (goToHide)
            {
                if (other.CompareTag("Hide_Place"))
                {
                    myHidePlace = other.gameObject;
                    myHidePlace.GetComponent<SpriteRenderer>().color = new Color(100f,100f,100f);
                    //other.gameObject.SetActive(false);
                }
            }
    }   }
}
