using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class stunArea : MonoBehaviour
{
    public GameObject cura;

    public GameObject shadow;
    public GameObject violet;

    public bool stuned;

    public Animator anim;

    private void Update()
    {
        if (FindObjectOfType<AbilityUI>().powerUpActivated == false)
        {
            this.transform.position = violet.transform.position;
        }
        else
        {
            this.transform.position = shadow.transform.position;
        }

        if(stuned)
        {
            StartCoroutine(DesStun());
            anim.SetBool("IsStunned", true);
            anim.SetBool("CanCry", false);
            anim.SetBool("MoveUp", false);
            anim.SetBool("MoveDown", false);
            anim.SetBool("MoveLeft", false);
            anim.SetBool("MoveRight", false);
            anim.SetBool("IdleUp", false);
            anim.SetBool("IdleDown", false);
            anim.SetBool("IdleLeft", false);
            anim.SetBool("IdleRight", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyHitNew>().isCura)
        {
            FindObjectOfType<AudioManager>().Play("Laugh");
            cura.GetComponent<NavMeshAgent>().enabled = false;
            stuned= true;
            StartCoroutine(DesStun());
        }
    }

    IEnumerator DesStun()
    {
        yield return new WaitForSeconds(2.0f);

        cura.GetComponent<NavMeshAgent>().enabled = true;
        stuned= false;
        anim.SetBool("IsStunned", false);
       
    }
}
