using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    public GameObject target;

    public GameObject mark;

    public bool isInRange = false;


    [SerializeField] private TargetController targetController;
   
    void Start()
    {

    }
    void Update()
    {
       if(targetController.target1 == null && isInRange)
       {
            targetController.target1 = target;
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(targetController.targetedElement == target)
        {
            mark.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else if (other.CompareTag("Player"))
        {
            mark.GetComponent<SpriteRenderer>().color = new Color(0f, 0f,0f, 1f);
            isInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            mark.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
            isInRange = false;
        }
    }
}

