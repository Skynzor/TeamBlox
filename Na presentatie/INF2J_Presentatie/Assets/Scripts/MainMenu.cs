using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    /******************************SOUND***********************************/
    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    // Use this for initialization
    void Start () {
	
	}

    /**********************************************************************/
    /******************************UNITY ALGEMEEN**************************/
    /**********************************************************************/
    // Update is called once per frame
    void Update () {
	
	}

    /**********************************************************************/
    /******************************PLAY KNOP*******************************/
    /**********************************************************************/
    public void Play()
    {
        //
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);

        //load levelselect scene
        //Application.LoadLevel(4);
        SceneManager.LoadScene(4);
    }

    /**********************************************************************/
    /******************************HIGHSCORE KNOP**************************/
    /**********************************************************************/
    public void HighScore()
    {
        //
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);

        //load highscore scene
        //Application.LoadLevel(2);
        SceneManager.LoadScene(2);
    }

    /**********************************************************************/
    /******************************OPTIONS KNOP****************************/
    /**********************************************************************/
    public void Options()
    {
        //
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);

        //load options scene
        //Application.LoadLevel(3);
        SceneManager.LoadScene(3);
    }

    /**********************************************************************/
    /******************************EXIT KNOP*******************************/
    /**********************************************************************/
    public void Exit()
    {
        //
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        
        //Sluit app
        print("Shutting down...");
        Application.Quit();
    }
}
