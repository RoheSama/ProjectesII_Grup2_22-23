using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class stunArea : MonoBehaviour
{
    public GameObject cura;

    public GameObject shadow;
    public GameObject violet;

    private bool stuned;

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
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyHitNew>().isCura)
        {
            Debug.Log("Stunedd");
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
    }
}
