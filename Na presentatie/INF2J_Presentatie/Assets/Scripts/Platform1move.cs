using UnityEngine;

public class Platform1move : MonoBehaviour {

    public GameObject Platform;
    public float moveSpeed;
    private Transform currentPoint;
    public Transform[] points;
    public int pointSelection;

    void Start()
    {
        currentPoint = points[pointSelection];
    }

    void Update()
    {
         Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

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
