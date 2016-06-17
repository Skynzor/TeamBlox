using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class hitFinishLine : MonoBehaviour {

    //Dit is de finishline class.
    //Dit hebben wij gemaakt omdat wij erachter kwamen dat wij nog geen finish hadden per level en dus ook geen transitie.

        //Geluidseffecten
    public AudioClip victorySound1;
    public AudioClip victorySound2;

        //Beide spelers worden op False gezet omdat ze niet in de finish staan.
    bool player1Arrived = false;
    bool player2Arrived = false;

        //De levelcomplete variabele
    public Text levelComplete;

    private bool paused = false;

    void Start()
    {
        //Hierin wordt de LevelComplete text aangeroepen binnen de canvas.
        levelComplete = GameObject.Find("Canvas/LevelComplete").GetComponent<Text>();  
        levelComplete.text = "";
    }

        //Hier wordt er gekeken wanneer een speler een collision heeft met de finish (of beter gezegd, in de finish staat) zal dit een status wijzigen van False naar True.
        //Hier wordt er afgedwongen dat beide spelers tegelijk in op of in de finish moeten staan doormiddel van een TRUE / FALSE status.
    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject hitObj = coll.gameObject;

        if (hitObj.tag == "Player1")
        {
            player1Arrived = true;
        }

        if (hitObj.tag == "Player2")
        {
            player2Arrived = true;
        }

        if (player1Arrived && player2Arrived)
        {
            Score.setTimeScore();
            levelComplete.text = "Level Complete!";
            StartCoroutine(LoadAfterDelay(0));
        }
    }

        //Hier wordt er gezegt dat als een speler geen collision meer heeft met de finish, geef dan een debug weer in de console dat een speler wegloopt.
        //Dit is niet te zien in de game, maar alleen te zien voor de developers.
    void OnTriggerExit2D(Collider2D coll)
    {
        GameObject hitObj = coll.gameObject;

        if (hitObj.tag == "Player1")
        {
            player1Arrived = false;
            Debug.Log("Player 1 loopt weg");
        }

        if (hitObj.tag == "Player2")
        {
            player2Arrived = false;
            Debug.Log("Player 2 loopt weg");
        }
    }

    //Hier wordt een victory geluid afgespeeld op de actieve level (index).
    IEnumerator LoadAfterDelay(int levelIndex)
    {
		//Play Victory Sound
        SoundManager.soundInstance.RandomizeSfx(victorySound1, victorySound2);
        yield return new WaitForSeconds(06); // wacht 6 seconden
        SceneManager.LoadScene(5); // level 2

    }
}
