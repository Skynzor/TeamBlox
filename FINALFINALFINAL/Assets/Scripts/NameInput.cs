using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameInput : MonoBehaviour {


	void Start () {
	
	}
	
	void Update () {
	
	}

    //Hier wordt een inputfield gameobject aangeroepen om een naam in te kunnen vullen voor de highscores.
    //Vervolgens moet het de scene laden met een index van 2.
    public void submit()
    {
        GameObject inputFieldGo = GameObject.Find("NameInputField");
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        Score.addScore(inputFieldCo.text);
        Application.LoadLevel(2);
    }
}
