using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour
{
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
    }
}
