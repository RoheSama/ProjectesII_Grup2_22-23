using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    public GameObject target;

    public GameObject mark;

    public bool isTargeted = false;

    [SerializeField] private TargetController targetController;
   
   
    void Start()
    {

    }
    void Update()
    {
       if(targetController.a)
        {
            if(targetController.target1 != null)
            {
                targetController.target1 = target;
            }
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             mark.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            isTargeted = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            mark.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            isTargeted = false;
        }
    }
}

