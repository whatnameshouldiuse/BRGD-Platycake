using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDetails : MonoBehaviour
{
    [SerializeField] private GameObject details1Head;
    [SerializeField] private GameObject details2Head;
    [SerializeField] private GameObject details3Head;
    [SerializeField] private GameObject details1;
    [SerializeField] private GameObject details2;
    [SerializeField] private GameObject details3;
    [SerializeField] private Vector2 detailSize;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 topRight = transform.position + new Vector3(transform.localScale.x*5, 0, transform.localScale.z * 5);
        Vector3 bottomLeft = transform.position - new Vector3(transform.localScale.x*5, 0, transform.localScale.z * 5);
        float width = topRight.x - bottomLeft.x;
        float height = topRight.z - bottomLeft.z;

        float numColumns = width / detailSize.x;
        float numRows = height / detailSize.y;
        print(numColumns);

        for(int column = 0; column < numColumns; column++)
        {
            for (int row = 0; row < numRows; row++)
            {
                Vector2 cellBottomLeft = new Vector2(column * detailSize.x, row * detailSize.y);
                Vector2 cellTopRight = new Vector2((column+1) * detailSize.x, (row+1) * detailSize.y);

                var position1 = new Vector3(Random.Range(cellBottomLeft.x, cellTopRight.x), 0.1f, Random.Range(cellBottomLeft.y, cellTopRight.y));
                GameObject go1 = Instantiate(details1, position1, Quaternion.identity);
                go1.transform.localScale = new Vector3(detailSize.x * 0.1f, 1, detailSize.y * 0.1f);
                go1.transform.parent = details1Head.transform;

                var position2 = new Vector3(Random.Range(cellBottomLeft.x, cellTopRight.x), 0.2f, Random.Range(cellBottomLeft.y, cellTopRight.y));
                GameObject go2 = Instantiate(details2, position2, Quaternion.identity);
                go2.transform.localScale = new Vector3(detailSize.x * 0.1f, 1, detailSize.y * 0.1f);
                go2.transform.parent = details2Head.transform;

                var position3 = new Vector3(Random.Range(cellBottomLeft.x, cellTopRight.x), 0.3f, Random.Range(cellBottomLeft.y, cellTopRight.y));
                GameObject go3 = Instantiate(details3, position3, Quaternion.identity);
                go3.transform.localScale = new Vector3(detailSize.x * 0.1f, 1, detailSize.y * 0.1f);
                go3.transform.parent = details3Head.transform;
            }
        }
    }
}
