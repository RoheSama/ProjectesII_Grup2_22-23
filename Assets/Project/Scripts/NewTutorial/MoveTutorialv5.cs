using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTutorialv5 : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    public GameObject wayPoint1;
    public GameObject wayPoint2;

    public bool activated = false;

    public GameObject voidsLeft;

    private void Update()
    {

        if (navMeshAgent.transform.position.x < wayPoint1.transform.position.x + 0.5 && navMeshAgent.transform.position.x > wayPoint1.transform.position.x - 0.5
            && navMeshAgent.transform.position.y < wayPoint1.transform.position.y + 0.5 && navMeshAgent.transform.position.y > wayPoint1.transform.position.y - 0.5 && !activated)
        {
            Debug.Log("desactivacion");
            navMeshAgent.enabled = false;
        }

        if (navMeshAgent.transform.position.x < wayPoint2.transform.position.x + 0.5 && navMeshAgent.transform.position.x > wayPoint2.transform.position.x - 0.5
            && navMeshAgent.transform.position.y < wayPoint2.transform.position.y + 0.5 && navMeshAgent.transform.position.y > wayPoint2.transform.position.y - 0.5)
        {
            Debug.Log("desactivacion");
            navMeshAgent.enabled = false;
        }

        if (voidsLeft.GetComponent<VoidsLeft>().totalVoids == 0)
        {
            activated = true;
        }

        MoveShadow();

    }

    void MoveShadow()
    {
        if (activated)
        {
            Debug.Log("activacion");
            navMeshAgent.enabled = true;
            navMeshAgent.destination = wayPoint2.transform.position;
            activated = true;

        }
    }
}
