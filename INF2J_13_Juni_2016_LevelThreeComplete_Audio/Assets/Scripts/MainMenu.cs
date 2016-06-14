using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

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
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
    }

    public void HighScore()
    {
        //highscore scene
        Application.LoadLevel(2);
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
    }

    public void Options()
    {
        //options scene
        Application.LoadLevel(3);
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
    }

    public void Exit()
    {
        //Sluit app
        print("Shutting down...");
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        Application.Quit();
    }
}
