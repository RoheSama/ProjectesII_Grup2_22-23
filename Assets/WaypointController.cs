using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;


    //---Follow Waypoints
    bool followWaypoints = true;

    //Waypoints for FollowWaypoints
    public GameObject []waypoints;
    int waypointsIndex = 0;

    //Timer
    public int[] timeWaypoints;
    int timeWaypointsIndex = 0;

    float waypointsTimer = 0;
    bool waypointsTimerReached = false;

    //Waypoints for AvoidPlayer function
    public GameObject[] securePlace;
    int securePlaceIndex = 0;

    //---Avoid Player
    bool avoidPlayer = false;
    bool canGenerateRandomSecurePlace = true;
    int randomSecurePlace;

    // Avoid Player Timer
    float avoidPlayerTimer = 0;
    public int timeAvoidingPlayer;


    void Update()
    {
       
        AvoidPlayer();
        if (followWaypoints)
        {
            FollowWaypoints();
        }
        
       
        if (Input.GetKeyDown("e"))
        {
            avoidPlayer = true;
            canGenerateRandomSecurePlace = true;
        }
    }
    void FollowWaypoints()
    {
        // Anar cap al waypoint
        navMeshAgent.destination = waypoints[waypointsIndex].transform.position;

        // Si el waypoint == al waypoint final -1, torna a començar la ruta de waypoints
        if(waypointsIndex == waypoints.Length -1)
        {
            // Reset Index
            waypointsIndex = 0;
            timeWaypointsIndex = 0;
        }
       
        // Si arribes al waypoint
        else if(transform.position == navMeshAgent.destination)
        {
            if (!waypointsTimerReached)
                waypointsTimer += Time.deltaTime;

            if (!waypointsTimerReached && waypointsTimer >= timeWaypoints[timeWaypointsIndex])
            {
                // Index++
                waypointsIndex++;
                timeWaypointsIndex++;

                waypointsTimerReached = true;
            }
            if(waypointsTimerReached)
            {
                waypointsTimerReached = false;
                waypointsTimer = 0;
            }
        }
    }

    void AvoidPlayer()
    {
      if(avoidPlayer)
        {
            avoidPlayerTimer += Time.deltaTime;

            if(canGenerateRandomSecurePlace)
            {
                randomSecurePlace = Random.Range(0, securePlace.Length);
            }
           
            followWaypoints = false;
            navMeshAgent.destination = securePlace[randomSecurePlace].transform.position;
            canGenerateRandomSecurePlace = false;
            navMeshAgent.speed = 3;

            if(avoidPlayerTimer >= timeAvoidingPlayer)
            {
                avoidPlayer = false;
                followWaypoints = true;
                avoidPlayerTimer = 0;
                navMeshAgent.speed = 1;
            }
        }
    }
}
