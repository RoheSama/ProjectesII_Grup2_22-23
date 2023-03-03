using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

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
        StartCoroutine(Shaking());
        //camera.GetComponent<CameraController>().start = true;
        //anim.SetTrigger("Hurt");

    }

    IEnumerator Shaking()
    {
        ScreenShake.Instance.ShakeCamera(1f, 0.1f);
        yield return new WaitForSeconds(0.4f);
        ScreenShake.Instance.ShakeCamera(0f, 0.1f);
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
            //Destroy(gameObject);
            alive = false;
            StartCoroutine(Wait());
           //Instantiate(bloodDie, transform.position, Quaternion.identity);
            this.enabled = false;
        }
    }

    IEnumerator Wait()
    {

        anim.SetTrigger("Die");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
