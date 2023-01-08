using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuraAnimationScript : MonoBehaviour
{
    public float speed;
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

        //  animator.SetFloat("Speed", speed);

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

        if (!animator.GetBool("CanCry" ))
        {



            //Move Down
            if (diferrenceLastPositionYAndActualPositionY > downValue) //0
            {
                animator.SetBool("MoveDown", true);
                animator.SetBool("MoveUp", false);
                animator.SetBool("MoveLeft", false);
                animator.SetBool("MoveRight", false);
                if (visionRangeDown != null)
                {
                    visionRangeDown.SetActive(true);
                    visionRangeUp.SetActive(false);
                    visionRangeLeft.SetActive(false);
                    visionRangeRight.SetActive(false);
                }

                //if (animator.GetBool("CanCry"))
                //{
                //    animator.SetBool("CanCry", false);
                //}
            }

            ////Move Left
            if (diferrenceLastPositionXAndActualPositionX > leftValue) //0.2
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

                //if (animator.GetBool("CanCry"))
                //{
                //    animator.SetBool("CanCry", false);
                //}
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

                //if (animator.GetBool("CanCry"))
                //{
                //    animator.SetBool("CanCry", false);
                //}

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

                //if (animator.GetBool("CanCry"))
                //{
                //    animator.SetBool("CanCry", false);
                //}

            }

            if (diferrenceLastPositionXAndActualPositionX == 0 && diferrenceLastPositionYAndActualPositionY == 0)
            {
                if (animator.GetBool("MoveDown"))
                {
                    animator.SetBool("MoveDown", false);
                    animator.SetBool("IdleDown", true);
                }
                if (animator.GetBool("MoveUp"))
                {
                    animator.SetBool("MoveUp", false);
                    animator.SetBool("IdleUp", true);
                }
                if (animator.GetBool("MoveLeft"))
                {
                    animator.SetBool("MoveLeft", false);
                    animator.SetBool("IdleLeft", true);
                }
                if (animator.GetBool("MoveRight"))
                {
                    animator.SetBool("MoveRight", false);
                    animator.SetBool("IdleRight", true);
                }
            }

            if (diferrenceLastPositionXAndActualPositionX != 0 && diferrenceLastPositionYAndActualPositionY != 0)
            {
                if (animator.GetBool("IdleDown"))
                {
                    animator.SetBool("MoveDown", true);
                    animator.SetBool("IdleDown", false);
                }
                if (animator.GetBool("IdleUp"))
                {
                    animator.SetBool("MoveUp", true);
                    animator.SetBool("IdleUp", false);
                }
                if (animator.GetBool("IdleLeft"))
                {
                    animator.SetBool("MoveLeft", true);
                    animator.SetBool("IdleLeft", false);
                }
                if (animator.GetBool("IdleRight"))
                {
                    animator.SetBool("MoveRight", true);
                    animator.SetBool("IdleRight", false);
                }


            }
        }
    }

}
