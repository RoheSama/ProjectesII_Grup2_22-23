using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    //Waypoints
    public GameObject []waypoints;
    int waypointsIndex = 0;

    //Timer
    public int[] timeWaypoints;
    int timeWaypointsIndex = 0;

    float timer = 0;
    bool timerReached = false;

    void Start()
    {
      
    }

    void Update()
    {
        FollowWaypoints();
    }
    void FollowWaypoints()
    {
        // Anar cap al waypoint
        navMeshAgent.destination = waypoints[waypointsIndex].transform.position;

        // Si el waypoint == al waypoint final -1, torna a començar la ruta de waypoints
        if(waypointsIndex == waypoints.Length -1)
        {
            waypointsIndex = 0;
        }
       
        // Si arribes al waypoint
        else if(transform.position == navMeshAgent.destination)
        {
            if (!timerReached)
                timer += Time.deltaTime;

            if (!timerReached && timer >= timeWaypoints[timeWaypointsIndex])
            {
                // Index++
                waypointsIndex++;
                timeWaypointsIndex++;

                //Set to false so that We don't run this again
                timerReached = true;
            }
            if(timerReached)
            {
                timerReached = false;
                timer = 0;
            }
        }
    }
   
}
