using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHitNew : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public Animator anim;

    public bool isCura;

    //[SerializeField]
    //private RageBar rageBar;

    public GameObject blood;
    public GameObject bloodDie;

    public NavMeshAgent agent;
    //public Slider rageBar;
    //public float maxRage = 100;
    //public float currentRage = 20;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //rageBar = FindObjectOfType<RageBar>();
    }

    public void TakeDamage(int damage)
    {
        //if (isCura)
        //{
        //    if (rageBar.raged)
        //    {
        //        Instantiate(blood, transform.position, Quaternion.identity);
        //        currentHealth -= damage;
        //        Debug.Log("Damaged");

        //        anim.SetTrigger("Hurt");
        //        if (currentHealth <= 0)
        //        {
        //            Die();
        //            Instantiate(bloodDie, transform.position, Quaternion.identity);
        //        }
        //    }
        //}
        //else
        //{
            Instantiate(blood, transform.position, Quaternion.identity);
            currentHealth -= damage;

            //anim.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                Die();
                Instantiate(bloodDie, transform.position, Quaternion.identity);
            }
        //}


    }

    void Die()
    {
        //Debug.Log("Enemy died");
        FindObjectOfType<AudioManager>().Play("DeathVoid");
        anim.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        agent.speed = 0.0f;
        StartCoroutine(VoidDestroy());
        //Destroy(gameObject);
        //rageBar.UpdateRageBar();
        //UpdateRageBar();
        //enemyDied = true;
    }

    IEnumerator VoidDestroy()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

}
