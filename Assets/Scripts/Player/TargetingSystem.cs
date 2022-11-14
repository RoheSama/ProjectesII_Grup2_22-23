using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    GameObject target1;
    GameObject mark1;

    SpriteRenderer spriteRenderer;

    void Start()
    {

    }
    void Update()
    {
        if(mark1 != null)
        {
            mark1.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mark"))
        {
            mark1 = other.gameObject;
        }
    }
}

