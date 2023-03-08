using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHitNew : MonoBehaviour
{
    public IABehaviour iABehaviour;
    public int maxHealth = 10;
    public int currentHealth;

    public Animator anim;

    public bool isCura;

    //[SerializeField]
    //private RageBar rageBar;

    public GameObject blood;
    public GameObject bloodDie;

    public NavMeshAgent agent;
    public bool died;
    public GameObject voidsLeft;
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
        if (isCura)
        {
            if (voidsLeft.GetComponent<VoidsLeft>().totalVoids == 1)
            {
                Instantiate(blood, transform.position, Quaternion.identity);
                currentHealth -= damage;
                Debug.Log("Damaged");

               // anim.SetTrigger("Hurt");
                if (currentHealth <= 0)
                {
                    Die();
                    Instantiate(bloodDie, transform.position, Quaternion.identity);
                }
            }
        }
        else
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            currentHealth -= damage;

            //anim.SetTrigger("Hurt");

            if (currentHealth <= 0 && iABehaviour.canDie==true)
            {
                Die();
                Instantiate(bloodDie, transform.position, Quaternion.identity);
            }
        }
    }

    void Die()
    {
        //Debug.Log("Enemy died");
        died = true;
        FindObjectOfType<AudioManager>().Play("DeathVoid");
        anim.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        agent.speed = 0.0f;
        StartCoroutine(VoidDestroy());
        if (!isCura)
        {
            voidsLeft.GetComponent<VoidsLeft>().studentKill();
            iABehaviour.isDead = true;
        }
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
