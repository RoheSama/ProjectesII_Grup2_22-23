using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndingSceneScript : MonoBehaviour
{
    public float timer;
    bool activeTimer = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
        if (activeTimer)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 33)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
