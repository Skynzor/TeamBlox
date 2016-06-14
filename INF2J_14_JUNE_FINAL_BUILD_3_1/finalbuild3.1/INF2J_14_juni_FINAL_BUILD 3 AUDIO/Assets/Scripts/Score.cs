using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int levelTime;
    public static int startTime;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        startLevel(4550);
    }

    //Update de score en tijd
    void FixedUpdate()
    {
        //Refresh score en tijd
        text.text = "Score: " + score + "   Bonus: " + getTimeLeft();

    }

    //Zet de startwaarden voor het begin van een nieuwe level
    static public void startLevel(int duration)
    {
        startTime = (int)Time.time;
        levelTime = duration;
    }

    //Verhoogt de huidige score met opgegeven waarde
    static public void incScore(int value)
    {
        score += value;
    }

    //Returnt het aantal secondes dat over is in de huidige level
    static public int getTimeLeft()
    {
        int timeLeft = (int)(levelTime - (Time.time - startTime));
        if(timeLeft < 1)
        {
            return 0;
        }
        return timeLeft;
    }

    //Verhoogt de huidige score met het overgebleven secondes aan het einde van de level | 1 punt per seconde.
    static public int setTimeScore()
    {
        return score += getTimeLeft();
    }

    //Voegt nieuwe score toe aan highscores
    static public void addScore(String name)
    {
        PlayerPrefs.SetInt("highScore5", score);
        PlayerPrefs.SetString("highScoreName5", name);
        PlayerPrefs.Save();
        refreshHighscores();
    }

    //Herberekend de highscorelijst. Dit is nodig omdat een nieuw toegevoegde score altijd op positie 5 staat.
    static public void refreshHighscores()
    {
        //Huidige highscores opslaan in nieuwe lijst
        var highScores = new List<KeyValuePair<string, int>>();
        for (int i = 0; i < 6; i++)
        {
            highScores.Add(new KeyValuePair<string, int>(PlayerPrefs.GetString("highScoreName" + i), PlayerPrefs.GetInt("highScore" + i)));
        }

        //Sorteer lijst op score
        highScores = highScores.OrderByDescending(x => x.Value).ToList();

        //Sla nieuwe geordende lijst op
        for (int i = 0; i < 5; i++)
        {
            KeyValuePair<string, int> temp = highScores[i];
            PlayerPrefs.SetString("highScoreName" + i, temp.Key);
            PlayerPrefs.SetInt("highScore" + i, temp.Value);
        }
        PlayerPrefs.Save();
    }
}