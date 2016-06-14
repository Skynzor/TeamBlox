using UnityEngine;
using System.Collections;

public class HighscoreMenu : MonoBehaviour {

    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //kan terug naar hoofdmenu, maar ook spel?
    public void Back()
    {
        //terug naar hoofdmenu scene
        Application.LoadLevel(0);
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
    }
}
