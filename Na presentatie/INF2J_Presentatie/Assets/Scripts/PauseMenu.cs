using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /******************************PAUSE SCHERM****************************/
    //variable aan gameobject linken
    public GameObject PauseUI;

    private bool paused = false;

    /******************************SOUNDS**********************************/
    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    //Zodra de game gestart wordt zal de PauseUI niet zichtbaar zijn.
    void Start()
    {
        PauseUI.SetActive(false);
    }

    /**********************************************************************/
    /******************************UNITY ALGEMEEN**************************/
    /**********************************************************************/
    //Zodra de button Down gedrukt wordt zal er gepaused worden
    //Wanneer er nog een keer opgedrukt wordt zal het unpausen.
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        //Hier zetten we de knop naar true, omdat het gepaused is.
        //Timescale zal de game op pause zetten zodra je niet meer kan bewegen.
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        //Hier zet je de pause op uit.
        //Timescale zorgt ervoor dat de game weer start
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
            //Wanneer Timescale op 0.3 wordt gezet is alles Slowmotion.
        }
    }

    /**********************************************************************/
    /******************************RESUME KNOP*****************************/
    /**********************************************************************/
    public void Resume()
    {
        //ga verder
        paused = false;

        //Play Button Sound
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
    }

    /**********************************************************************/
    /******************************RESTART KNOP****************************/
    /**********************************************************************/
    public void Restart()
    {
        //Play Button Sound
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);

        //reload het level
        //Application.LoadLevel(Application.loadedLevel);
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }

    /**********************************************************************/
    /******************************MAINMENU KNOP***************************/
    /**********************************************************************/
    public void MainMenu()
    {
        //Play Button Sound
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        
        //level index is nu 0. Dit betekend dat de Scene met index 0 geladen wordt.
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }

    /**********************************************************************/
    /******************************QUIT KNOP*******************************/
    /**********************************************************************/
    public void Quit()
    {
        //Play Button Sound
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);

        //sluit applicatie af
        print("Shutting down...");
        Application.Quit();
    }
}
