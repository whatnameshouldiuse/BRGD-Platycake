using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    [Serializable]
    public struct Item {
        public bool isIngredient;
        public bool fromPlayer;
        public Sprite sprite;

        public Item(bool isIngredient, bool fromPlayer, Sprite sprite) {
            this.isIngredient = isIngredient;
            this.fromPlayer = fromPlayer;
            this.sprite = sprite;
        }
    }

    public Queue<Item> itemQueue = new Queue<Item>();
    public List<Sprite> sprites;

    public GameObject inventoryItem;
    public GameObject worldItem;

    public const float THROW_VELOCITY = 10f;

    // Start is called before the first frame update
    void Start()
    {
        itemQueue.Enqueue(new Item(true, true, this.sprites[0]));
        itemQueue.Enqueue(new Item(true, true, this.sprites[1]));
        itemQueue.Enqueue(new Item(true, true, this.sprites[2]));
        display();
    }

    private void display() {
        // Destroy existing children
        foreach(Transform child in this.transform) {
            GameObject.Destroy(child.gameObject);
        }
        // Repopulate
        float currentHeight = 0f;
        foreach(Item item in itemQueue) {
            GameObject itemObject = Instantiate(inventoryItem) as GameObject;

            itemObject.GetComponent<Image>().sprite = item.sprite;
            itemObject.transform.SetParent(this.transform, false);

            RectTransform rectTransform = itemObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0f, currentHeight);

            currentHeight += rectTransform.rect.height;
        }
    }

    // Drop the item in the 0th index of itemQueue
    private void dropItem() {
        if(itemQueue.Count > 0) {
            Item item = itemQueue.Dequeue();
            GameObject itemObject = Instantiate(worldItem) as GameObject;
            itemObject.GetComponent<SpriteRenderer>().sprite = item.sprite;

            WorldItem worldItemScript = itemObject.GetComponent<WorldItem>();
            item.fromPlayer = true;
            worldItemScript.SetItem(item);

            itemObject.transform.position = this.transform.position;

            itemObject.GetComponent<Rigidbody>().velocity = calculateThrowVelocity();
            display();
        }
    }

    private Vector3 calculateThrowVelocity() {
        // Get all NPC positions
        Vector3[] npcPositions = Array
            .ConvertAll<NPC, Vector3>(FindObjectsOfType<NPC>(), (npc) => npc.gameObject.transform.position);
        // Sort NPCs by distance to player
        Array.Sort(npcPositions, (p1, p2) =>
                Vector3.Distance(p1, transform.position).CompareTo(Vector3.Distance(p2, transform.position)));
        if(npcPositions.Length > 0) {
            return (npcPositions[0] - this.transform.position).normalized * THROW_VELOCITY;
        } else {
            throw new Exception("No NPCs in world");
        }
    }

    private void rotateItems() {
        if(itemQueue.Count > 0) {
            Item item = itemQueue.Dequeue();
            itemQueue.Enqueue(item);
            display();
        }
    }

    // Return true if AddItem operation was successful
    public bool AddItem(Item item) {
        if(itemQueue.Count >= 3) return false;
        itemQueue.Enqueue(item);
        display();
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            dropItem();
        }
        if(Input.GetKeyDown(KeyCode.Q)) {
            rotateItems();
        }
    }
}
