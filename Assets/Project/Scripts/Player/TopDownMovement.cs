using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TopDownMovement : MonoBehaviour
{
    public Animator anim;

    public float moveSpeed;

    private Rigidbody2D rb;

    private float x;
    private float y;

    private Vector2 input;
    private bool moving;
    private bool moved = false;
    public float shadowSpeed;
    public GameObject shadow;
    public  float violetSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        GetInput();
        Animate();
        if(shadow.activeSelf)
        {
            moveSpeed = shadowSpeed;
        }
        else
        {
            moveSpeed = violetSpeed;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");

        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }

    private void Animate()
    {
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
            moved = false;
        }
        else
        {
            moving = false;
            moved = true;
        }

        if (moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }
        if(moved)
        {
            FindObjectOfType<AudioManager>().Play("walkViolet");
        }
        anim.SetBool("Moving", moving);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CrossEnabledRange"))
        {
            shadowSpeed = 8;
        }
    }
}
