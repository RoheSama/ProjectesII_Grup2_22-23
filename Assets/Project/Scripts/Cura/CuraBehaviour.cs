using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuraBehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public SpriteRenderer character;
    public GameObject player;


    //---Follow Waypoints
    public bool followWaypoints = true;

    //Waypoints for FollowWaypoints
    public GameObject[] waypoints;
    int waypointsIndex = 0;

    //Timer
    public int[] timeWaypoints;
    int timeWaypointsIndex = 0;

    float waypointsTimer = 0;
    bool waypointsTimerReached = false;

    //Icono Danger
    public GameObject dangerIcon;
    public GameObject shadowIcon;

    //LEVELS
    bool level0 = true;
    bool level1 = false;
    bool level2 = false;
    bool level3 = false;


    // Satanic Stars
    public GameObject satanicStar01;
    public GameObject satanicStar02;


    //Sounds
    bool canAlertSound = true;
    bool canActiveAlertSound = true;


    //Chase
    float chaseTimer;
    public float chaseTime;

    //Last Seen
    public GameObject lastSeenPlayerIcon;
    bool canGoToLastPos = false;

    void Start()
    {
        dangerIcon.SetActive(false);
        //lastSeenPlayerIcon.SetActive(true);
    }

    void Update()
    {


        //DEBUG
        if (level0)
        {
           // Debug.Log("level0");
        }

        if (level1)
        {
           // Debug.Log("level1");
        }

        if (level2)
        {
           // Debug.Log("level2");
        }

        //Debug.Log(chaseTimer);

        if (!dangerIcon.activeSelf)
        {
            navMeshAgent.speed = 2.0f;
        }

        //Start at Level 0

        //Level 1
        if (satanicStar01.activeInHierarchy == false)
        {
            level0 = false;
            level1 = true;
        }

        //Level2
        if (satanicStar02.activeInHierarchy == false)
        {
            level1 = false;
            level2 = true;
        }

        //Audio
        if (canActiveAlertSound)
        {
            canAlertSound = true;
            canActiveAlertSound = false;
        }

        //Chase 
        if (level0 || level1 || level2)
        {
            if (followWaypoints)
            {
                FollowWaypoints();
                dangerIcon.SetActive(false);
            }

            else if (dangerIcon.activeSelf)
            {
                GoToLastPos();
            }
        }
    }

    void FollowWaypoints()
    {
        // Anar cap al waypoint
        navMeshAgent.destination = waypoints[waypointsIndex].transform.position;

        // Si el waypoint == al waypoint final -1, torna a comen ar la ruta de waypoints
        if (waypointsIndex == waypoints.Length - 1)
        {
            // Reset Index
            waypointsIndex = 0;
            timeWaypointsIndex = 0;
        }

        // Si arribes al waypoint
        else if (transform.position == navMeshAgent.destination)
        {
            if (!waypointsTimerReached)
            {
                //Iniciar temporitzador
                waypointsTimer += Time.deltaTime;
            }

            if (!waypointsTimerReached && waypointsTimer >= timeWaypoints[timeWaypointsIndex])
            {
                // Index++
                waypointsIndex++;
                timeWaypointsIndex++;
                waypointsTimerReached = true;
            }

            // Si arribes al waypointsTimer
            if (waypointsTimerReached)
            {
                waypointsTimerReached = false;
                waypointsTimer = 0;
            }
        }
    }


    void ChasePlayer()
    {
        // navMeshAgent.destination = lastSeenPlayerIcon.transform.position;
        navMeshAgent.destination = player.transform.position;

        chaseTimer += Time.deltaTime;

        if (level0)
        {
            navMeshAgent.speed = 3.0f;
            // lastSeenPlayerIcon.SetActive(true);
        }

        if (level1)
        {
            navMeshAgent.speed = 4.0f;
            //lastSeenPlayerIcon.SetActive(true);
        }

        if (level2)
        {
            navMeshAgent.speed = 4.0f;
            // lastSeenPlayerIcon.SetActive(true);
        }

        if (chaseTimer >= chaseTime)
        {
            chaseTimer = 0;
            dangerIcon.SetActive(false);
            followWaypoints = true;

            if (level0)
            {
                satanicStar01.SetActive(false);
            }

            if (level1)
            {
                satanicStar02.SetActive(false);
            }
        }
    }

    void GoToLastPos()
    {
        navMeshAgent.destination = lastSeenPlayerIcon.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (level0)
        {
            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                //dangerIcon.SetActive(true);
                //followWaypoints = false;
                // lastSeenPlayerIcon.SetActive(true);
                //lastSeenPlayerIcon.transform.position = player.transform.position;

                //Audio
                if (canAlertSound)
                {
                    FindObjectOfType<AudioManager>().Play("AlertVoid");
                    canAlertSound = false;
                }
            }
        }

        if (level1 || level2)
        {
            if (other.CompareTag("Player"))
            {
                //dangerIcon.SetActive(true);
                //followWaypoints = false;
                //lastSeenPlayerIcon.SetActive(true);
                //lastSeenPlayerIcon.transform.position = player.transform.position;

                //Audio
                if (canAlertSound)
                {
                    FindObjectOfType<AudioManager>().Play("AlertVoid");
                    canAlertSound = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (level0)
        {
            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                // lastSeenPlayerIcon.transform.position = player.transform.position;
                // lastSeenPlayerIcon.SetActive(true);
            }
        }


        if (level1 || level2)
        {
            if (other.CompareTag("Player"))
            {
                // lastSeenPlayerIcon.transform.position = player.transform.position;
                //lastSeenPlayerIcon.SetActive(true);

                /*if (chaseTimer > 0)
                {
                    chaseTimer = 0;
                }*/
            }
        }
    }
}