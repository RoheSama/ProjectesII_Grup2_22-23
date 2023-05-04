using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTutoriav3 : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    public GameObject wayPoint1;
    public GameObject wayPoint2;

    public bool activated = false;

    public GameObject disabledCross;

    public GameObject invisibleWall;
    private void Update()
    {

        if (navMeshAgent.transform.position.x < wayPoint1.transform.position.x + 0.5 && navMeshAgent.transform.position.x > wayPoint1.transform.position.x - 0.5
            && navMeshAgent.transform.position.y < wayPoint1.transform.position.y + 0.5 && navMeshAgent.transform.position.y > wayPoint1.transform.position.y - 0.5 && !activated)
        {
            navMeshAgent.enabled = false;
        }

        if (navMeshAgent.transform.position.x < wayPoint2.transform.position.x + 0.5 && navMeshAgent.transform.position.x > wayPoint2.transform.position.x - 0.5
            && navMeshAgent.transform.position.y < wayPoint2.transform.position.y + 0.5 && navMeshAgent.transform.position.y > wayPoint2.transform.position.y - 0.5)
        {
            navMeshAgent.enabled = false;
        }

        if (disabledCross.activeSelf)
        {
            activated= true;
        }

        MoveShadow();

    }

    void MoveShadow()
    {
        if(activated)
        {
            navMeshAgent.enabled = true;
            navMeshAgent.destination = wayPoint2.transform.position;
            activated = true;
            invisibleWall.SetActive(false);
        }
    }
}
