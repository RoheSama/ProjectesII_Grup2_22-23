using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointControllerVoids : MonoBehaviour
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


    //---JAM
    float jamTimer = 0;
    int timeToDetectJam = 3;
    float xCoords;
    float yCoords;
    bool canGetCoords = true;


    //Is In Waypoint
    bool isInWaypoint = false;

    void Update()
    {
       // IsInWaypoint();
        Jam();
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
            {
                //Començar contador
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
            // Comencçar contador
            avoidPlayerTimer += Time.deltaTime;

            if(canGenerateRandomSecurePlace)
            {
                // Genera un numero random entre 0 i el maxim de randmosScurePlaces
                randomSecurePlace = Random.Range(0, securePlace.Length);
            }
           
            followWaypoints = false;
            navMeshAgent.destination = securePlace[randomSecurePlace].transform.position;
            canGenerateRandomSecurePlace = false;
            navMeshAgent.speed = 3;

            //Si arribes al temps de timeAvoidingPlayer
            if(avoidPlayerTimer >= timeAvoidingPlayer)
            {
                avoidPlayer = false;
                followWaypoints = true;
                avoidPlayerTimer = 0;
                navMeshAgent.speed = 1;
            }
        }
    }

    void Jam()
    {  
        jamTimer += Time.deltaTime;
        if(canGetCoords)
        {
            xCoords = navMeshAgent.transform.position.x;
            yCoords = navMeshAgent.transform.position.y;
            canGetCoords = false;
        }

        if(jamTimer >= timeToDetectJam)
        {
            if (!isInWaypoint && xCoords == navMeshAgent.transform.position.x || xCoords == navMeshAgent.transform.position.x  || yCoords == navMeshAgent.transform.position.y || yCoords == navMeshAgent.transform.position.y)
            {
               // Debug.Log("Atasco");
            }
            canGetCoords = true;
            jamTimer = 0;
        }
    }

    void IsInWaypoint()
    {
        for(int i = 0; i<= waypoints.Length;i++)
        {
            if (transform.position != waypoints[i].transform.position)
            {
                isInWaypoint = false;
            }
            else
                isInWaypoint = true;
            Debug.Log("WAYPOINT");
                break;
        }
        
    }
}
