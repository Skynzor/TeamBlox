using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    /******************************SOUND***********************************/
    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    // Use this for initialization
    void Start()
    {

    }

    /**********************************************************************/
    /******************************UNITY ALGEMEEN**************************/
    /**********************************************************************/
    // Update is called once per frame
    void Update()
    {

    }

    /**********************************************************************/
    /******************************TERUGKNOP*******************************/
    /**********************************************************************/
    // Terug naar hoofdmenu
    public void Back()
    {
        //Play Button Sound
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);

        //terug naar hoofdmenu scene
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }

    /**********************************************************************/
    /******************************LEVEL 1 KNOP****************************/
    /**********************************************************************/
    //start level 1
    public void PlayLevelOne()
    {
        //Play Button Sound
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);

        //load level 1
        //Application.LoadLevel(1);
        SceneManager.LoadScene(1);

        //stop sound en destroy soundInstance
        SoundManager.soundInstance.musicSource.Stop();
        Destroy(SoundManager.soundInstance);

        //
        Score.startLevel(60);
    }

    /**********************************************************************/
    /******************************LEVEL 2 KNOP****************************/
    /**********************************************************************/
    //start level 2
    public void PlayLevelTwo()
    {
        //Play Button Sound
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);

        //load level 2
        //Application.LoadLevel(5);
        SceneManager.LoadScene(5);

        //stop sound en destroy soundInstance
        SoundManager.soundInstance.musicSource.Stop();
        Destroy(SoundManager.soundInstance);
    }

    /**********************************************************************/
    /******************************LEVEL 3 KNOP****************************/
    /**********************************************************************/
    //start level 3
    public void PlayLevelThree()
    {
        //Play Button Sound
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        
        //load level 3
        //Application.LoadLevel(6);
        SceneManager.LoadScene(6);

        //stop sound en destroy soundInstance
        SoundManager.soundInstance.musicSource.Stop();
        Destroy(SoundManager.soundInstance);
    }
}
