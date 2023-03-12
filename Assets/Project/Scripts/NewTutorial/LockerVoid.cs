using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class LockerVoid : MonoBehaviour
{
    public GameObject student;
    public GameObject icon;
    public NavMeshAgent navMeshAgent;
    public GameObject locker;
    public GameObject shadow;

    public animatonScript animatonScript;

    private bool voidActivated = false;

    public bool locked = false;

    void Start()
    {

    }
    void Update()
    {
        if(!voidActivated)
        {
            navMeshAgent.enabled = false;
        }

        if (navMeshAgent.transform.position.x < locker.transform.position.x + 1 && navMeshAgent.transform.position.x > locker.transform.position.x - 1
            && navMeshAgent.transform.position.y < locker.transform.position.y + 1 && navMeshAgent.transform.position.y > locker.transform.position.y - 1)
        {
            student.SetActive(false);
            locked = true;
            icon.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && shadow.activeSelf)
        {
            animatonScript.enabled = true;
            voidActivated = true;
            navMeshAgent.enabled = true;
            navMeshAgent.destination = locker.transform.position;
        }
    }
}
