using UnityEngine;
using System.Collections;

public class LevelSelectMenu : MonoBehaviour {

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
    }

    //start level 1
    public void PlayLevelOne()
    {
        Application.LoadLevel(1);
        SoundManager.soundInstance.musicSource.Stop();
        Destroy(SoundManager.soundInstance);

        Score.startLevel(60);
    }

    //start level 1
    public void PlayLevelTwo()
    {
        Application.LoadLevel(1);
    }

    //start level 1
    public void PlayLevelThree()
    {
        Application.LoadLevel(1);
    }
}
