using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    // Scenes Gameobjects
    public GameObject game;
    public GameObject deathCanvas;

    // Time
    public float gameTime;
    public int gameTimeInt;
    public int minutes;
    public int seconds;

    // Text
    public Text timeText1;
    public Text timeText2;
    public Text voidsKilledText;
    public Text alertLevelText;

    public VoidsLeft voidsLeft;
    public int totalVoidsKilled;

    public int alertLevel;
    public Animator star1Animator;
    public Animator star2Animator;

    private float goToMenuTimer;

    void Start()
    {
        alertLevel= 0;
       // deathCanvas.SetActive(false); 
    }

    void Update()
    {
        totalVoidsKilled = voidsLeft.voidsKilled;

        if (!deathCanvas.activeSelf)
        {
            gameTime += Time.deltaTime;
        }

        if(star1Animator.GetBool("CanStartSatanicStar01"))
        {
            alertLevel= 1;
        }
        if(star2Animator.GetBool("CanStartSatanicStar02"))
        {
            alertLevel = 2;
        }

        if (deathCanvas.activeSelf)
        {
            game.SetActive(false);
            deathCanvas.SetActive(true);

            gameTimeInt = Convert.ToInt32(gameTime);

            minutes = gameTimeInt / 60;
            gameTimeInt -= 60 * minutes;
            seconds = gameTimeInt;
            DeathScene();

            goToMenuTimer += Time.deltaTime;

            if(goToMenuTimer>=5)
            {
                SceneManager.LoadScene("TopDownMap");
            }
        }
    }

    void DeathScene()
    {

        timeText1.text = minutes.ToString();

        timeText2.text = seconds.ToString();

        voidsKilledText.text = totalVoidsKilled.ToString();

        alertLevelText.text = alertLevel.ToString();
    }
}
