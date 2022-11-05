using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapLocation : MonoBehaviour
{
    [SerializeField] Image miniPlayer;
    [SerializeField] GameObject player;
    [SerializeField] Image minimap;
    [SerializeField] private float miniHeight;
    [SerializeField] private float miniWidth;
    [SerializeField] private Vector2 mapBottomLeft;
    [SerializeField] private Vector2 mapTopRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float heightRatio = (player.transform.position.z - mapBottomLeft.y) / (mapTopRight.y - mapBottomLeft.y);
        float widthRatio = (player.transform.position.x - mapBottomLeft.x) / (mapTopRight.x - mapBottomLeft.x);
        float xStart = -miniWidth / 2;
        float yStart = -miniHeight / 2;
        float xFinal = xStart + widthRatio * miniWidth;
        float yFinal = yStart + heightRatio * miniHeight;
        miniPlayer.rectTransform.localPosition = new Vector3(xFinal, yFinal, 0);
    }
}
