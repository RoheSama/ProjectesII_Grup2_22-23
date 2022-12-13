using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEditor.PackageManager;
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
        GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            //DamageEnemy
            DestroyProjectile();
        }
       
    }
    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

     
}

