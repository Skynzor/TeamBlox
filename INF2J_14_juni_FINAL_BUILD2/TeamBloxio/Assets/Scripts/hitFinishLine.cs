using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hitFinishLine : MonoBehaviour {

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

            Score.addScore("Bob");//REMOVE!
            Score.refreshHighscores();
            Application.LoadLevel(2);//

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
        yield return new WaitForSeconds(03); // wacht 3 seconden
        Application.LoadLevel(5); // Level 2

    }
}
