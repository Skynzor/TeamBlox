using UnityEngine;
using System.Collections;

public class Groundcheck_Level2 : MonoBehaviour {

    //Om het makkelijker te maken met nakijken bekijk de GroundCheck class.
    //Hierin wordt hetzelfde behandelt.

    private Player1 player1;

    void Start()
    {
        player1 = gameObject.GetComponentInParent<Player1>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player1.grounded = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player1.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player1.grounded = false;
    }
}
