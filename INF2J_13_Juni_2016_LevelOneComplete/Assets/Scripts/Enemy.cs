using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speed = 50f;

    public float velocity = 10f;

    public Transform sightStart;
    public Transform sightEnd;

    public bool colliding;

    public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.mass = 100f; //Creëert de massa van de enemy

        Transform sightStartTrans = GameObject.Find("Enemy/SightStart").transform;
        Transform sightEndTrans = GameObject.Find("Enemy/SightEnd").transform;

        sightStart = GameObject.Find("Enemy/SightStart").transform;
        sightEnd = GameObject.Find("Enemy/SightEnd").transform;
    }

    // Update is called once per frame
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
