using ClearSky;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    private int orientation = 1;

    private float distance;
    [SerializeField]
    private float attackDamage = 10f;
    [SerializeField]
    private float attackSpeed = 1f;
    [SerializeField]
    private float canAttack;

    private Animator anim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();

        anim.SetBool("isRun", direction.sqrMagnitude > 0.0001f);

        if (direction.x > 0.0001f)
            orientation = 1;
        else if (direction.x < -0.0001f)
            orientation = -1;

        transform.localScale = new Vector3(orientation, 1, 1);

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(attackSpeed <= canAttack)
            {
                collision.gameObject.GetComponent<PlayerMovement>().Hurt();
                collision.gameObject.GetComponent<PlayerMovement>().UpdateHealth(-attackDamage);
                Debug.Log("HIT");
                canAttack = 0f;
            } 
            else
            {
                canAttack += Time.deltaTime;
            }
           
        }
    }
}
