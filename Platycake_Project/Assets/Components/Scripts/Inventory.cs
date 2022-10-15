using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public struct Item {
        bool isIngredient;
        public Sprite sprite;

        public Item(bool isIngredient, Sprite sprite) {
            this.isIngredient = isIngredient;
            this.sprite = sprite;
        }
    }

    public Queue<Item> itemQueue = new Queue<Item>();
    public List<Sprite> sprites;

    public GameObject inventoryItem;
    public GameObject worldItem;

    // Start is called before the first frame update
    void Start()
    {
        itemQueue.Enqueue(new Item(true, this.sprites[0]));
        itemQueue.Enqueue(new Item(true, this.sprites[1]));
        itemQueue.Enqueue(new Item(true, this.sprites[0]));
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
            itemObject.transform.position = this.transform.position;
            itemObject.GetComponent<Rigidbody>().velocity = new Vector3(2f, 0f, 0f);
            display();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            dropItem();
        }
    }
}
