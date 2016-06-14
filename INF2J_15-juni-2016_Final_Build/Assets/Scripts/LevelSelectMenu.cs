using UnityEngine;
using System.Collections;

public class LevelSelectMenu : MonoBehaviour
{

    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //kan terug naar hoofdmenu, maar ook spel?
    public void Back()
    {
        //terug naar hoofdmenu scene
        Application.LoadLevel(0);
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);

    }

    //start level 1
    public void PlayLevelOne()
    {
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        Application.LoadLevel(1);

        SoundManager.soundInstance.musicSource.Stop();
        Destroy(SoundManager.soundInstance);

        Score.startLevel(60);
    }

    //start level 2
    public void PlayLevelTwo()
    {
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        Application.LoadLevel(5);

        SoundManager.soundInstance.musicSource.Stop();
        Destroy(SoundManager.soundInstance);
    }

    //start level 3
    public void PlayLevelThree()
    {
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        Application.LoadLevel(6);

        SoundManager.soundInstance.musicSource.Stop();
        Destroy(SoundManager.soundInstance);
    }
}
