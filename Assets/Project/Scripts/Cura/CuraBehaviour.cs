using System.Collections;
using System.Collections.Generic;
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
    bool level0 = true;
    bool level1 = false;
    bool level2 = false;
    bool level3 = false;

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
    bool canChase = false;
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


    void Start()
    {
        dangerIcon.SetActive(false);
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
            navMeshAgent.speed = 3.0f;
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
            if(canChase)
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

        if (level0)
        {
            navMeshAgent.speed = 7.0f;
            // lastSeenPlayerIcon.SetActive(true);
        }

        if (level1)
        {
            navMeshAgent.speed = 7.0f;
            //lastSeenPlayerIcon.SetActive(true);
        }

        if (level2)
        {
            navMeshAgent.speed = 7.0f;
            // lastSeenPlayerIcon.SetActive(true);
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

        if (navMeshAgent.transform.position.x < lastSeenPlayerIcon.transform.position.x + 13 && navMeshAgent.transform.position.x > lastSeenPlayerIcon.transform.position.x - 13
            && navMeshAgent.transform.position.y < lastSeenPlayerIcon.transform.position.y + 13 && navMeshAgent.transform.position.y > lastSeenPlayerIcon.transform.position.y - 13 ||
            navMeshAgent.transform.position.x < player.transform.position.x + 13 && navMeshAgent.transform.position.x > player.transform.position.x - 13
            && navMeshAgent.transform.position.y < player.transform.position.y + 13 && navMeshAgent.transform.position.y > player.transform.position.y - 13)
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
            navMeshAgent.speed = 6.0f;
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
            crossEnabled= cross.transform.GetChild(0).gameObject;
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
        if (level0)
        {
            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                canChase = true;
                playerIsVisible = true;
                dangerIcon.SetActive(true);
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
                dangerIcon.SetActive(true);
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
                // lastSeenPlayerIcon.transform.position = player.transform.position;
                // lastSeenPlayerIcon.SetActive(true);
            }
        }

        //if (level1 || level2)
        //{
        //    if (other.CompareTag("Player"))
        //    {
        //        playerIsVisible = false;
        //        // lastSeenPlayerIcon.transform.position = player.transform.position;
        //        //lastSeenPlayerIcon.SetActive(true);

        //        /*if (chaseTimer > 0)
        //        {
        //            chaseTimer = 0;
        //        }*/
        //    }
        //}
    }
}