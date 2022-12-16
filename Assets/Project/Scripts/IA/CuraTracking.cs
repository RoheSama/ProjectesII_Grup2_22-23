using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuraTracking : MonoBehaviour
{
    public Transform Player;
    NavMeshAgent agent;
    [SerializeField]
    private AbilityUI player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.powerUpActivated)
        {
            agent.SetDestination(Player.position);
        }
    }
}
