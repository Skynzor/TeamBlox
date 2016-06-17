using UnityEngine;

public class Platform1move : MonoBehaviour {

    //Dit is de platform bewegings class.
    //Hier wordt een platform gemaakt die punten volgt die je kunt aangeven binnen unity.


        //Platform gameObject variabele
    public GameObject Platform;
        //Bewegingssnelheid variabele
    public float moveSpeed;
        //Hier wordt de huidige punt van de platform in opgeslagen
    private Transform currentPoint;
        //Hierin kunnen de punten worden aangegeven dat de platform tussen moet bewegen.
    public Transform[] points;
    public int pointSelection;

    void Start()
    {
        //Hier starten wij met de huidige positie van het platform.
        currentPoint = points[pointSelection];
    }

    void Update()
    {
        //Hier zeggen wij dat de bewegingssnelheid van de platform afgeleid wordt tussen de frames van Unity en de huidige positie waar het vandaan kwam.
         Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

        //Hier zeggen wij dat het moet loopen tussen de huidige positie en de aantal posities dat aangegeven wordt binnen de editor.
        if (Platform.transform.position == currentPoint.position)
        {
            pointSelection++;

            if(pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];
     }  
    }

    void FixedUpdate()
    {

    }
}
