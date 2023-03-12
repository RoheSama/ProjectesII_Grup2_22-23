using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHitNew : MonoBehaviour
{
    public IABehaviour iABehaviour;
    public int maxHealth = 10;
    public int currentHealth;

    public Animator anim;

    public bool isCura;
    public bool isTuto;

    //[SerializeField]
    //private RageBar rageBar;

    public GameObject blood;
    public GameObject bloodDie;

    public NavMeshAgent agent;
    public bool died;
    public GameObject voidsLeft;


    public RenderPipelineAsset normalAsset;
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
            if (voidsLeft.GetComponent<VoidsLeft>().totalVoids == 0)
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

    public void Stun()
    {
        if (isCura)
        {

            Debug.Log("STUNED");
        }
    }
    void Die()
    {
        //Debug.Log("Enemy died");
        FindObjectOfType<AudioManager>().Play("CuraDeathSound");
        anim.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        agent.speed = 0.0f;
        StartCoroutine(VoidDestroy());
        if (!isCura)
        {
            FindObjectOfType<AudioManager>().Play("DeathVoid");
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

        died = true;
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
        if (isCura && !isTuto)
        {
            GraphicsSettings.renderPipelineAsset = normalAsset;
            SceneManager.LoadScene("EndingCinematic");
        }
    }

}
