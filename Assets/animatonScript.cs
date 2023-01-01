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

    bool isUp = false;
    bool isDown = false;
    bool isLeft = false;
    bool isRight = false;

    bool canUp = true;
    bool canDown = true;
    bool canLeft = true;
    bool canRight = true;

    public float timeCounter = 0;


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
        if (diferrenceLastPositionYAndActualPositionY == 0)
        {
            animator.SetBool("MoveDown", true);
            animator.SetBool("MoveUp", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", false);
        }

        ////Move Left
        if (diferrenceLastPositionXAndActualPositionX >0.2)
        {
            animator.SetBool("MoveLeft", true);
            animator.SetBool("MoveDown", false);
            animator.SetBool("MoveUp", false);
            animator.SetBool("MoveRight", false);
        }

        ////Move Right
        if (diferrenceLastPositionXAndActualPositionX < -0.2)
        {
            animator.SetBool("MoveRight", true);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveDown", false);
            animator.SetBool("MoveUp", false);
        }

        ////Move Up
        if (diferrenceLastPositionYAndActualPositionY < -1)
        {
            animator.SetBool("MoveUp", true);
            animator.SetBool("MoveDown", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", false);
        }       
    }
}
