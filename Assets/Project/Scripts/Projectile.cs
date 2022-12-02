using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask solid;
    //public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, solid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Target"))
            {
                Debug.Log("ENEMY DAMAGED");
            }
            DestroyProjectile();
        }


        transform.Translate(transform.up * speed * Time.deltaTime); 
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

     
}

