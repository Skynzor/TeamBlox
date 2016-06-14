using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour
{
    //Voor dropdown

    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    //Zet de bool playAudio in SoundManager to false om audio uit te zetten. True om het weer aan te zetten.
    //SoundManager.soundInstance.musicSource.Stop();
  

    // Use this for initialization
    void Start()
    {
        //Voor dropdown
    }

    //Voor dropdown
    

    // Update is called once per frame
    void Update()
    {

    }

    //kan terug naar hoofdmenu, maar ook spel?
    public void Back()
    {
        //terug naar hoofdmenu scene
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
        Application.LoadLevel(0);
    }
}
