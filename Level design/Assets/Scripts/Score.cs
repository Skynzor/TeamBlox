using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Score : MonoBehaviour
{
    public static int score;
    public static int levelTime;
    public static int startTime;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    //Update de score en tijd
    void FixedUpdate()
    {
        //Refresh score en tijd
        text.text = "Score: " + score + "   Time: " + getTimeLeft();

        //Controleer als er nog tijd over is
        if (getTimeLeft() < 1)
        {
            //HE DED
        }
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
        return (int)(levelTime - (Time.time - startTime));
    }

    //Verhoogt de huidige score met het overgebleven secondes aan het einde van de level | 1 punt per seconde.
    static public int setTimeScore()
    {
        return score += getTimeLeft();
    }

    //Voegt nieuwe score toe aan highscores
    static public void addScore(String name)
    {
        PlayerPrefs.SetInt("highscore11", score);
        PlayerPrefs.SetString("highScoreName11", name);
        PlayerPrefs.Save();
        refreshHighscores();
    }

    //Herberekend de highscorelijst. Dit is nodig omdat een nieuw toegevoegde score altijd op positie 11 staat.
    static public void refreshHighscores()
    {
        //Huidige highscores opslaan in nieuwe lijst
        var highScores = new List<KeyValuePair<string, int>>();
        for (int i = 0; i < 11; i++)
        {
            highScores.Add(new KeyValuePair<string, int>(PlayerPrefs.GetString("highScoreName" + i), PlayerPrefs.GetInt("highScore" + i)));
        }
        
        //Sorteer lijst op score
        highScores = highScores.OrderByDescending(x => x.Value).ToList();

        //Sla nieuwe geordende lijst op
        for (int i = 0; i < 11; i++){
            KeyValuePair<string, int> temp = highScores[i];
            PlayerPrefs.SetString("highScoreName" + i, temp.Key);
            PlayerPrefs.SetInt("highScore" + i, temp.Value);
        }
        PlayerPrefs.Save();
    }

    static public void saveScore()
    {
        /*testmeuk
        PlayerPrefs.SetInt("highScore0", 1);
        PlayerPrefs.SetInt("highScore1", 2);
        PlayerPrefs.SetInt("highScore2", 3);
        PlayerPrefs.SetInt("highScore3", 8);
        PlayerPrefs.SetInt("highScore4", 5);

        PlayerPrefs.SetString("highScoreName0", "nr5");
        PlayerPrefs.SetString("highScoreName1", "nr4");
        PlayerPrefs.SetString("highScoreName2", "nr3");
        PlayerPrefs.SetString("highScoreName3", "nr2");
        PlayerPrefs.SetString("highScoreName4", "nr1");
        PlayerPrefs.Save();

        var list = new List<KeyValuePair<string, int>>();
        list.Add(new KeyValuePair<string, int>(PlayerPrefs.GetString("highScoreName0"), PlayerPrefs.GetInt("highScore0")));
        list.Add(new KeyValuePair<string, int>(PlayerPrefs.GetString("highScoreName1"), PlayerPrefs.GetInt("highScore1")));
        list.Add(new KeyValuePair<string, int>(PlayerPrefs.GetString("highScoreName2"), PlayerPrefs.GetInt("highScore2")));
        list.Add(new KeyValuePair<string, int>(PlayerPrefs.GetString("highScoreName3"), PlayerPrefs.GetInt("highScore3")));
        list.Add(new KeyValuePair<string, int>(PlayerPrefs.GetString("highScoreName4"), PlayerPrefs.GetInt("highScore4")));

        list = list.OrderByDescending(x => x.Value).ToList();

        foreach (var element in list)
        {
            Console.WriteLine(element);
        }

        KeyValuePair<string, int> high = list[0];
        //KeyValuePair<string, int> high = new KeyValuePair<string, int>("string", 222);
        int ttest = high.Value;
        //int test = PlayerPrefs.GetInt("highScore2"); 
        test = high.Key;
        score = ttest;
        
        PlayerPrefs.SetInt("highScore2", 145999993);
        PlayerPrefs.SetString("highScoreName2", "Kees");
        PlayerPrefs.Save();
        refreshHighscores();
        test = PlayerPrefs.GetString("highScoreName0");
        */
    }
}