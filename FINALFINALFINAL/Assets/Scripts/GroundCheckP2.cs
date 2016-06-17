using UnityEngine;
using System.Collections;

public class GroundCheckP2 : MonoBehaviour {

    //Om het makkelijker te maken met nakijken bekijk de GroundCheck class.
    //Hierin wordt hetzelfde behandelt.

    private Player2 player2;

    void Start()
    {
        player2 = gameObject.GetComponentInParent<Player2>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player2.grounded = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player2.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player2.grounded = false;
    }
}
