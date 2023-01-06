using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public SpriteRenderer character;
  
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

    // Detector
    public GameObject detector;
    int detectorIncrement = 0;
    //Rincon de llorar

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


    void Start()
    {
      dangerIcon.SetActive(false);
    }

    void Update()
    {
        //CHECK THE LEVEL
       
   

        //Level 0
        if (satanicStar01.activeInHierarchy == false)
        {
            level0= false;
            level1= true;
        }
        if (level0)
        {
            if (followWaypointsLevel0)
            {
                FollowWaypointsLevel0();
            }
            else if(dangerIcon.activeSelf)
            {
                RinconDeLlorarLevel0(); 
            }
        }

        //Level 1
        if (level1)
        {
            if (followWaypointsLevel0)
            {
                FollowWaypointsLevel0();
            }
            else if(canAvoidStudents)
            {
                AvoidStudents();
            }
            else if(dangerIcon.activeSelf)
            {
                HideInHidePlace();
                
            }
            
            //HIDE FUNCTION
            if (canActivateHideTimer)
            {
                hideTimer += Time.deltaTime;
            }
            if (hideTimer >= timeHidden)
            {
                Debug.Log("AAA");
                hideTimer = 0;
                followWaypointsLevel0 = true;
                character.enabled = true;
                myHideIcon.SetActive(false);
                navMeshAgent.speed = 2;
                Debug.Log("A");
                dangerIcon.SetActive(true);
                myHidePlace.tag = "Hide_Place";
                canActivateHideTimer= false;
                myHidePlace = null;
                myHideIcon = null;
            }
        }
    }

    void FollowWaypointsLevel0()
    {
        // Anar cap al waypoint
        navMeshAgent.destination = waypoints[waypointsIndex].transform.position;

        // Si el waypoint == al waypoint final -1, torna a començar la ruta de waypoints
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
                //Començar temporitzador
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
   
    
    void RinconDeLlorarLevel0()
    {
        rinconDeLlorarTimer += Time.deltaTime;
        if(myRinconDeLlorar == null)
        {
            detector.transform.localScale= new Vector3(detectorIncrement, 1, 1);
            detectorIncrement++;
        }
        else
        {
            detector.transform.localScale = new Vector3(1, 1, 1);
            navMeshAgent.destination = myRinconDeLlorar.transform.position;
            navMeshAgent.speed = 3;
            Debug.Log("B");
        }
        if(myRinconDeLlorar!= null)
        {
            if (navMeshAgent.transform.position == myRinconDeLlorar.transform.position)
            {
                //Llora
            }
        }
       
        if(rinconDeLlorarTimer >= timeInRinconDeLlorar)
        {
            dangerIcon.SetActive(false);
            rinconDeLlorarTimer = 0;
        }
       
        //Vuelta a la normalidad
        if(dangerIcon.activeInHierarchy == false)
        {
            myRinconDeLlorar.tag = "Rincon_De_Llorar";
            myRinconDeLlorar = null;
            followWaypointsLevel0 = true;
            navMeshAgent.speed = 2;
            Debug.Log("C");
            if (satanicStar01.activeSelf)
            {
                satanicStar01.SetActive(false);
            }
        }
    }


    void AvoidStudents()
    {
        //waypointsIndex++;
        avoidStudentsTemp+= Time.deltaTime;
        navMeshAgent.speed = 4;
        Debug.Log("D");

        if (avoidStudentsTemp >=3)
        {
            avoidStudentsTemp = 0;
            canAvoidStudents = false;
            followWaypointsLevel0 = true;
            navMeshAgent.speed = 2;
            Debug.Log("E");
        }
    }

    void HideInHidePlace()
    {
       
        //Detectar el HidePlace mas cercano
        if (myHidePlace == null)
        {
            detector.transform.localScale = new Vector3(detectorIncrement, 1, 1);
            detectorIncrement++;
        }
        else
        {
            // Volver a la normalidad una vez encontrado y ir hacia el HidePlace
            detector.transform.localScale = new Vector3(1, 1, 1);
            navMeshAgent.destination = myHidePlace.transform.position;
            navMeshAgent.speed = 3;
            Debug.Log("F");
        }

        if(myHidePlace != null)
        {
            if (navMeshAgent.transform.position.x < myHidePlace.transform.position.x + 2 && navMeshAgent.transform.position.x > myHidePlace.transform.position.x - 2
           && navMeshAgent.transform.position.y < myHidePlace.transform.position.y + 2 && navMeshAgent.transform.position.y > myHidePlace.transform.position.y - 2)
            {
                character.enabled = false;
                myHideIcon = myHidePlace.transform.GetChild(0).gameObject;
                myHideIcon.SetActive(true);
                navMeshAgent.speed = 0;
                Debug.Log("G");
                dangerIcon.SetActive(false);
                canActivateHideTimer = true;
                followWaypointsLevel0 = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(level0)
        {
            if (other.CompareTag("Player") && shadowIcon.activeSelf)
            {
                dangerIcon.SetActive(true);
                followWaypointsLevel0 = false;

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

        if (level1)
        {
            if (other.CompareTag("Target")|| other.CompareTag("Player") && canActivateHideTimer==false)
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
                dangerIcon.SetActive(true);
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
    }   }
}
