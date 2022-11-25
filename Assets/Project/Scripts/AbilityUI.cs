using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    // Ability1
    public Image abilityImage1;
    public float cooldown1;
    bool isCooldown = false;
    public KeyCode ability1;
    public TargetController targetController;

    //Abilty2
    public Image abilityImage2;
    public float cooldown2;
    bool isCooldown2 = false;
    public KeyCode ability2;

    //Rohe
    public Animator anim;
    public LayerMask enemyLayers;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    int attackDamage = 5;

    private float powerUpSpeed = 1.5f;

    private bool powerUpAvailable = true;
    public bool powerUpActivated = false;

    NavMeshAgent agent;
    void Start()
    {
        abilityImage1.fillAmount = 1;
        abilityImage2.fillAmount = 1;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (powerUpActivated)
        {
            Ability1();
        }

        //if (powerUpAvailable)
       // {

            Ability2();
        //}

    }

    void Ability1()
    {
        if(Input.GetKeyUp(ability1)&& isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;

            //Efecto de la habilidad
            //Debug.Log("Ataque ejecutado");
            //targetController.targetedElement.SetActive(false);
            //Animation
            anim.SetTrigger("Attack");

            //Detect enemies
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("HIT");
                enemy.GetComponent<EnemyHit>().TakeDamage(attackDamage);
            }
        }
        if(isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
    void Ability2()
    {
        if (Input.GetKeyUp(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;

            //Efecto de la habilidad
            PowerUp();
            
        }
        if (isCooldown2)
        {
            PowerOff();
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }
    void PowerUp()
    {
        //if (Input.GetKeyDown(KeyCode.E))
       // {
            powerUpActivated = true;
            powerUpAvailable = false;
          //StartCoroutine(PowerUpCooldown());
            GetComponent<SpriteRenderer>().color = Color.yellow;
            agent.speed = agent.speed + powerUpSpeed;
            StartCoroutine(NormalForm());
       // }
    }

    void PowerOff()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        agent.speed = agent.speed - powerUpSpeed;
        powerUpActivated = false;
    }

    IEnumerator NormalForm()
    {
        yield return new WaitForSeconds(5);
        PowerOff();

    }

    IEnumerator PowerUpCooldown()
    {
        yield return new WaitForSeconds(10);
        powerUpAvailable = true;

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
