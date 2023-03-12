using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Threading;

public class AbilityUI : MonoBehaviour
{
    // Abilities images
    public Image abilityImage1;
    public Image abilityImageSM;    public Image abilityImageStun;
    //public Image abilityImageRA;

    public float cooldown1;
    public float cooldownPowerUp;
    public float cooldownStun;
    public float currentCD;

    bool isCooldown1 = false;
    bool isCooldownRA = false;
    bool isCooldownStun = false;

    //KeyCodes
    public KeyCode ability1;
    public KeyCode powerUpKey;
    public KeyCode stunKey;

    //Rohe
    public Animator anim;
    public Animator shadowAnim;
    public LayerMask enemyLayers;
    public LayerMask curaLayers;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    int attackDamage = 10;

    private float powerUpSpeed = 1.5f;

    private bool powerUpAvailable = true;
    public bool powerUpActivated = false;

    public float powerUpDuration;

    NavMeshAgent agent;

    public Image shadowCooldown;

    public GameObject shadowModeEffect;

    public GameObject normalForm;
    public GameObject shadowForm;

    public Image normalFace;
    public Image shadowFace;

    public PlayerHealth playerHealth;

    //Attack Area
    private bool attackAreaEnabled = false;
    [SerializeField] private GameObject attackArea;
    [SerializeField] LayerMask AoE;

    //Rendering
    public RenderPipelineAsset powerUpAsset;
    public RenderPipelineAsset normalAsset;
    //Arnau
    //public GameObject shadowIcon;

    //Stun
    private GameObject stunArea = default;

    private bool stuning = false;

    private float timeToStun = 2.5f;
    private float stunTimer = 0f;

    public bool isTuto;

    void Start()
    {
        abilityImage1.fillAmount = 1;
        abilityImageSM.fillAmount = 1;        abilityImageStun.fillAmount = 1;
        normalForm.SetActive(true);
        shadowForm.SetActive(false);

        stunArea = transform.GetChild(4).gameObject;
    }

    void Update()
    {
        Ability1();
        PowerUp();

        Stun();

        if (stuning)
        {
            stunTimer += Time.deltaTime;
            if (stunTimer >= timeToStun)
            {
                stunTimer = 0;
                stuning = false;
                stunArea.SetActive(stuning);
            }
        }
        //RangedAttack();
        //UpdateRageBar();
    }

    void Ability1()
    {
        if (powerUpActivated)
        {
            if (Input.GetKeyUp(ability1) && isCooldown1 == false)
            {

                FindObjectOfType<AudioManager>().Play("attackShadow");
                isCooldown1 = true;
                abilityImage1.fillAmount = 1;
                AreaEnabled(); 
                //Animation
                
                shadowAnim.SetTrigger("Attacking");
                StartCoroutine(AttackAreaRoutine());

            }
        }

        if (isCooldown1)

        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (abilityImage1.fillAmount <= 0)
            {

                abilityImage1.fillAmount = 1;

                isCooldown1 = false;

            }

        }
    }    public void AreaEnabled()
    {
        attackAreaEnabled = true;
    }    void AreaDamage()
    {
        Debug.Log("DAMAGE");
        Vector2 origin = new Vector2(0f, 0f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position,3f, AoE);
        foreach(Collider2D enemy in colliders)
        {
            if (enemy.GetComponent<EnemyHitNew>())
            {
                Debug.Log("DAMAGED");
                enemy.GetComponent<EnemyHitNew>().TakeDamage(attackDamage);
            }
        }
    }    IEnumerator AttackAreaRoutine()
    {
        attackArea.SetActive(true);
        ScreenShake.Instance.ShakeCamera(1f, 0.1f);
        yield return new WaitForSeconds(0.4f);
        AreaDamage();
        yield return new WaitForSeconds(0.4f);
        attackArea.SetActive(false);
        ScreenShake.Instance.ShakeCamera(0f, 0.1f);
        attackAreaEnabled = false;
    }
    void Stun()
    {
        if (Input.GetKeyDown(stunKey) == true && isCooldownStun == false)
        {
            FindObjectOfType<AudioManager>().Play("Stun");
            isCooldownStun = true;

            abilityImageStun.fillAmount = 1;

            //Efecto de la habilidad
            stuning = true;
            stunArea.SetActive(stuning);
           
            playerHealth.health -= 0.1f;
            if(playerHealth.health <=0)
            {
                playerHealth.health = 0.1f;
            }

            //Animation
            if (powerUpActivated)
            {
                shadowAnim.SetTrigger("Stuning");
            }
            else
            {
                anim.SetTrigger("Stuning");
            }


        }

        if (isCooldownStun)

        {
            abilityImageStun.fillAmount -= 1 / cooldownStun * Time.deltaTime;

            if (abilityImageStun.fillAmount <= 0)
            {

                abilityImageStun.fillAmount = 1;

                isCooldownStun = false;

            }

        }

    }


    void PowerUp()
    {
        if (Input.GetKeyDown(powerUpKey) && powerUpAvailable == true)
        {            if (Input.GetKeyDown(powerUpKey))
            {
                PowerOff();
            }

                        //shadowModeEffect.SetActive(true);
            powerUpAvailable = false;
            powerUpActivated = true;
            currentCD = 0;
            abilityImageSM.fillAmount = 1;            StartCoroutine(ShadowForm());
            StartCoroutine(NormalForm());            //Arnau            //shadowIcon.SetActive(true);
        }

        if (!powerUpAvailable)
        {
            abilityImageSM.fillAmount -= 1 / cooldownPowerUp * Time.deltaTime;
            currentCD = Mathf.Clamp(currentCD, 0.0f, cooldownPowerUp);

            if (abilityImageSM.fillAmount <= 0)
            {
                abilityImageSM.fillAmount = 1;
                powerUpAvailable = true;

            }
            else
            {
                currentCD += Time.deltaTime;
                currentCD = Mathf.Clamp(currentCD, 0.0f, powerUpDuration);
            }
        }
        shadowCooldown.fillAmount = currentCD / powerUpDuration;
    }

    void PowerOn()
    {
        normalForm.SetActive(false);
        shadowForm.SetActive(true);
        normalFace.enabled = false;
        shadowFace.enabled = true;
        ScreenShake.Instance.ShakeCamera(0f, 0.0f);
        if (!isTuto)
        {
            GraphicsSettings.renderPipelineAsset = powerUpAsset;
        }
    }
    void PowerOff()
    {
         //GetComponent<SpriteRenderer>().color = Color.white;

        //agent.speed = agent.speed - powerUpSpeed;

        normalForm.SetActive(true);
        shadowForm.SetActive(false);

        powerUpActivated = false;
        shadowModeEffect.SetActive(false);

        normalFace.enabled = true;
        shadowFace.enabled = false;
        if (!isTuto)
        {
            GraphicsSettings.renderPipelineAsset = normalAsset;
        }
    }

    IEnumerator ShadowForm()
    {
        //audio
        FindObjectOfType<AudioManager>().Play("transformShadow");
        FindObjectOfType<AudioManager>().Play("screamShadow");
        anim.SetTrigger("Transform");
        ScreenShake.Instance.ShakeCamera(2f, 0.1f);
        yield return new WaitForSeconds(0.8f);
        PowerOn();
    }
    IEnumerator NormalForm()
    {
        yield return new WaitForSeconds(powerUpDuration);
        //audio
        FindObjectOfType<AudioManager>().Play("transformShadow");
        shadowAnim.SetTrigger("Detransformation");
        yield return new WaitForSeconds(0.8f);
        PowerOff();
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
