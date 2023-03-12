using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraDummy : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject waypoint1;
    public GameObject waypoint2;

    private bool goToWaypoint1 = true;
    private bool goToWaypoint2 = false;

    void Update()
    {
        if (navMeshAgent.transform.position.x < waypoint1.transform.position.x + 1 && navMeshAgent.transform.position.x > waypoint1.transform.position.x - 1
          && navMeshAgent.transform.position.y < waypoint1.transform.position.y + 1 && navMeshAgent.transform.position.y > waypoint1.transform.position.y - 1)
        {
            goToWaypoint1= false;
            goToWaypoint2 = true;
        }

        if (navMeshAgent.transform.position.x < waypoint2.transform.position.x + 1 && navMeshAgent.transform.position.x > waypoint2.transform.position.x - 1
          && navMeshAgent.transform.position.y < waypoint2.transform.position.y + 1 && navMeshAgent.transform.position.y > waypoint2.transform.position.y - 1)
        {
            goToWaypoint1 = true;
            goToWaypoint2 = false;
        }


        if (goToWaypoint1)
        {
            navMeshAgent.destination = waypoint1.transform.position;
        }

        if (goToWaypoint2)
        {
            navMeshAgent.destination = waypoint2.transform.position;
        }
    }
}
