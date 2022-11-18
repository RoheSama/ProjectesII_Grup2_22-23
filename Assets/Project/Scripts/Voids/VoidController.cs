using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class VoidController : MonoBehaviour
{
    private int decisionClock = 0;
    private int decisionTime = 220;

    private Vector2 direction = Vector2.zero;

    public float movePower = 350.4f;

    private Animator anim;
    private Rigidbody2D rb;

    private int orientation = 1;

    //navmesh
    private Vector3 target;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //navmesh
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Tick();
        Move();
    }

    private void Move()
    {
        //Run animation
        anim.SetBool("isRun", direction.sqrMagnitude > 0.0001f);

        //Set animator direction
        if (direction.x > 0.0001f)
            orientation = 1;
        else if (direction.x < -0.0001f)
            orientation = -1;

        transform.localScale = new Vector3(orientation, 1, 1);

        rb.AddForce(direction * movePower * Time.fixedDeltaTime, ForceMode2D.Force);
    }
    private void Tick()
    {
        decisionClock++;
        if(decisionClock > decisionTime)
        {
            decisionClock = 0;

            direction = GetDirection();
            

        }
    }

    private Vector2 GetDirection()
    {
        System.Random random = new System.Random();

        Vector3 newDirection = new Vector3(random.Next(-1, 2), random.Next(-1, 2), 0);

        return ToIso(newDirection.normalized);

    }

    private Vector3 ToIso(Vector3 cartesianVector)
    {
        return new Vector3(cartesianVector.x - cartesianVector.y,
            (cartesianVector.x + cartesianVector.y) / 2,0);
    }
}
