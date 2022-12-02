using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    // Ability1
    public Image abilityImage1;
    public Image abilityImageSM;
    public float cooldown1;
    public float cooldownPowerUp;
    public float currentCD;
    bool isCooldown = false;
    public KeyCode ability1;
    public KeyCode powerUpKey;
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

    public float powerUpDuration;

    NavMeshAgent agent;

    public Slider shadowCooldown;

    public Slider rageBar;
    public float maxRage = 100;
    public float currentRage = 20;

    public float offset;

    public GameObject projectile;
    public Transform shotPoint;
    void Start()
    {
        abilityImage1.fillAmount = 1;
        abilityImageSM.fillAmount = 1;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        Ability1();
        PowerUp();
        //UpdateRageBar();
        RangedAttack(); 
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
        if (Input.GetKeyDown(powerUpKey) && powerUpAvailable == true)
        {
            powerUpAvailable = false;
            powerUpActivated = true;
            currentCD = 0;
            abilityImageSM.fillAmount = 1;
            //StartCoroutine(PowerUpCooldown());
            GetComponent<SpriteRenderer>().color = Color.yellow;
            agent.speed = agent.speed + powerUpSpeed;
            StartCoroutine(NormalForm());
           

        }

        if (!powerUpAvailable)
        {
            abilityImageSM.fillAmount -= 1 / cooldownPowerUp * Time.deltaTime;
            currentCD = Mathf.Clamp(currentCD, 0.0f, cooldownPowerUp);

            if (abilityImageSM.fillAmount <= 0)
            {
                abilityImageSM.fillAmount = 0;
                powerUpAvailable = true;
            }
            else
            {
                currentCD += Time.deltaTime;
                currentCD = Mathf.Clamp(currentCD, 0.0f, powerUpDuration);
            }
        }

        shadowCooldown.value = currentCD / powerUpDuration;
        
    }

    void PowerOff()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        agent.speed = agent.speed - powerUpSpeed;
        powerUpActivated = false;
    }

    IEnumerator NormalForm()
    {
        yield return new WaitForSeconds(powerUpDuration);
        PowerOff();
    }

    void RangedAttack()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(projectile, shotPoint.position, transform.rotation);
        }
    }

    //IEnumerator PowerUpCooldown()
    //{
    //    yield return new WaitForSeconds(10);
    //    powerUpAvailable = true;

    //}
    //void UpdateRageBar()
    //{
    //    if (GetComponent<EnemyHit>().enemyDied)
    //    {
    //        rageBar.value = currentRage / maxRage;
    //        GetComponent<EnemyHit>().enemyDied = false;
    //    }
    //}
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
