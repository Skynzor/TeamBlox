using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class OptionsMenu : MonoBehaviour
{
    //Voor dropdown
    Dropdown dropdown;
    int selectedindex;

    //Voor windowed
    bool checkedStatus;
    Button windowedButton;
    Image vinkAan;
    Image vinkUit;

    //Voor audio
    //Button on;
    //Button off;
    //static bool audioOnOff; //true is on, false is off

    // Use this for initialization
    void Start()
    {
        //Voor audio
        //on = GameObject.Find("SoundOn").GetComponent<Button>();
        //off = GameObject.Find("SoundOff").GetComponent<Button>();
        //audioOnOff = true;

        //Voor windowed
        checkedStatus = checkFullScreen();

        windowedButton = GameObject.Find("windowedButton").GetComponent<Button>();
        vinkAan = GameObject.Find("welAangevinkt").GetComponent<Image>();
        vinkUit = GameObject.Find("nietAangevinkt").GetComponent<Image>();
        //Beide knoppen niet te zien
        vinkAan.enabled = false;
        vinkUit.enabled = false;
        //set
        setCheckedOrUnchecked();

        //Voor dropdown
        dropdown = GameObject.FindGameObjectWithTag("resolutiedropdown").GetComponent<Dropdown>();
        dropdown.options.Clear();
        List<string> dropdownlist = new List<string>();

        //add resolutions
        Resolution[] resolutions = Screen.resolutions;
        foreach (Resolution res in resolutions)
        {
            dropdownlist.Add(res.width + "x" + res.height);
            //dropdownlist.Add(res.ToString());
        }
        //Screen.SetResolution(resolutions[0].width, resolutions[0].height, true);

        foreach (string option in dropdownlist)
        {
            dropdown.options.Add(new Dropdown.OptionData(option));
        }

        /*Zet geselecteerde waarde op current resolutie*/
        //current game resolutie
        string caption = Screen.width + "x" + Screen.height;
        //zet als geselecteerde waarde
        dropdown.captionText.text = caption;

    }

    //kan terug naar hoofdmenu, maar ook spel?
    public void Back()
    {
        //terug naar hoofdmenu scene
        Application.LoadLevel(0);
    }

    //Voor audio
    public void setAudioOn()
    {
        SoundManager.soundInstance.playAudio = true;
        SoundManager.soundInstance.musicSource.Play();
    }
    public void setAudioOff()
    {
        SoundManager.soundInstance.playAudio = false;
        SoundManager.soundInstance.musicSource.Stop();
    }


    //Voor dropdown
    // Update is called once per frame
    void Update()
    {
        //geen onchange functies aanroepen want dan wordt het getriggerd bij het openen van de scene
    }

    /*als andere geselecteerd is, doe wat*/
    public void dropdowncheck()
    {
        //string nieuweCaption = "";
        List<int> nieuweHightWidth = new List<int>();

        //zoveel als er resoluties bestaan
        Resolution[] resolutions = Screen.resolutions;
        for (int i = 0; i < resolutions.Length; i++)
        {
            //index 0 is current game resolutie
            if (dropdown.value == i)
            {
                nieuweHightWidth.Clear();
                //nieuweCaption = getResString(i);
                nieuweHightWidth = getResWidthHeight(dropdown.value);
                //dropdown.captionText.text = nieuweCaption;

                //dropdown.captionText.text = dropdown.value + "; w x h:" + nieuweHightWidth[0] + ", " + nieuweHightWidth[1];
                Screen.SetResolution(nieuweHightWidth[0], nieuweHightWidth[1], checkedStatus);
                Application.LoadLevel(3);
                
            }

        }
    }

    /*krijg string resolutie van gekozen resolutie om caption goed te zetten*/
    public string getResString(int selectedIndexRes)
    {
        string selectedRes = "";

        Resolution[] resolutions = Screen.resolutions;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (i == selectedIndexRes)
            {
                selectedRes = resolutions[i].width + "x" + resolutions[i].height;
            }
            else
            {
                selectedRes = "Gekozen resolutie niet gevonden.";
            }
        }
        //Screen.SetResolution(resolutions[0].width, resolutions[0].height, true);
        return selectedRes;
    }

    /*krijg width en hight resolutie van gekozen resolutie om resolutie goed te zetten*/
    public List<int> getResWidthHeight(int selectedIndexRes)
    {
        List<int> selectedRes = new List<int>();

        Resolution[] resolutions = Screen.resolutions;
        //width height refreshrate
        for (int i = 0; i < resolutions.Length+1; i++)
        {
            if (i == selectedIndexRes)
            {
                selectedRes.Clear();
                selectedRes.Add(resolutions[i].width);
                selectedRes.Add(resolutions[i].height);
            }
            else
            {
                selectedRes.Add(0);
            }
        }
        //Screen.SetResolution(resolutions[0].width, resolutions[0].height, true);
        return selectedRes;
    }

    //Voor windowed
    bool checkFullScreen()
    {
        //Screen.fullScreen = !Screen.fullScreen

        //als fullscreen == true, return true
        if (Screen.fullScreen == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //check of checked geshowt moet worden of unchecked
    void setCheckedOrUnchecked()
    {
        checkedStatus = checkFullScreen(); //true = full, false = windowed

        if (checkedStatus == true)
        {
            //unchecked
            vinkAan.enabled = false;
            vinkUit.enabled = true;
        }
        else
        {
            //checked
            vinkAan.enabled = true;
            vinkUit.enabled = false;
        }
    }

    //klik op knop voor windowed
    public void windowedCheck()
    {
        //klik switcht tussen fullscreen en windowed
        checkedStatus = checkFullScreen(); //true = full, false = windowed
        if (checkedStatus == true)
        {
            Screen.fullScreen = false;
            Application.LoadLevel(3);

            setCheckedOrUnchecked();
        }
        else
        {
            Screen.fullScreen = true;
            Application.LoadLevel(3);

            setCheckedOrUnchecked();
        }
    }

    
}