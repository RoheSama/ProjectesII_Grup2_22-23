using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public Image abilityImage1;
    public float cooldown1;
    bool isCooldown = false;
    public KeyCode ability1;
    void Start()
    {
        abilityImage1.fillAmount = 1;
    }

    void Update()
    {
        Ability1();
    }

    void Ability1()
    {
        if(Input.GetKeyUp(ability1)&& isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
            Debug.Log("Ataque ejecutado");
        }
        if(isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

}
