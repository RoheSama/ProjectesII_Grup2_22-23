using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
    private float maxHealth = 1f;
    public bool alive = true;
    public Animator anim;
    private Rigidbody2D rb;

    int number = 0;
    bool couroutineStarted = false;

    public float movePower = 10f;
    private int direction = 1;
    Vector2 moveVelocity;

    bool canSlow = false;

    public GameObject bloodDie;
    public GameObject camera;

    public GameObject playerPos;

    //private float powerUpSpeed = 1.5f;

    //private bool powerUpAvailable = true;
    //public bool powerUpActivated = false;

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

        target = playerPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            SetTargetPosition();
            SetAgentPosition();
            Die();
            //if (powerUpAvailable)
            //{
            //    PowerUp();
            //}
            if(canSlow == true)
            {
                Debug.Log("RELANTIZAO");
                agent.speed = 0.5f;
            }
            else
                agent.speed = 3.5f;
        }
    }

    void SetTargetPosition() //Sets the target position that our agent is following everytime you click
    {
        if (Input.GetMouseButtonDown(1)) //Right Click
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           // canSlow= false;
        }
    }

    void SetAgentPosition()
    {
        agent.SetDestination(moveVelocity = new Vector3(target.x, target.y, transform.position.z));
       // anim.SetBool("Walk", true);         
    }

    public void Hurt()
    {
        anim.SetTrigger("hurt");
        camera.GetComponent<CameraController>().start = true;
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
            //anim.SetTrigger("die");
            //Destroy(gameObject);
            alive = false;
            StartCoroutine(Wait());
            Instantiate(bloodDie, transform.position, Quaternion.identity);
            this.enabled = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack Range"))
        {
            canSlow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Attack Range"))
        {
            canSlow = false;
        }
    }

}
