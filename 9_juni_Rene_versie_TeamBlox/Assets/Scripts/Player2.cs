﻿using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {
    
    
    //Bepaal de maximum snelheid, snelheid en jumppower van de player
    public float maxSpeed = 20;
    public float speed = 200f;
    public float jumpPower = 250f;

    //Creëert een boolean om later te kunnen checken of de player op de grond staat
    public bool grounded;

    //Maak variabelen aan voor de rigidbody en de animation
    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        rb2d.mass = 0.5f; //Creëert de massa van de player
    }
	
	// Update is called once per frame
	void Update () {
        //Verbind de variabele grounded met de functie "grounded" binnen Unity
        //Hetzelfde geldt voor speed
        anim.SetBool("grounded", grounded);
        //anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
        //if (Input.GetAxis("Horizontal") < -0.1f)
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}

        //if (Input.GetAxis("Horizontal") > 0.1f)
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}

        //if (Input.GetButtonDown("Jump") && grounded)
        //{
        //    rb2d.AddForce(Vector2.up * jumpPower);
        //}

        //Get de horizontale as
        float h = Input.GetAxis("Horizontal");

        //Check of de player op de grond staat
        //Move player
        //W A D (omhoog, links, rechts) 
        if (grounded == true)
        {
            //rb2d.AddForce((Vector2.right * h) * speed);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.AddForce((Vector3.right * h) * speed);
                //Debug.Log("LEFT arrow ingedrukt");
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.AddForce((Vector3.right * h) * speed);
                //Debug.Log("RIGHT arrow ingedrukt");
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                grounded = false;
                rb2d.AddForce(Vector3.up * jumpPower);
                //Debug.Log("UP Arrow ingedrukt");
            }
        }
        else if (grounded == false)
        {
           //
        }
        
        
    }

    //Een functie die je kunt maken die Unity automatisch aanroept
    void FixedUpdate()
    {
        //Deze variabelen zorgen ervoor dat de player niet wegglijdt nadat het heeft bewogen/gesprongen
        //Doe niets met de 'y' as
        //Doe niets met de 'z' as (het is geen 3D, maar 2D)
        //Geef de 'x' as een waarde onder 1 aan, zodat de player niet wegglijdt
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;



        //Doe alsof er weerstand is en daarmee de snelheid van de player te verminderen
        //Check of de player op de grond staat en voer dan de easeVelocity uit
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }



        //Voeg een limiet toe aan de snelheid van de player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.transform.tag == "MovingPlatform")
        {
            grounded = true;
            transform.parent = coll.transform;
        }


        if (coll.gameObject.tag == "Lava")
        {
            Destroy(gameObject);
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        grounded = false;
        transform.parent = null;
    }
}