using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NPC : MonoBehaviour
{
    [Serializable]
    public struct ItemTrade {
        // The item the NPC wants
        public Inventory.Item want;

        // The item the NPC needs
        public Inventory.Item have;
    }

    public ItemTrade itemTrade;

    public GameObject canvas;
    public List<string> dialogueList;
    public TextMeshProUGUI dialogueText;

    public GameObject worldItem;

    private Queue<string> dialogueQueue;
    private GameObject player;

    private ItemHolder itemHolder;

    private const double RADIUS = 10f;
    private const float INTERPOLATION = 0.1f;

    // Start is called before the first frame update
    void Start() {
        // Find the player GameObject
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        this.player = players[0];
        this.canvas.transform.localScale = Vector3.zero;

        this.dialogueQueue = new Queue<string>(dialogueList);

        this.itemHolder = this.GetComponent<ItemHolder>();
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

        checkCurrentItems();
    }

    private void checkCurrentItems() {
        foreach(Inventory.Item item in this.itemHolder.itemList) {
            if(item.sprite == itemTrade.want.sprite) {
                // The item in the item holder is what the NPC wants, throw out a new item
                dropItem(itemTrade.have);
            } else {
                // The item in the item holder is not needed by the NPC, so throw it out...
                dropItem(item);
            }
        }
        // Remove all items from the item holder's item list
        this.itemHolder.itemList.Clear();
    }

    private void dropItem(Inventory.Item item) {
        GameObject itemObject = Instantiate(this.worldItem) as GameObject;
        itemObject.GetComponent<SpriteRenderer>().sprite = item.sprite;
        WorldItem worldItemScript = itemObject.GetComponent<WorldItem>();

        item.fromPlayer = false;
        worldItemScript.SetItem(item);

        itemObject.transform.position = this.transform.position;
        Vector3 direction = (this.player.transform.position - this.transform.position).normalized;
        itemObject.GetComponent<Rigidbody>().velocity = direction * 10f;
    }
}
