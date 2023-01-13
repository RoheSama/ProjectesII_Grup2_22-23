using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;
    [SerializeField]
    private float maxHealth = 1f;
    public bool alive = true;
    public Animator anim;

    public GameObject camera;
    public GameObject blood;
    public GameObject bloodDie;

    // Start is called before the first frame update
    void Start()
    {
        //health 
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void TakeDamage(float damage)
    {
       
        //Instantiate(blood, transform.position, Quaternion.identity);
        health -= damage;
        //camera.GetComponent<CameraController>().start = true;
        //anim.SetTrigger("Hurt");

    }
    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
        }

    }

    void Die()
    {
        if (health <= 0)
        {
            Debug.Log("LOSE");
            health = 0;
            //anim.SetTrigger("die");
            //Destroy(gameObject);
            alive = false;
            StartCoroutine(Wait());
           //Instantiate(bloodDie, transform.position, Quaternion.identity);
            this.enabled = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");

    }
}
