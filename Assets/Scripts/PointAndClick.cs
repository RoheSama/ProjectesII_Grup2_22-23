using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClick : MonoBehaviour
{
    private Vector3 target;
    NavMeshAgent agent;

    void Start()
    {
        //Navmesh DONT ERASE
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition();
        SetAgentPosition();
    }

    void SetTargetPosition() //Sets the target position that our agent is following everytime you click
    {
        if (Input.GetMouseButtonDown(1)) //Right Click
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void SetAgentPosition()
    {
        agent.SetDestination(new Vector3 (target.x, target.y, transform.position.z));
    }
}
