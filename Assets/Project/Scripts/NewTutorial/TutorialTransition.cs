using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialTransition : MonoBehaviour
{

    public GameObject wayPoint1;

    public NavMeshAgent navMeshAgent;

    public bool chargeScene = false;
    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.transform.position.x < wayPoint1.transform.position.x + 0.5 && navMeshAgent.transform.position.x > wayPoint1.transform.position.x - 0.5
            && navMeshAgent.transform.position.y < wayPoint1.transform.position.y + 0.5 && navMeshAgent.transform.position.y > wayPoint1.transform.position.y - 0.5)
        {
            Debug.Log("desactivacion");
            navMeshAgent.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            chargeScene = true;
        }
    }

    
}
