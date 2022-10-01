using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject player;
    private float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;
    private float yOffset = 12f;
    private float zOffset = 16f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(35f, 0, 0);
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = this.transform.position;
        targetPosition.x = player.transform.position.x;
        targetPosition.z = player.transform.position.z - zOffset;
        targetPosition.y = yOffset;

        this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, smoothTime);
    }
}
