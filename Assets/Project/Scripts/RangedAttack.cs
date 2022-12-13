using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    public float offset;

    public GameObject projectile;
    public Transform shotPoint;
    // Update is called once per frame
    private float cdShot;
    public float startCdShot;
    void Update()
    {

        Shot();
    }
    
    void Shot()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.position;
        //difference.z = 1;
        Quaternion rotation = Quaternion.LookRotation(difference, Vector3.back);

        if(cdShot <= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log(difference);

                var obj = Instantiate(projectile, shotPoint.position, rotation, null);
                cdShot = startCdShot;
            }
        }
        else
        {
            cdShot -= Time.deltaTime;
        }
        
    }
}
