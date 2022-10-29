using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlipper : MonoBehaviour
{
    [SerializeField] float flipRate = 100f;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput < 0)
        {
            facingRight = false;
        }
        else if(horizontalInput > 0)
        {
            facingRight = true;
        }

        if (facingRight)
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, 90 * Vector3.right, Time.deltaTime*flipRate);
        }
        else
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, 180*Vector3.up + 90*Vector3.right, Time.deltaTime*flipRate);
        }
    }
}
