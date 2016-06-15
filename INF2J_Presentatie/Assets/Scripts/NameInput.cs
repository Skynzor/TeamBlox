using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void submit()
    {
        GameObject inputFieldGo = GameObject.Find("NameInputField");
        InputField inputFieldCo = inputFieldGo.GetComponent<InputField>();
        Score.addScore(inputFieldCo.text);
        Application.LoadLevel(2);
    }
}
