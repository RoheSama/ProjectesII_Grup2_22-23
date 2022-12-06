using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public GameObject waypoint;

    void Start()
    {
        navMeshAgent.destination = waypoint.transform.position;
    }

    void Update()
    {
       // navMeshAgent.destination = waypoint.transform.position;
    }
}
