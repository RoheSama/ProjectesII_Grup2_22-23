using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TopDownController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    public float movementSpeed;
    private Vector2 movementInput;

    private Vector3 target;
    NavMeshAgent agent;

    Vector2 moveVelocity;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       agent.updateRotation = false;
       agent.updateUpAxis = false;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition();
        Move();
        Animate();
    }

    void SetTargetPosition() //Sets the target position that our agent is following everytime you click
    {
        if (Input.GetMouseButtonDown(1)) //Right Click
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // canSlow= false;
            direction = target;
        }
        
    }

    private void Move()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");

        if (direction.x == 0 && direction.y == 0)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        movementInput = new Vector2(direction.x, direction.y);
        //rb.velocity = movementInput * movementSpeed * Time.deltaTime;
        agent.SetDestination(moveVelocity = new Vector3(target.x, target.y, transform.position.z));


    }

    private void Animate()
    {
        anim.SetFloat("MovementX", movementInput.x);
        anim.SetFloat("MovementY", movementInput.y);
    }
}
