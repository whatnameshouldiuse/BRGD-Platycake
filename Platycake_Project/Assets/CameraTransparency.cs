using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparency : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position - transform.position).magnitude;
        float scaling = Mathf.Max(distance, 1);
        transform.localScale = new Vector3(1/scaling, 1/scaling, 1/scaling);
        transform.localPosition = new Vector3(0, - scaling/2, 0);
    }
}
