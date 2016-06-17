using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    //Dit is de GroundCheck class. Dit spreekt voorzich.
    //Maar om het duidelijker te maken, hier wordt de class GroundCheck gebruikt om collissions te gebruiken om na te gaan of de speler op de grond staat.
    //Wanneer de speler in de lucht vliegt zal de speler in theorie neit meer grounded zijn en dus andere voorwaarden hebben.

    private Player1 player1;

    void Start ()
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