using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject canvas;
    public List<string> dialogueList;
    public TextMeshProUGUI dialogueText;

    private Queue<string> dialogueQueue;
    private GameObject player;

    private const double RADIUS = 10f;
    private const float INTERPOLATION = 0.1f;

    // Start is called before the first frame update
    void Start() {
        // Find the player GameObject
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        this.player = players[0];
        this.canvas.transform.localScale = Vector3.zero;

        this.dialogueQueue = new Queue<string>(dialogueList);
    }

    // Update is called once per frame
    void Update() {
        double currentDistance = Vector3.Distance(this.player.transform.position, this.transform.position);
        bool isWithinDistance = currentDistance <= RADIUS;

        Vector3 targetScale = isWithinDistance ? Vector3.one : Vector3.zero;
        this.canvas.transform.localScale = Vector3.Lerp(canvas.transform.localScale, targetScale, INTERPOLATION);

        if(dialogueQueue.Count > 0) {
            if(isWithinDistance && Input.GetKeyDown(KeyCode.Space)) {
                dialogueQueue.Enqueue(dialogueQueue.Dequeue());
            }
            dialogueText.text = dialogueQueue.Peek();
        }
    }
}
