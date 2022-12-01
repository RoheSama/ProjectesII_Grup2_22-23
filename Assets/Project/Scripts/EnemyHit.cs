using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public Animator anim;

    private bool enemyDied = false;

    public Slider rageBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        anim.SetBool("Dead", true);


        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        enemyDied = true;
    }

    void UpdateRageBar()
    {
        if (enemyDied)
        {
            rageBar.value = +10;
            enemyDied = false;
        }
    }
}
