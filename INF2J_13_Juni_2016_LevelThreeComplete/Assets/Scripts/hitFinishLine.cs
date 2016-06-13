using UnityEngine;
using System.Collections;

public class hitFinishLine : MonoBehaviour {

    bool player1Arrived = false;
    bool player2Arrived = false;

	void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject hitObj = coll.gameObject;

        if(hitObj.tag == "Player1")
        {
            player1Arrived = true;
        }

        if (hitObj.tag == "Player2")
        {
            player2Arrived = true;
        }

        if (player1Arrived && player2Arrived)
        {
            // Level voltooid
            Debug.Log("Beide aangekomen");
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        GameObject hitObj = coll.gameObject;

        if (hitObj.tag == "Player1")
        {
            player1Arrived = false;
            Debug.Log("Player 1 loopt weg");
        }

        if (hitObj.tag == "Player2")
        {
            player2Arrived = false;
            Debug.Log("Player 2 loopt weg");
        }
    }
}
