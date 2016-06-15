using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    //Zodra de game gestart wordt zal de PauseUI niet zichtbaar zijn.
    void Start()
    {
        PauseUI.SetActive(false);
    }

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

    public void Resume()
    {
        paused = false;
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
    }

    public void Restart()
    {
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(Application.loadedLevel);
    }

    public void MainMenu()
    {
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        //level index is nu 0. Dit betekend dat de Scene met index 0 geladen wordt.
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        print("Shutting down...");
        Application.Quit();
    }
}
