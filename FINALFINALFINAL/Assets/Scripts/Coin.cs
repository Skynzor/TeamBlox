using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

    public AudioClip coinPickup;

    void Start()
    {

    }

    void Update()
    {

    }

    //Trigger voor oppakken coin. Verwijderd de coin, verhoogt de score en speelt audio af.
    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
        Score.incScore(1);
        SoundManager.soundInstance.RandomizeSfx(coinPickup);
    }
}
