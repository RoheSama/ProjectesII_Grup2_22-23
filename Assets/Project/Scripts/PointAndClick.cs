using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PointAndClick : MonoBehaviour
{
    private Vector3 target;
    NavMeshAgent agent;

    //others
    public float health = 0f;
    [SerializeField]
    private float maxHealth = 100f;
    public bool alive = true;
    public Animator anim;
    private Rigidbody2D rb;

    int number = 0;
    bool couroutineStarted = false;

    public float movePower = 10f;
    private int direction = 1;
    Vector2 moveVelocity;



    void Start()
    {
        //Navmesh DONT ERASE
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //health 
        health = maxHealth;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            SetTargetPosition();
            SetAgentPosition();
            Die();
        }
    }

    void SetTargetPosition() //Sets the target position that our agent is following everytime you click
    {
        if (Input.GetMouseButtonDown(1)) //Right Click
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void SetAgentPosition()
    {
        agent.SetDestination(moveVelocity = new Vector3(target.x, target.y, transform.position.z));
        anim.SetBool("Walk", true);
            
    }


    public void Hurt()
    {
        anim.SetTrigger("hurt");
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
        }

    }

    void Die()
    {
        if (health <= 0)
        {
            Debug.Log("LOSE");
            health = 0;
            anim.SetTrigger("die");
            alive = false;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");

    }
}
