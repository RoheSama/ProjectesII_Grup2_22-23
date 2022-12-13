using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    //public float distance;
    //public LayerMask solid;
    //public GameObject destroyEffect;
    public int damage;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            //DamageEnemy
            //Destroy(collision.gameObject);
            DestroyProjectile();
            collision.GetComponent<EnemyHit>().TakeDamage(damage);
        }
       
    }
    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

     
}

