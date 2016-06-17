using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class hitFinishLine_Level_2 : MonoBehaviour {

    //In de class hitFinishLine staat alles uitgelegd.
    //Gelieve daarna te kijken voor comments.

    //Sound effects
    public AudioClip victorySound1;
    public AudioClip victorySound2;

    bool player1Arrived = false;
    bool player2Arrived = false;

    public Text levelComplete;

    private bool paused = false;

    void Start()
    {
        levelComplete = GameObject.Find("Canvas/LevelComplete").GetComponent<Text>();
        levelComplete.text = "";
    }

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

    IEnumerator LoadAfterDelay(int levelIndex)
    {
        SoundManager.soundInstance.RandomizeSfx(victorySound1, victorySound2);
        yield return new WaitForSeconds(06); // wacht 6 seconden
        //Application.LoadLevel(6); // Level 3
        SceneManager.LoadScene(6); // level 3

    }
}
