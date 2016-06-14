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
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        Application.LoadLevel(4);

    }

    public void HighScore()
    {
        //highscore scene
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        Application.LoadLevel(2);
    }

    public void Options()
    {
        //options scene
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        Application.LoadLevel(3);
    }

    public void Exit()
    {
        //Sluit app
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        print("Shutting down...");
        Application.Quit();
    }
}
