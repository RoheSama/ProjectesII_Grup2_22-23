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


    public GameObject blood;
    public GameObject bloodDie;

    public NavMeshAgent agent;
    public bool died;
    public GameObject voidsLeft;


    public RenderPipelineAsset normalAsset;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isCura)
        {
            if (voidsLeft.GetComponent<VoidsLeft>().totalVoids == 0)
            {
                Instantiate(blood, transform.position, Quaternion.identity);
                currentHealth -= damage;

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
            anim.SetTrigger("Cura_stun");
        }
    }
    void Die()
    {
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
        else if (isCura)
        {
            FindObjectOfType<AudioManager>().Play("CuraDeathSound");
        }
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
