﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class HighscoreMenu : MonoBehaviour
{
    /******************************HIGHSCORE*******************************/
    public List<Text> Texts;

    /******************************SOUND***********************************/
    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    // Use this for initialization
    void Start()
    {
        /******************************HIGHSCORE*******************************/
        Text[] highScores = new Text[5];
        Text[] highScoresName = new Text[5];

        //set de lijst met highscores
        for (int i = 0; i < 5; i++)
        {

            //koppel variabele met gameobject in scene
            highScores[i] = GameObject.Find("highScore" + i).GetComponent<Text>();
            highScoresName[i] = GameObject.Find("highScoreName" + i).GetComponent<Text>();

            //Vult de strings in de scene met naam en scores.
            highScores[i].text = PlayerPrefs.GetInt("highScore" + i, 0).ToString();
            highScoresName[i].text = (i + 1).ToString() + ". " + PlayerPrefs.GetString("highScoreName" + i, "");
        }
    }

    /**********************************************************************/
    /******************************UNITY ALGEMEEN**************************/
    /**********************************************************************/
    // Update is called once per frame
    void Update()
    {

    }

    /**********************************************************************/
    /******************************TERUGKNOP*******************************/
    /**********************************************************************/
    // Terug naar hoofdmenu
    public void Back()
    {
        //
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);

        //terug naar hoofdmenu scene
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }
}