using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;
    public float maxHealth = 1f;
    public bool alive = true;
    public Animator anim;
    public Animator animShadow;

    public GameObject blood;
    public GameObject bloodDie;

    public SpriteRenderer character;
    public SpriteRenderer characterShadow;

    public RenderPipelineAsset normalAsset;
    public TimeCounter timeCounter;

    // Start is called before the first frame update
    void Start()
    {
        //health 
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health>= maxHealth)
        {
            health = maxHealth;
        }

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

    IEnumerator DieAnimation()
    {
        if (FindObjectOfType<AbilityUI>().powerUpActivated == false)
        {
            anim.SetTrigger("Die");
            yield return new WaitForSeconds(0.75f);
            character.enabled = false;
        }
        else
        {
            animShadow.SetTrigger("Die");
            yield return new WaitForSeconds(0.75f);
            characterShadow.enabled = false;
            GraphicsSettings.renderPipelineAsset = normalAsset;
        }
    }

    IEnumerator Wait()
    {
        StartCoroutine(DieAnimation());
        yield return new WaitForSeconds(2);
        timeCounter.activateDeathScene = true;
       // SceneManager.LoadScene("MainMenu");
    }
}
