using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuraHit : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public GameObject cura;

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
        if (rageBar.raged)
        {
            currentHealth -= damage;

            anim.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                Die();
            }
        }
       
    }

    void Die()
    {
        Debug.Log("Enemy died");

        anim.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(cura);
     
    }

}
