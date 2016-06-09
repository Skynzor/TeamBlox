using UnityEngine;
using System.Collections;

public class CameraPlayer1 : MonoBehaviour {

    //oude code
    //public Transform player;
    //public Vector3 offset;

    //nieuwe code
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    void Start()
    {
        // Oude code
        //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

        //nieuwe code
        player = GameObject.FindGameObjectWithTag("Player1");
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.x, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if(bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}

