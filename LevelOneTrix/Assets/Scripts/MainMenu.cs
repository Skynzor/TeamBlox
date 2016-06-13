using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        //levelselect scene
        Application.LoadLevel(4);
    }

    public void HighScore()
    {
        //highscore scene
        Application.LoadLevel(2);
    }

    public void Options()
    {
        //options scene
        Application.LoadLevel(3);
    }

    public void Exit()
    {
        //Sluit app
        print("Shutting down...");
        Application.Quit();
    }
}
