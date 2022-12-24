using ClearSky;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CuraTracking : MonoBehaviour
{
    public Transform Player;
    NavMeshAgent agent;
    [SerializeField]
    private AbilityUI player;

    [SerializeField]
    private float attackDamage = 0.2f;
    [SerializeField]
    private float attackSpeed = 1f;
    [SerializeField]
    private float canAttack;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.powerUpActivated)
        {
            agent.SetDestination(Player.position);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PointAndClick>().alive)
            {
                if (attackSpeed <= canAttack)
                {
                    collision.gameObject.GetComponent<PointAndClick>().Hurt();
                    collision.gameObject.GetComponent<PointAndClick>().UpdateHealth(-attackDamage);
                    Debug.Log("HIT");
                    canAttack = 0f;
                }
                else
                {
                    canAttack += Time.deltaTime;
                }
            }
        }
    }
}
