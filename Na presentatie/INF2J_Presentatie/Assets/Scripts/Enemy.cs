using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    //Dit is de enemy class. Hierin worden alle voorwaarden voor een enemy opgesteld.


        //Hier wordt de snelheid bepaald van de enemy.
    public float speed = 10f;

        //Hier de wendbaarheid van de enemy
    public float velocity = 10f;

        //Hier wordt een start en een eindpunt aangemaakt
    public Transform sightStart;
    public Transform sightEnd;

        //Hier een bool voor het raken van collision boxes.
    public bool colliding;

        //Hier wordt een variabele gemaakt voor RigidBody2D
    public Rigidbody2D rb2d;

	    //Start wordt uitgevoerd zodra de applicatie wordt gestart.
	void Start () {
        //Hier roepen wij de rigidbody component aan binnen unity
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.mass = 100f; //Creëert de massa van de enemy

        //Hier geven wij aan dat er een tegenovergestelde voorwaarde moet zijn zodra de eerste voorwaarde verandert.
        //Dus zodra de enemy rechts raakt, zal dit links draaien en vice versa.
        Transform sightStartTrans = GameObject.Find("Enemy/SightStart").transform;
        Transform sightEndTrans = GameObject.Find("Enemy/SightEnd").transform;

        sightStart = GameObject.Find("Enemy/SightStart").transform;
        sightEnd = GameObject.Find("Enemy/SightEnd").transform;
    }

        //De Update functie wordt 1x aangeroepen per frame.
        //Hier wordt er gezegd dat het moet draaien en dit wordt gechecked per frame.
    void Update () {
        rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);

        colliding = Physics2D.Linecast(sightStart.position, sightEnd.position);

        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                velocity *= -1;
        }
        
	}
}
