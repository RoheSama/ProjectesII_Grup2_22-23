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
    bool followWaypointsLevel0 = true;

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


    //Sounds
    bool canAlertSound = true;
    bool canActiveAlertSound = true;


    //Chase
    float chaseTimer;
    public float chaseTime;

    public GameObject globalDangerIcon;
    public GameObject[] globalDangerIcons;

    void Start()
    {
        dangerIcon.SetActive(false);
    }

    void Update()
    {
        //CHECK THE LEVEL

        if(level0)
        {
            Debug.Log("LEVEL 0");
        }
        if (level1)
        {
            Debug.Log("LEVEL 1");
        }

        if (globalDangerIcons[0].activeSelf || globalDangerIcons[1].activeSelf || globalDangerIcons[2].activeSelf || globalDangerIcons[3].activeSelf || globalDangerIcons[4].activeSelf || globalDangerIcons[5].activeSelf || globalDangerIcons[6].activeSelf)
        {
            followWaypointsLevel0 = false;
        }

       if(dangerIcon.activeSelf)
        {
            navMeshAgent.speed = 3.0f;
            globalDangerIcon.SetActive(true);

        }
        else if (!dangerIcon.activeSelf)
        {
            globalDangerIcon.SetActive(false);
        }

        else
        {
            navMeshAgent.speed = 2.0f;
        }

        //Level 0
        if (satanicStar01.activeInHierarchy == false)
        {
            level0 = false;
            level1 = true;
            
            //Audio
            if (canActiveAlertSound)
            {
                canAlertSound = true;
                canActiveAlertSound = false;
            }
        }

        //Chase 
        if (level0 || level1)

        {
            if (followWaypointsLevel0)
            {
                FollowWaypointsLevel0();
                dangerIcon.SetActive(false);
            }

            else if (globalDangerIcons[0].activeSelf || globalDangerIcons[1].activeSelf || globalDangerIcons[2].activeSelf || globalDangerIcons[3].activeSelf || globalDangerIcons[4].activeSelf || globalDangerIcons[5].activeSelf || globalDangerIcons[6].activeSelf)
            {
                ChasePlayer();
            }
        }
    }

    void FollowWaypointsLevel0()
    {
        // Anar cap al waypoint
        navMeshAgent.destination = waypoints[waypointsIndex].transform.position;

        // Si el waypoint == al waypoint final -1, torna a comen�ar la ruta de waypoints
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
                //Comen�ar temporitzador
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
        navMeshAgent.destination = player.transform.position;
        chaseTimer += Time.deltaTime;

        if (chaseTimer>= chaseTime)
        {
            chaseTimer = 0;
            dangerIcon.SetActive(false);
            followWaypointsLevel0= true;

            if(level0)
            {
                satanicStar01.SetActive(false);
            }
        }  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (level0)
        {
            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                //dangerIcon.SetActive(true);
                followWaypointsLevel0 = false;

                //Audio
                if (canAlertSound)
                {
                    AudioManager.Instance.Play("AlertVoid", this.gameObject);
                    canAlertSound = false;
                }
            }
        }

        if (level1)
        {
            if (other.CompareTag("Player"))
            {
                dangerIcon.SetActive(true);
                followWaypointsLevel0 = false;

                //Audio
                if (canAlertSound)
                {
                    AudioManager.Instance.Play("AlertVoid", this.gameObject);
                    canAlertSound = false;
                }
            }
        }
    }
}
