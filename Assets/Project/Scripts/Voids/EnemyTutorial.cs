using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTutorial : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public Animator anim;

    public bool isCura;

    public GameObject blood;
    public GameObject bloodDie;

    public NavMeshAgent agent;
    public bool died;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {

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
        this.enabled = false;
        died = true;
    }
}
