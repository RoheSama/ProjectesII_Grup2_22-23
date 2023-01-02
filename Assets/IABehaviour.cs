using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject player;
    //float playerPosX;
    //float playerPosY;


    //---Follow Waypoints
    bool followWaypoints = true;

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
    bool level1 = true;
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


    void Start()
    {
      dangerIcon.SetActive(false);
    }

    void Update()
    {
      //  playerPosX = player.transform.position.x;
      //  playerPosY= player.transform.position.y;

        if (level1)
        {
            if (followWaypoints)
            {
                FollowWaypoints();
            }
            else if(dangerIcon.activeSelf)
            {
                RinconDeLlorar();
                if(satanicStar01.activeSelf)
                {
                    satanicStar01.SetActive(false);
                }
            }
        }
    }

    void FollowWaypoints()
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
   
    
    void RinconDeLlorar()
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
        if(dangerIcon.activeInHierarchy == false)
        {
            myRinconDeLlorar.SetActive(true);
            myRinconDeLlorar = null;
            followWaypoints = true;
            navMeshAgent.speed = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && shadowIcon.activeSelf)
        {
            dangerIcon.SetActive(true);
            followWaypoints = false;
        }

       else if(goToRinconDeLlorar)
        {
            if (other.CompareTag("Rincon_De_Llorar"))
            {
                myRinconDeLlorar = other.gameObject;
                other.gameObject.SetActive(false);
            }
        }
    }

}
