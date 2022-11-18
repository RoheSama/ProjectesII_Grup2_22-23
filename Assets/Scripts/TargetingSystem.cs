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
        TargetsOutOfRange();
        TargetsInRange();
        TargetedLogic();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mark.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
            isInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            mark.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.3f);
            isInRange = false;
        }
    }

    void TargetsInRange()
    {
        if (targetController.targetsInRange[0] == null && isInRange)
        {
            targetController.targetsInRange[0] = target;
        }
        else if (targetController.targetsInRange[0] != null && targetController.targetsInRange[1] == null && isInRange && target != targetController.targetsInRange[0] && target != targetController.targetsInRange[2])
        {
            targetController.targetsInRange[1] = target;
        }
        else if (targetController.targetsInRange[0] != null && targetController.targetsInRange[1] != null && targetController.targetsInRange[2] == null && isInRange && target != targetController.targetsInRange[0] && target != targetController.targetsInRange[1])
        {
            targetController.targetsInRange[2] = target;
        }
    }

    void TargetedLogic()
    {
        if (targetController.targetedElement == target)
        {
            mark.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else if (targetController.targetedElement != target && isInRange)
        {
            mark.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
        }
    }

    void TargetsOutOfRange()
    {
        if (target == targetController.targetsInRange[0] && isInRange == false)
        {
            targetController.targetsInRange[0] = null;
        }
        else if (target == targetController.targetsInRange[1] && isInRange == false)
        {
            targetController.targetsInRange[1] = null;
        }
        else if (target == targetController.targetsInRange[2] && isInRange == false)
        {
            targetController.targetsInRange[2] = null;
        }
    }
}
