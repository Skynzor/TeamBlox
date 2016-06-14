using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class HighscoreMenu : MonoBehaviour
{

    public List<Text> Texts;



    // Use this for initialization
    void Start()
    {

        /* Test shizzl
        PlayerPrefs.SetInt("highScore0", -5);
        PlayerPrefs.SetString("highScoreName0", "test0");

        PlayerPrefs.SetInt("highScore1", -10);
        PlayerPrefs.SetString("highScoreName1", "test1");

        PlayerPrefs.SetInt("highScore2", -30);
        PlayerPrefs.SetString("highScoreName2", "test2");

        PlayerPrefs.SetInt("highScore3", -20);
        PlayerPrefs.SetString("highScoreName3", "test3");

        PlayerPrefs.SetInt("highScore4", -50);
        PlayerPrefs.SetString("highScoreName4", "test4");
        

        PlayerPrefs.Save();
        Score.refreshHighscores();
        */

        Text[] highScores = new Text[5];
        Text[] highScoresName = new Text[5];
        for (int i = 0; i < 5; i++)
        {
            print(i.ToString());
            highScores[i] = GameObject.Find("highScore" + i).GetComponent<Text>();
            highScoresName[i] = GameObject.Find("highScoreName" + i).GetComponent<Text>();

            highScores[i].text = PlayerPrefs.GetInt("highScore" + i, 0).ToString();
            highScoresName[i].text = (i + 1).ToString() + ". " + PlayerPrefs.GetString("highScoreName" + i, "");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //kan terug naar hoofdmenu, maar ook spel?
    public void Back()
    {
        //terug naar hoofdmenu scene
        Application.LoadLevel(0);
    }
}