using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldingScript : MonoBehaviour
{
    [SerializeField] float distanceToFold;
    private float goalUpAngle;
    private float angle;
    private bool billboarding = true;
    [SerializeField] float foldSpeed;

    private void Start()
    {
        this.transform.LookAt(this.transform.position + Camera.main.transform.forward);

        angle = transform.rotation.eulerAngles.x;
        goalUpAngle = angle;
    }

    void Update()
    {
        if(billboarding)
        {
            this.transform.LookAt(this.transform.position + Camera.main.transform.forward);
        }
        if (transform.position.z < Camera.main.transform.position.z+distanceToFold)
        {
            // Stop billboarding
            billboarding = false;
            // Fold Down
            RotateDown();

        }
        if (transform.position.z > Camera.main.transform.position.z+distanceToFold)
        {
            RotateUp();
        }
    }

    void RotateDown()
    {
        if(angle > -130)
        {
            transform.Rotate(-foldSpeed * Time.deltaTime, 0, 0);
            angle -= foldSpeed * Time.deltaTime;
        }
    }

    void RotateUp()
    {
        if(angle <= goalUpAngle - 10)
        {
            transform.Rotate(foldSpeed * Time.deltaTime, 0, 0);
            angle += foldSpeed * Time.deltaTime;
        }
        else
        {
            billboarding = true;
        }
    }
}
