using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class HighscoreMenu : MonoBehaviour
{

    public List<Text> Texts;

    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    // Use this for initialization
    void Start()
    {
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
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        //terug naar hoofdmenu scene
        Application.LoadLevel(0);
    }
}