using UnityEngine;
using System.Collections;

public class GroundCheckP2 : MonoBehaviour {

    private Player2 player2;

    void Start()
    {
        player2 = gameObject.GetComponentInParent<Player2>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player2.grounded = true;

        //if (col.gameObject.tag == "MovingPlatform")
        //{
        //    transform.parent = col.transform;

        //}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player2.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player2.grounded = false;

        //if (col.gameObject.tag == "MovingPlatform")
        //{
        //    transform.parent = null;
        //}
    }
}
