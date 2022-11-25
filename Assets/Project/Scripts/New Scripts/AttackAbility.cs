using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackAbility : Ability
{
    public override void Activate(GameObject parent) 
    {
        Debug.Log("Ability Used");
    }

    public override void BeginCooldown(GameObject parent)
    {
        //Debug.Log("Ability In Cooldown");
    }
}
