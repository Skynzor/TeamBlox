﻿using UnityEngine;
using System.Collections;

public class GroundCheckP2_2 : MonoBehaviour {

    private Player2_2 player2;

    void Start()
    {
        player2 = gameObject.GetComponentInParent<Player2_2>();
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