using UnityEngine;
using System.Collections;

public class MovingPlatform1 : MonoBehaviour {

    public Transform platform;

    public Transform startTransform;

    public Transform endTransform;

    float platformSpeed;

    void FixedUpdate()
    {
        platform.GetComponent<Rigidbody>().MovePosition(platform.position + Vector3.right * platformSpeed * Time.fixedDeltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(startTransform.position, platform.localScale);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endTransform.position, platform.localScale);

    }
}
