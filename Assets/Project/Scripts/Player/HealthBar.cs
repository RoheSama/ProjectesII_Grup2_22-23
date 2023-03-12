using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
    public GameObject player;
    public UnityEngine.UI.Image healthBar;
    private float maxHealth = 1.0f;

    void Start()
    {
        healthBar = GetComponent<UnityEngine.UI.Image>();  
    }

    void Update()
    {
        healthBar.fillAmount = player.GetComponent<PlayerHealth>().health / maxHealth;  
    }
}
