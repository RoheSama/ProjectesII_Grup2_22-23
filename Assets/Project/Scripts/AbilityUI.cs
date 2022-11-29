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

    public Slider shadowCooldown;
    void Start()
    {
        abilityImage1.fillAmount = 1;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
            Ability1();
 

        if (powerUpAvailable)
        {
            PowerUp();
        }

    }

    void Ability1()
    {
        if (powerUpActivated)
        {
            if (Input.GetKeyUp(ability1) && isCooldown == false)
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
        }
            if (isCooldown)
            {
                abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

                if (abilityImage1.fillAmount <= 0)
                {
                    abilityImage1.fillAmount = 0;
                    isCooldown = false;
                }
            }
        
    }

    void PowerUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            powerUpActivated = true;
            powerUpAvailable = false;
            StartCoroutine(PowerUpCooldown());
            GetComponent<SpriteRenderer>().color = Color.yellow;
            agent.speed = agent.speed + powerUpSpeed;
            StartCoroutine(NormalForm());
        }
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
