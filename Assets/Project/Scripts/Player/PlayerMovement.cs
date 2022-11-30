using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

namespace ClearSky
{
    public class PlayerMovement : MonoBehaviour
    {
        public float movePower = 10f;

        private Rigidbody2D rb;
        public Animator anim;
        private int direction = 1;
        public bool alive = true;

        public ShowPhone showPhone;

        public float health = 0f;
        [SerializeField]
        private float maxHealth = 100f;

        Vector2 moveVelocity;

        int number = 0;
        bool couroutineStarted = false;

        // Start is called before the first frame update
        void Start()
        {
            health = maxHealth;
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            if (alive)
            {
                Run();
                Die();
            }
            
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

            if (showPhone.phoneIsActive == true)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                anim.SetBool("isRun", false);
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }

       
        public void Hurt()
        {
            anim.SetTrigger("hurt");
            if (direction == 1)
                rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            
        }

        public void UpdateHealth(float mod)
        {
            health += mod;
            
            if(health > maxHealth)
            {
                health = maxHealth;
            }else if(health <= 0f)
            {
                health = 0f;
            }
            
        }

        void Die()
        {   
          if(health <= 0)
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
}