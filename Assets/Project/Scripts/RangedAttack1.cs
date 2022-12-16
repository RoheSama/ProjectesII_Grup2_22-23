using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack1 : MonoBehaviour
{
    public Transform shotPosition;
    public GameObject projectile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(projectile, shotPosition.position, shotPosition.rotation);
        }
    }
}
