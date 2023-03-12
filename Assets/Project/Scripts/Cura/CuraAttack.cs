using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuraAttack : MonoBehaviour
{
    public Animator anim;
    public LayerMask playerLayer;
    public NavMeshAgent navMeshAgent;
    
    public Transform attackPoint;

    private bool attackAreaEnabled = false;
    [SerializeField] private GameObject attackArea;
    [SerializeField] LayerMask AoE;
    [SerializeField] private GameObject player;

    private float curaDamage = 0.2f;

    public bool curaCanAttack;
    public CuraBehaviour curaBehaviour;

    //Audio
    public AudioSourceCura audioSourceCura;

    void Start()
    {
        curaCanAttack = false;
    }

    void Update()
    {
        if(curaBehaviour.level1 || curaBehaviour.canChase)
        {
            curaCanAttack = true;
        }
    }

    public void AreaEnabled()
    {
        attackAreaEnabled = true;
    }
    void AreaDamage()
    {
        //audioSourceCura.AttackCuraOn();
        FindObjectOfType<AudioManager>().Play("attackPriest");
        Debug.Log("DAMAGE PJ");
        Vector2 origin = new Vector2(0f, 0f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, 1f, playerLayer);
        player.GetComponent<PlayerHealth>().TakeDamage(curaDamage);
        //foreach (Collider2D player in colliders)
        //{
        //    if (player.GetComponent<PlayerHealth>())
        //    {
        //        Debug.Log("DAMAGED PJ");
        //        player.GetComponent<PlayerHealth>().TakeDamage(curaDamage);
        //    }
        //}
    }
    IEnumerator AttackAreaRoutine()
    {
        attackArea.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        AreaDamage();
        anim.SetBool("CanCry", true);
        anim.SetBool("MoveUp", false);
        anim.SetBool("MoveDown", false);
        anim.SetBool("MoveLeft", false);
        anim.SetBool("MoveRight", false);
        anim.SetBool("IdleUp", false);
        anim.SetBool("IdleDown", false);
        anim.SetBool("IdleLeft", false);
        anim.SetBool("IdleRight", false);
        navMeshAgent.speed = 0;


        yield return new WaitForSeconds(1.0f);
        attackArea.SetActive(false);
        attackAreaEnabled = false;
        anim.SetBool("CanCry", false);
        navMeshAgent.speed = 2;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (curaCanAttack)
            {
                StartCoroutine(AttackAreaRoutine());
                StartCoroutine(CoolDownAttack());
            }
           
        }
    }

    IEnumerator CoolDownAttack()
    {
        yield return new WaitForSeconds(1.0f);

    }


}
