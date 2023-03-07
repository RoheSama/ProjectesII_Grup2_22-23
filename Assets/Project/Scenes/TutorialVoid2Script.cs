using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialVoid2Script : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject shadowIcon;
    public GameObject locker;
    public GameObject student;
    public GameObject icon;

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && shadowIcon.activeSelf)
        {
            TutorialHide();
        }
        if (other.CompareTag("Locker") && shadowIcon.activeSelf)
        {
            student.SetActive(false);
            icon.SetActive(true);
            
        }
    }

    void TutorialHide()
    {
        navMeshAgent.destination = locker.transform.position;
    }

}
