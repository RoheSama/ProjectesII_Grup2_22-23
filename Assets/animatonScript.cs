using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animatonScript : MonoBehaviour
{
    public int speed;
    public Animator animator;
    public NavMeshAgent navmeshAgent;

    public float actualPositionX;
    public float actualPositionY;
   
    public float lastPositionX;
    public float lastPositionY;

    public float diferrenceLastPositionXAndActualPositionX = 0;
    public float diferrenceLastPositionYAndActualPositionY = 0;

    public float leftValue = 0;
    public float rightValue = 0;
    public float upValue = 0;
    public float downValue = 0;

    public float timeCounter = 0;

    //Range Vision
    public GameObject visionRangeDown;
    public GameObject visionRangeUp;
    public GameObject visionRangeLeft;
    public GameObject visionRangeRight;


    void Start()
    {
       
    }

    void Update()
    {
        timeCounter += Time.deltaTime;

        //animator.SetFloat("Speed", speed);

        actualPositionX = navmeshAgent.transform.position.x;
        actualPositionY = navmeshAgent.transform.position.y;
        diferrenceLastPositionXAndActualPositionX = (lastPositionX - actualPositionX);
        diferrenceLastPositionYAndActualPositionY = (lastPositionY - actualPositionY);

        if (timeCounter >= 0.5f)
        {
            lastPositionX = actualPositionX;
            lastPositionY = actualPositionY;
            timeCounter = 0;
        }

        
        //Move Down
        if (diferrenceLastPositionYAndActualPositionY > downValue) //0
        {
            animator.SetBool("MoveDown", true);
            animator.SetBool("MoveUp", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", false);
            if(visionRangeDown!= null)
            {
                visionRangeDown.SetActive(true);
                visionRangeUp.SetActive(false);
                visionRangeLeft.SetActive(false);
                visionRangeRight.SetActive(false);
            }
         
        }

        ////Move Left
        if (diferrenceLastPositionXAndActualPositionX >leftValue) //0.2
        {
            animator.SetBool("MoveLeft", true);
            animator.SetBool("MoveDown", false);
            animator.SetBool("MoveUp", false);
            animator.SetBool("MoveRight", false);
            if (visionRangeDown != null)
            {
                visionRangeDown.SetActive(false);
                visionRangeUp.SetActive(false);
                visionRangeLeft.SetActive(true);
                visionRangeRight.SetActive(false);
            }
             
        }

        ////Move Right
        if (diferrenceLastPositionXAndActualPositionX < rightValue) //-0.2
        {
            animator.SetBool("MoveRight", true);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveDown", false);
            animator.SetBool("MoveUp", false);
            if (visionRangeDown != null)
            {
                visionRangeDown.SetActive(false);
                visionRangeUp.SetActive(false);
                visionRangeLeft.SetActive(false);
                visionRangeRight.SetActive(true);
            }
              
        }

        ////Move Up
        if (diferrenceLastPositionYAndActualPositionY < upValue) //-1
        {
            animator.SetBool("MoveUp", true);
            animator.SetBool("MoveDown", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", false);
            if (visionRangeDown != null)
            {
                visionRangeDown.SetActive(false);
                visionRangeUp.SetActive(true);
                visionRangeLeft.SetActive(false);
                visionRangeRight.SetActive(false);
            }
               
        }      
    }
    
}
