using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBobbing : MonoBehaviour
{
    [SerializeField] float scaleFactor = 0.2f;
    private Vector3 standardScale;
    private float time = 0;
    [SerializeField] float bobSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        standardScale = this.GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        this.GetComponent<RectTransform>().localScale = standardScale * (1+ scaleFactor * (0.5f *(1f + Mathf.Sin(bobSpeed * time))));
    }
}
