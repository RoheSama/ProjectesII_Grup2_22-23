using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class IABehaviour : MonoBehaviour
{
    //Player NavMesh
    public TopDownMovement playerMovement;
    public CuraBehaviour curaBehaviour;

    //Void
    public NavMeshAgent navMeshAgent;
    public SpriteRenderer character;
    public Animator animator;

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
    public GameObject satanicStar02;
    public Animator satanicStar01Animator;
    public Animator satanicStar02Animator;

    public StarsManager starsManager;

    // Detector
    public CircleCollider2D detector;
    float detectorIncrement = 0;

    //Waypoints for Rincon De Llorar Function
    bool goToRinconDeLlorar = true;
    public GameObject myRinconDeLlorar;

    // Rincon de Llorar Timer
    float rinconDeLlorarTimer = 0;
    public int timeInRinconDeLlorar;

    //Avoid Students
    bool canAvoidStudents = false;
    float avoidTemp = 0;
    float avoidStudentsTemp = 0;

    //Hide
    bool goToHide = true;
    bool canHide = false;
    bool canActivateHideTimer = false;
    public float hideTimer = 0;
    public int timeHidden;
    public GameObject myHidePlace;
    public GameObject myHideIcon;
    public GameObject myHideTileMap;

    //Sounds
    bool canAlertSound = true;
    bool canActiveAlertSound = true;

    public AudioSourceVoids audioSourceVoids;

    //Attack 
    bool canAttack = false;
    float attackTimer;
    public float attackTime;

    //Void Behaviour
    public bool isDead = false;
    public bool canDie = true;

    //Trail
    public TrailRenderer trailRenderer;
    public GameObject shadow;

    public bool standInTable = false;
    public PlayerHealth playerHealth;
    private bool canIncreasePlayerHealth = true;

    void Start()
    {
        shadow.SetActive(true);
        shadow.SetActive(false);
    }

    void Update()
    {
            //Audio
            if (canActiveAlertSound)
            {
            canAlertSound = true;
            canActiveAlertSound = false;
            }

        if(isDead)
        {
            //Hacer que el void salga si ha entrado en un escondite mientras mor�a (BUGS)
            if(canIncreasePlayerHealth)
            {
                playerHealth.health += 0.05f;
                canIncreasePlayerHealth = false;
            }

            navMeshAgent.enabled = false;
            hideTimer = 100;
            //Desactivar Ataque si el student muere
            attackTimer = 100;
        }

        if (shadow.activeSelf)
        {
            trailRenderer.enabled = true;
        }
        else trailRenderer.enabled = false;

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

        if (level0)
        {
            if(standInTable)
            {
                navMeshAgent.speed = 0;
                animator.SetBool("CanCry", false);
                animator.SetBool("IdleUp", false);
                animator.SetBool("IdleDown", true);
                animator.SetBool("IdleLeft", false);
                animator.SetBool("IdleRight", false);
                animator.SetBool("MoveUp", false);
                animator.SetBool("MoveDown", false);
                animator.SetBool("MoveLeft", false);
                animator.SetBool("MoveRight", false);
                animator.SetBool("CanAttack", false);
            }

            if (followWaypointsLevel0 && standInTable==false)
            {
                FollowWaypoints();
                dangerIcon.SetActive(false);
            }

            else if (dangerIcon.activeSelf)
            {
                if(satanicStar02Animator.GetBool("CanStartSatanicStar02") == false)
                {
                    starsManager.canStart1Star = true;
                    standInTable= false;
                    RinconDeLlorar();
                }
            }
        }

        //Level 1
        if (level1)
        {
            if (dangerIcon.activeSelf)
            {
                HideInHidePlace();
            }

            if (canAvoidStudents && dangerIcon.activeInHierarchy == false)
            {
                AvoidStudents();
            }

            if (followWaypointsLevel0 && dangerIcon.activeInHierarchy == false)
            {
                FollowWaypoints();
                dangerIcon.SetActive(false);
            }


            //HIDE FUNCTION FINISHED
            if (canActivateHideTimer)
            {
                hideTimer += Time.deltaTime;
            }

            if (hideTimer >= timeHidden)
            {
                hideTimer = 0;
                followWaypointsLevel0 = true;
                character.enabled = true;
                myHideIcon.SetActive(false);
                navMeshAgent.speed = 2;
                dangerIcon.SetActive(false);
                myHidePlace.tag = "Hide_Place";
                canActivateHideTimer = false;
                myHidePlace = null;
                myHideIcon = null;
                myHideTileMap = null;
                canAlertSound = true;
                canDie = true;
            }
        }

        //Level2
        if (level2)
        {
            if (dangerIcon.activeSelf)
            {
                VoidAttack();
            }

            if (canAvoidStudents && dangerIcon.activeInHierarchy == false)
            {
                AvoidStudents();
            }

            if (followWaypointsLevel0 || dangerIcon.activeInHierarchy == false)
            {
                FollowWaypoints();
                if (avoidStudentsTemp == 0)
                {
                    navMeshAgent.speed = 4;
                }
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
                //Comen ar temporitzador
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
    void RinconDeLlorar()
    {
        rinconDeLlorarTimer += Time.deltaTime;
        if (myRinconDeLlorar == null)
        {
            detector.radius = (detectorIncrement);
            detectorIncrement++;
        }

        else
        {
            detector.transform.localScale = new Vector3(1, 1, 1);
            navMeshAgent.destination = myRinconDeLlorar.transform.position;
            navMeshAgent.speed = 5;

            if (navMeshAgent.transform.position.x < myRinconDeLlorar.transform.position.x + 2 && navMeshAgent.transform.position.x > myRinconDeLlorar.transform.position.x - 2
            && navMeshAgent.transform.position.y < myRinconDeLlorar.transform.position.y + 2 && navMeshAgent.transform.position.y > myRinconDeLlorar.transform.position.y - 2)
            {
                animator.SetBool("CanCry", true);
                animator.SetBool("IdleUp", false);
                animator.SetBool("IdleDown", false);
                animator.SetBool("IdleLeft", false);
                animator.SetBool("IdleRight", false);
                animator.SetBool("MoveUp", false);
                animator.SetBool("MoveDown", false);
                animator.SetBool("MoveLeft", false);
                animator.SetBool("MoveRight", false);
                animator.SetBool("CanAttack", false);
            }
        }

        if (rinconDeLlorarTimer >= timeInRinconDeLlorar)
        {
            dangerIcon.SetActive(false);
            rinconDeLlorarTimer = 0;
        }

        //Vuelta a la normalidad
        if (dangerIcon.activeInHierarchy == false)
        {
            myRinconDeLlorar.tag = "Rincon_De_Llorar";
            myRinconDeLlorar = null;
            followWaypointsLevel0 = true;
            navMeshAgent.speed = 2;
        }
    }

    void AvoidStudents()
    {
        avoidStudentsTemp += Time.deltaTime;
        if (level1)
        {
            navMeshAgent.speed = 4;
        }

        if (level2)
        {
            navMeshAgent.speed = 6;
        }

        if (avoidStudentsTemp >= 3)
        {
            avoidStudentsTemp = 0;
            canAvoidStudents = false;
            followWaypointsLevel0 = true;
            navMeshAgent.speed = 2;
        }
    }
    void HideInHidePlace()
    {
        //Detectar el HidePlace mas cercano
        if (myHidePlace == null)
        {
            detector.radius = detectorIncrement;
            detectorIncrement++;
        }

        else
        {
            // Volver a la normalidad una vez encontrado y ir hacia el HidePlace
            detector.radius = 1.0f;
            navMeshAgent.destination = myHidePlace.transform.position;
            navMeshAgent.speed = 5;
        }

        if (myHidePlace != null)
        {
            if (navMeshAgent.transform.position.x < myHidePlace.transform.position.x + 2 && navMeshAgent.transform.position.x > myHidePlace.transform.position.x - 2
            && navMeshAgent.transform.position.y < myHidePlace.transform.position.y + 2 && navMeshAgent.transform.position.y > myHidePlace.transform.position.y - 2)
            {
                character.enabled = false;
                myHideIcon = myHidePlace.transform.GetChild(0).gameObject;
                myHideTileMap = myHidePlace.transform.GetChild(1).gameObject;
                myHideIcon.SetActive(true);
                myHideTileMap.SetActive(true);
                navMeshAgent.speed = 0;
                dangerIcon.SetActive(false);
                canActivateHideTimer = true;
                followWaypointsLevel0 = false;
                canDie = false;
                audioSourceVoids.hideVoidOn();
            }
        }
    }

    void VoidAttack()
    {
        attackTimer += Time.deltaTime;
        navMeshAgent.speed = 0;
        playerMovement.shadowSpeed = 1;

        animator.SetBool("CanCry", false);
        animator.SetBool("IdleUp", false);
        animator.SetBool("IdleDown", false);
        animator.SetBool("IdleLeft", false);
        animator.SetBool("IdleRight", false);
        animator.SetBool("MoveUp", false);
        animator.SetBool("MoveDown", false);
        animator.SetBool("MoveLeft", false);
        animator.SetBool("MoveRight", false);
        animator.SetBool("CanAttack", true);

        if (attackTimer >= attackTime)
        {
            dangerIcon.SetActive(false);
            navMeshAgent.speed = 2;
            playerMovement.shadowSpeed = 8;
            attackTimer= 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Level 0 Colliders
        if (level0)
        {   
            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                dangerIcon.SetActive(true);
                curaBehaviour.dangerIcon.SetActive(true);
                curaBehaviour.followWaypoints = false;
                curaBehaviour.lastSeenPlayerIcon.transform.position = new Vector3(dangerIcon.transform.position.x, dangerIcon.transform.position.y-1, dangerIcon.transform.position.z);
                followWaypointsLevel0 = false;

                //Audio
                if (canAlertSound)
                {
                    FindObjectOfType<AudioManager>().Play("AlertVoid");
                    canAlertSound = false;
                }
            }

            else if (goToRinconDeLlorar)
            {
                if (other.CompareTag("Rincon_De_Llorar"))
                {
                    myRinconDeLlorar = other.gameObject;
                    myRinconDeLlorar.tag = "Rincon_De_Llorar_Disabled";
                }
            }
        }

        //Level 1 Colliders
        if (level1)
        {
            if (other.CompareTag("Target") || other.CompareTag("Player") && canActivateHideTimer == false)
            {
                avoidTemp += Time.deltaTime;
                if (avoidTemp >= 1)
                {
                    followWaypointsLevel0 = false;
                    canAvoidStudents = true;
                    avoidTemp = 0;
                }
            }

            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                //Audio
                if (canAlertSound)
                {
                    FindObjectOfType<AudioManager>().Play("AlertVoid");
                    canAlertSound = false;
                }
                dangerIcon.SetActive(true);
                curaBehaviour.dangerIcon.SetActive(true);
                curaBehaviour.followWaypoints = false;
                curaBehaviour.lastSeenPlayerIcon.transform.position = new Vector3(dangerIcon.transform.position.x, dangerIcon.transform.position.y - 1, dangerIcon.transform.position.z);
                followWaypointsLevel0 = false;
            }

            else if (goToHide)
            {
                if (other.CompareTag("Hide_Place"))
                {
                    myHidePlace = other.gameObject;
                    myHidePlace.tag = "Hide_Place_Disabled";
                }
            }
        }

        //Level 2 Colliders
        if (level2)
        {
            if (other.CompareTag("Player") && dangerIcon.activeSelf)
            {
                canAttack = true;
                attackTimer = 0;
            }

            if (other.CompareTag("Target") || other.CompareTag("Player") && dangerIcon.activeInHierarchy == false)
            {
                followWaypointsLevel0 = false;
                canAvoidStudents = true;
                avoidTemp = 0;
            }

            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                //Audio
                if (canAlertSound)
                {
                    FindObjectOfType<AudioManager>().Play("AlertVoid");
                    canAlertSound = false;
                }
                dangerIcon.SetActive(true);
                curaBehaviour.dangerIcon.SetActive(true);
                curaBehaviour.followWaypoints = false;
                curaBehaviour.lastSeenPlayerIcon.transform.position = new Vector3(dangerIcon.transform.position.x, dangerIcon.transform.position.y - 1, dangerIcon.transform.position.z);
                followWaypointsLevel0 = false;
            }
        }
    }
}