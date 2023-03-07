using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    // Scenes Gameobjects
    public GameObject game;
    public GameObject deathScene;

    // Time
    public float gameTime;
    public int gameTimeInt;
    public int minutes;
    public int seconds;

    public bool activateDeathScene;

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

    void Start()
    {
        alertLevel= 0;
    }

    void Update()
    {
        totalVoidsKilled = voidsLeft.voidsKilled;

        if (activateDeathScene==false)
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

        if (activateDeathScene)
        {
            game.SetActive(false);
            deathScene.SetActive(true);

            gameTimeInt = Convert.ToInt32(gameTime);

            minutes = gameTimeInt / 60;
            gameTimeInt -= 60 * minutes;
            seconds = gameTimeInt;

            if(minutes <10)
            {
                MoveText();
            }
            DeathScene();
        }
    }

    void DeathScene()
    {

        timeText1.text = minutes.ToString();

        timeText2.text = seconds.ToString();

        voidsKilledText.text = totalVoidsKilled.ToString();

        alertLevelText.text = alertLevel.ToString();
    }

    void MoveText()
    {
        //Adjustar la posicio del text
    }
}
