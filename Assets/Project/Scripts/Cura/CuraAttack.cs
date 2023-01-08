using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuraAttack : MonoBehaviour
{
    public Animator anim;
    public LayerMask playerLayer;

    public Transform attackPoint;

    private bool attackAreaEnabled = false;
    [SerializeField] private GameObject attackArea;
    [SerializeField] LayerMask AoE;
    [SerializeField] private GameObject player;

    private float curaDamage = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AreaEnabled()
    {
        attackAreaEnabled = true;
    }
    void AreaDamage()
    {
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
        yield return new WaitForSeconds(0.4f);
        attackArea.SetActive(false);
        attackAreaEnabled = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("CanCry");
            StartCoroutine(AttackAreaRoutine());
        }
    }
}
