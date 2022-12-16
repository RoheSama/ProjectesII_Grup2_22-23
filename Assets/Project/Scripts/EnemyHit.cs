using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public Animator anim;

    public bool updateRageBar = false;

    [SerializeField]
    private RageBar rageBar;

    //public Slider rageBar;
    //public float maxRage = 100;
    //public float currentRage = 20;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rageBar = FindObjectOfType<RageBar>();
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
        rageBar.UpdateRageBar();
        //UpdateRageBar();
        //enemyDied = true;
    }

}
