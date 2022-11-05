using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialBillboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        this.transform.LookAt(this.transform.position + Camera.main.transform.forward);
    }
}
