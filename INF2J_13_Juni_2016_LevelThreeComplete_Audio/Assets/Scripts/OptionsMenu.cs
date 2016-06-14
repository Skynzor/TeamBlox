using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour

   
{

    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    //Zet de bool playAudio in SoundManager to false om audio uit te zetten. True om het weer aan te zetten.

    //Voor dropdown


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
        Application.LoadLevel(0);
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
    }
}
