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
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<UnityEngine.UI.Image>();  
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = player.GetComponent<PlayerHealth>().health / maxHealth;  
    }
}
