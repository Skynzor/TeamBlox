using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public AudioClip coinPickup;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
        Score.incScore(1);
        SoundManager.soundInstance.RandomizeSfx(coinPickup);
    }
}
