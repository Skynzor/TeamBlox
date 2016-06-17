using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraPlayer1 : MonoBehaviour {

    //Dit is de camera class
    //Met deze class wordt er rekening gehouden met de totale zicht wat een speler kan en mag zien
    //zo zal de camera alleen speler 1 volgen, om meer teamwork te creëren met de mede speler.


        //Dit is een Vector2 structure die gebruikt wordt om in 2D punten te creëren.
        //Me de variabele VELOCITY wordt snelheid gemeten.
    private Vector2 velocity;


        //Met de SmoothTime variabele wordt een soepele beweging gecreëerd met de camera
    public float smoothTimeY;
    public float smoothTimeX;

        //Hier zeg ik dat Player1 een gameobject is.
    public GameObject player1;

        //Dit is een variabele die gebruikt gaat worden om het limiet aan te geven van de camera
    public bool bounds;

        //Hier wordt de camera positie weergegeven in een 3D.
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

        //Bij de functie Start() wordt een gameobject aangeroepen doormiddel van een Tag, de TAG geef je aan in Unity.
        //Vervolgens geef je met showLevelTexT(); de level text weer die in de canvas (binnen unity) is geplaatst.
    void Start()
    {
        
        player1 = GameObject.FindGameObjectWithTag("Player1");
        showLevelText();

    }


        //FixedUpdate() functie is een functie die 1x per paar frames uitgevoerd wordt.
    void FixedUpdate()
    {
        //Hiermee wordt de camera snelheid tegen over speler 1 opgewogen, zodat de camera niet sneller beweegt dan Speler1.
        float posX = Mathf.SmoothDamp(transform.position.x, player1.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player1.transform.position.y, ref velocity.x, smoothTimeY);


        //Hier geef je aan dat positie.Z een limiet wordt die later getransformed wordt
        transform.position = new Vector3(posX, posY, transform.position.z);


        //Hier wordt gezegd dat als de camera een bepaalde positie heeft bereikt moet het stoppen met bewegen.
        //Zo zal Speler 1 altijd in beeld blijven.
        if(bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }

        //Hier wordt de level text per level opgehaald doormiddel van een Case.
        //Elke case wordt vergeleken met de index nummer (te zien binnen Unity) met de string die voor de betreffende case is uitgeschreven.
        //Vervolgens wordt er een Fade-Out geschreven doormiddel van crossfadealpha.
    public void showLevelText()
    {
        Text levelText = GameObject.Find("levelText").GetComponent<Text>();
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        string text;
        switch (sceneIndex)
        {
            case 1:
                text = "Level 1: Tokyo City";
                break;
            case 5:
                text = "Level 2: Cloud Kingdom";
                break;
            case 6:
                text = "Level 3: Hell Freezes Over";
                break;
            default:
                text = "";
                break;
        }
        levelText.text = text;
        levelText.CrossFadeAlpha(0f, 3.5f, false);
    }
}

