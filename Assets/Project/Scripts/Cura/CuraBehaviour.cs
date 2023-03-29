using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class CuraBehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public SpriteRenderer character;
    public GameObject player;
    public GameObject cura;

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
    public bool level0 = true;
    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;

    // Satanic Stars
    public GameObject satanicStar01;
    public GameObject satanicStar02;
    public Animator satanicStar01Animator;
    public Animator satanicStar02Animator;

    //Sounds
    bool canAlertSound = true;
    bool canActiveAlertSound = true;

    //Chase
    public float chaseTimer;
    public float chaseTime;
    public bool canChase = false;
    public bool playerIsVisible = false;

    //Last Seen
    public GameObject lastSeenPlayerIcon;
    bool canGoToLastPos = false;
    public float lastSeenPlayerTimer;
    public float lastSeenPlayerTime;

    bool curaCanSpeedRun = false;

    //Cross
    bool canGoToCross = false;
    public GameObject cross;
    public GameObject crossEnabled;
    public GameObject crossDisabled;

    // Other
    public StarsManager starsManager;
    public float normalSpeed;
    public float runningSpeed;
    public bool canSlowCura = true;


    void Start()
    {
        dangerIcon.SetActive(false);
    }

    void Update()
    {
        if (!dangerIcon.activeSelf)
        {
            navMeshAgent.speed = normalSpeed;
        }
        if (dangerIcon.activeSelf)
        {
            followWaypoints = false;
        }

        //Start at Level 0

        //Level 0 to 1
        if (satanicStar01Animator.GetBool("CanStartSatanicStar01") == true)
        {
            level0 = false;
            level1 = true;
        }

        //Level 1 o 2
        if (satanicStar02Animator.GetBool("CanStartSatanicStar02") == true)
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
            if(level0 && canChase)
            {
                starsManager.canStart1Star = true;
            }

            else if(canChase)
            {
                ChasePlayer();
            }

            else if (canGoToCross)
            {
                GoToCross();
            }

            if (followWaypoints && canChase == false && canGoToCross==false)
            {
                FollowWaypoints();
                dangerIcon.SetActive(false);
            }

            else if (dangerIcon.activeSelf && canChase == false)
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

        if (level0)
        {
            navMeshAgent.speed = runningSpeed;
        }

        if (level1)
        {
            navMeshAgent.speed = runningSpeed;
        }

        if (level2)
        {
            navMeshAgent.speed = runningSpeed;
        }

        if (chaseTimer >= chaseTime && playerIsVisible == false)
        {
            chaseTimer = 0;
            dangerIcon.SetActive(false);
            followWaypoints = true;
            canChase = false;
        }
    }

    void GoToLastPos()
    {
        if(canChase== false)
        {
            navMeshAgent.destination = lastSeenPlayerIcon.transform.position;
        }

        if (navMeshAgent.transform.position.x < lastSeenPlayerIcon.transform.position.x + 20 && navMeshAgent.transform.position.x > lastSeenPlayerIcon.transform.position.x - 20
            && navMeshAgent.transform.position.y < lastSeenPlayerIcon.transform.position.y + 20 && navMeshAgent.transform.position.y > lastSeenPlayerIcon.transform.position.y - 20 ||
            navMeshAgent.transform.position.x < player.transform.position.x + 20 && navMeshAgent.transform.position.x > player.transform.position.x - 20
            && navMeshAgent.transform.position.y < player.transform.position.y + 20 && navMeshAgent.transform.position.y > player.transform.position.y - 20)
        {
            curaCanSpeedRun = true;
        }

        else curaCanSpeedRun = false;

        if (curaCanSpeedRun == false)
        {
            navMeshAgent.speed = 20;
            navMeshAgent.acceleration = 1000;
        }
        else
        {
            navMeshAgent.speed = runningSpeed;
            navMeshAgent.acceleration = 8;
        }

        if (navMeshAgent.transform.position.x < lastSeenPlayerIcon.transform.position.x + 2 && navMeshAgent.transform.position.x > lastSeenPlayerIcon.transform.position.x - 2
            && navMeshAgent.transform.position.y < lastSeenPlayerIcon.transform.position.y + 2 && navMeshAgent.transform.position.y > lastSeenPlayerIcon.transform.position.y - 2)
        {
            lastSeenPlayerTimer += Time.deltaTime;
        }


        if (lastSeenPlayerTimer >= lastSeenPlayerTime)
        {
            lastSeenPlayerTimer = 0;
            dangerIcon.SetActive(false);
            followWaypoints = true;
        }
    }

    void GoToCross()
    {
        navMeshAgent.destination = cross.transform.position;
        if(navMeshAgent.transform.position.x < cross.transform.position.x + 1 && navMeshAgent.transform.position.x > cross.transform.position.x - 1
        && navMeshAgent.transform.position.y < cross.transform.position.y + 1 && navMeshAgent.transform.position.y > cross.transform.position.y - 1)
        {
            cross.tag = "CrossEnabled";
            crossEnabled = cross.transform.GetChild(0).gameObject;
            crossEnabled.SetActive(true);
            crossDisabled= cross.transform.GetChild(1).gameObject;
            crossDisabled.SetActive(false);
           
            crossEnabled = null;
            crossDisabled = null;
            cross = null;
            canGoToCross = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Disabled Cross Effect
        if(other.CompareTag("CrossDisabledRange") &&canChase)
        {
            if(canSlowCura)
            {
                runningSpeed -= 3;
                canSlowCura= false;
            }
        }

        if (level0)
        {
            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                canChase = true;
                playerIsVisible = true;
                chaseTimer= 0;
                dangerIcon.SetActive(true);

                //Audio
                if (canAlertSound)
                {
                    FindObjectOfType<AudioManager>().Play("AlertVoid");
                    canAlertSound = false;
                }
            }

            else if(other.CompareTag("CrossDisabled") )
            {
                canGoToCross= true;
                cross = other.gameObject;
            }
        }

        if (level1 || level2)
        {
            if (other.CompareTag("Player"))
            {
                canChase = true;
                playerIsVisible = true;
                chaseTimer = 0;
                dangerIcon.SetActive(true);
                
                //Audio
                 if (canAlertSound)
                 {
                    FindObjectOfType<AudioManager>().Play("AlertVoid");
                    canAlertSound = false;
                 }
            }

            else if (other.CompareTag("CrossDisabled"))
            {
                canGoToCross = true;
                cross = other.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (level0||level1||level2)
        {
            if (other.CompareTag("Player"))
            {
                playerIsVisible = false;
            }
        }

        //Disabled Cross Effect
        if (other.CompareTag("CrossDisabledRange"))
        {
            if (canSlowCura== false)
            {
                runningSpeed += 3;
                canSlowCura = true;
            }
        }
    }
}