using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject player;
    float speed = 5f;
    float yOffset = 3f;
    float zOffset = 5f;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(35f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, interpolation);
        position.y = yOffset;
        position.z = Mathf.Lerp(this.transform.position.z, player.transform.position.z - zOffset, interpolation);

        this.transform.position = position;
    }
}
