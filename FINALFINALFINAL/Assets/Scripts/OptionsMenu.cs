using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

	/******************************SOUND***********************************/
    //Sound effects
    public AudioClip buttonSound1;
    public AudioClip buttonSound2;

    /******************************DROPDOWN********************************/
    Dropdown dropdown;
    int selectedindex;
    List<string> dropdownlist = new List<string>();
    
    /******************************WINDOWED********************************/
    bool checkedStatus;
    Button windowedButton;
    Image vinkAan;
    Image vinkUit;

    // Use this for initialization
    void Start()
    {
        /******************************WINDOWED********************************/
        checkedStatus = checkFullScreen(); //check wat de opstart status is, fullscreen of windowed

        //koppel variabele met gameobject in scene
        windowedButton = GameObject.Find("windowedButton").GetComponent<Button>();
        vinkAan = GameObject.Find("welAangevinkt").GetComponent<Image>();
        vinkUit = GameObject.Find("nietAangevinkt").GetComponent<Image>();

        //Beide knoppen niet te zien
        vinkAan.enabled = false;
        vinkUit.enabled = false;

        //set; laat het juiste plaatje zien
        setCheckedOrUnchecked();

        /******************************DROPDOWN********************************/
        //koppel variabele met gameobject in scene
        dropdown = GameObject.FindGameObjectWithTag("resolutiedropdown").GetComponent<Dropdown>();

        //maak dropdownlijst leeg
        dropdown.options.Clear();

        //vul de dropdown lijst met resoluties
        getAndSetDropdown();
    } //einde Start()

    /**********************************************************************/
    /******************************UNITY ALGEMEEN**************************/
    /**********************************************************************/
    // Update is called once per frame
    void Update()
    {
        //geen onchange functies aanroepen want dan wordt het getriggerd bij het openen van de scene
    }

    /**********************************************************************/
    /******************************TERUGKNOP*******************************/
    /**********************************************************************/
    //Terugknop naar hoofdmenu
    public void Back()
    {
		//Play Button Sound
        SoundManager.soundInstance.RandomizeSfx(buttonSound1, buttonSound2);
		
        //terug naar hoofdmenu scene
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }

    /**********************************************************************/
    /******************************AUDIO***********************************/
    /**********************************************************************/
    //set audio aan
    public void setAudioOn()
    {
        SoundManager.soundInstance.playAudio = true;
        SoundManager.soundInstance.musicSource.Play();
    }

    //set audio uit
    public void setAudioOff()
    {
        SoundManager.soundInstance.playAudio = false;
        SoundManager.soundInstance.musicSource.Stop();
    }

    /**********************************************************************/
    /******************************WINDOWED********************************/
    /**********************************************************************/
    //check de status van nu, fullscreen of windowed
    bool checkFullScreen()
    {
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
    } // einde setCheckedOrUnchecked()

    //klik op button voor windowed
    public void windowedCheck()
    {
        //klik switcht tussen fullscreen en windowed
        checkedStatus = checkFullScreen(); //true = full, false = windowed
        if (checkedStatus == true)
        {
            Screen.fullScreen = false;
            //Application.LoadLevel(3);
            SceneManager.LoadScene(3);

            //laat het juiste plaatje zien
            setCheckedOrUnchecked();
        }
        else
        {
            Screen.fullScreen = true;
            //Application.LoadLevel(3);
            SceneManager.LoadScene(3);

            //laat het juiste plaatje zien
            setCheckedOrUnchecked();
        }
    } // einde windowedCheck()

    /**********************************************************************/
    /******************************DROPDOWN********************************/
    /**********************************************************************/
    //get de juiste resoluties en set in de dropdown
    private void getAndSetDropdown()
    {
        //eerst lijst met resoluties
        int locatieminres = -1;
        bool maglocatieminresophogen = true;

        List<string> resolutionslist = new List<string>();

        //loop over de screen resoluties
        Resolution[] resolutions = Screen.resolutions;
        foreach (Resolution res in resolutions)
        {
            //zolang 800x600 nog niet gevonden is verhoog
            if (maglocatieminresophogen == true)
            {
                locatieminres++; //weten waar 800x600 staat, beginwaarde
            }

            //voeg resolutie als string toe
            resolutionslist.Add(res.width + "x" + res.height);

            //begin waarde is gevonden, stop met ophogen
            if (res.width == 800 && res.height == 600)
            {
                maglocatieminresophogen = false;
            }
        }

        //dan copy vanaf 800x600, dat is locatieminres
        for (int i = locatieminres; i < resolutionslist.Count; i++)
        {
            //van lijst resolutionslist naar nieuwe lijst dropdownlist, string
            dropdownlist.Add(resolutionslist[i]);
        }

        //voeg toe aan dropdown, eerste is current
        dropdown.options.Add(new Dropdown.OptionData(Screen.width + "x" + Screen.height));
        for (int j = 0; j < dropdownlist.Count; j++)
        {
            dropdown.options.Add(new Dropdown.OptionData(dropdownlist[j]));
        }

        //Zet geselecteerde waarde op current resolutie
        string caption = Screen.width + "x" + Screen.height;

        //zet als geselecteerde waarde
        dropdown.captionText.text = caption;
    } // einde getAndSetDropdown()

    //als andere uit dropdownlijst geselecteerd is, set de nieuwe resolutie en refresh
    public void dropdowncheck()
    {
        //loop over dropdownlist
        for (int i = 0; i < dropdownlist.Count; i++)
        {
            //gekozen index komt overeen met item in lijst; -1 omdat current resolutie toegevoegd is aan dropdownlijst
            if ((dropdown.value-1) == i)
            {
                //haal de resolutie uit de string
                string[] words = dropdownlist[i].Split(' ', 'x');
                
                //clear dropdown
                dropdown.ClearOptions();

                //voeg current toe als eerste in de dropdown lijst
                dropdown.options.Add(new Dropdown.OptionData(dropdownlist[i]));

                //voeg alle opties weer aan de dropdown lijst toe
                for (int j = 0; j < dropdownlist.Count; j++)
                {
                    //de hele lijst in dropdown
                    dropdown.options.Add(new Dropdown.OptionData(dropdownlist[j]));
                }

                //set resolutie en refresh
                Screen.SetResolution(int.Parse(words[0]), int.Parse(words[1]), checkedStatus);
                //Application.LoadLevel(3);
                SceneManager.LoadScene(3);
            }
        }
    } // einde dropdowncheck()
}