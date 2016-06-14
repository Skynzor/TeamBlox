using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraPlayer1 : MonoBehaviour {

    //oude code
    //public Transform player;
    //public Vector3 offset;

    //nieuwe code
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player1;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    void Start()
    {
        // Oude code
        //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

        //nieuwe code
        player1 = GameObject.FindGameObjectWithTag("Player1");
        showLevelText();
        //setTime();
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player1.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player1.transform.position.y, ref velocity.x, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if(bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }

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

