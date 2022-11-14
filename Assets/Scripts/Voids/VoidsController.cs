using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VoidsController : MonoBehaviour
{
    private Animator anim;

    public float actualSpeed = 10.0f;
    public GameObject[] checkpoints;
    int counter = 0;
    public float distance = 2.0f; //on which distance you want to switch to the next waypoint
    Vector2 direction;

    private int orientation = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        direction = Vector2.zero;
        //get the vector from your position to current waypoint
        direction = checkpoints[counter].transform.position - transform.position;
        //check our distance to the current waypoint, Are we near enough?
        if (direction.magnitude < distance)
        {
            if (counter < checkpoints.Length - 1) //switch to the nex waypoint if exists
            {
                counter++;
            }
            else //begin from new if we are already on the last waypoint
            {
                counter = 0;
            }
        }
        direction = direction.normalized;
        Vector2 dir = direction;

        //Run animation
        anim.SetBool("isRun", direction.sqrMagnitude > 0.0001f);

        //Set animator direction
        if (direction.x > 0.0001f)
            orientation = 1;
        else if (direction.x < -0.0001f)
            orientation = -1;

        transform.localScale = new Vector3(orientation, 1, 1);

        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * actualSpeed, direction.y * actualSpeed);
    }
}
