using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class stunArea : MonoBehaviour
{
    public GameObject cura;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyHitNew>().isCura)
        {
            Debug.Log("Stunedd");
            cura.GetComponent<NavMeshAgent>().enabled = false;
            StartCoroutine(DesStun());
        }
    }

    IEnumerator DesStun()
    {
        yield return new WaitForSeconds(2.0f);

        cura.GetComponent<NavMeshAgent>().enabled = true;
    }
}
