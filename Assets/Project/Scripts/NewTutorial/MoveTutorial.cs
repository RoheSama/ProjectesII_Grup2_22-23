using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTutorial : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    public GameObject wayPoint;

    public bool activated = false;

    private void Update()
    {
        if (navMeshAgent.transform.position.x < wayPoint.transform.position.x + 0.1 && navMeshAgent.transform.position.x > wayPoint.transform.position.x - 0.1
            && navMeshAgent.transform.position.y < wayPoint.transform.position.y + 0.1 && navMeshAgent.transform.position.y > wayPoint.transform.position.y - 0.1)
        {
            navMeshAgent.enabled = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            navMeshAgent.enabled = true;
            navMeshAgent.destination = wayPoint.transform.position;
            activated = true;
        }
    }
}
