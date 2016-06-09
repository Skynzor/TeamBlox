using UnityEngine;
using System.Collections;

public class HighscoreMenu : MonoBehaviour {

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
}
