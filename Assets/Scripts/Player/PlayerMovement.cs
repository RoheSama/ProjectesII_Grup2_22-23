using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClearSky
{
    public class PlayerMovement : MonoBehaviour
    {
        public float movePower = 10f;

        private Rigidbody2D rb;
        private Animator anim;
        private int direction = 1;
        private bool alive = true;

        Vector2 moveVelocity;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            Run();
        }
        void Run()
        {
            //Calculate the movement direction
            moveVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            //Run animation
            anim.SetBool("isRun", moveVelocity.sqrMagnitude > 0.0001f);

            //Direction flip
            if (moveVelocity.x > 0.0001f)
                direction = 1;
            else if (moveVelocity.x < -0.0001f)
                direction = -1;

            transform.localScale = new Vector3(direction, 1, 1);

            rb.AddForce(moveVelocity * movePower * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }
}