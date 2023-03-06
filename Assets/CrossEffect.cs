using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossEffect : MonoBehaviour
{
    public TopDownMovement topDownMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CrossEnabledRange"))
        {
            Debug.Log("AFECTADO POR LA CRUZ");
            topDownMovement.shadowSpeed = 1;

        }
    }
}
