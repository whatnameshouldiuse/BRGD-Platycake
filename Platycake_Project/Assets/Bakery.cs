using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Bakery : MonoBehaviour
{
    [Serializable]
    public struct ItemTrade
    {
        // The item the NPC wants
        public List<Sprite> ingredients;

        // Cake item
        public Inventory.Item have;
    }

    public ItemTrade itemTrade;

    public GameObject canvas;
    public List<string> dialogueList;
    public TextMeshProUGUI dialogueText;
    public List<Image> visualIngredients;

    public GameObject worldItem;

    private Queue<string> dialogueQueue;
    private GameObject player;

    private ItemHolder itemHolder;

    private const double RADIUS = 22f;
    private const float INTERPOLATION = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // Find the player GameObject
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        this.player = players[0];
        this.canvas.transform.localScale = Vector3.zero;

        this.dialogueQueue = new Queue<string>(dialogueList);

        this.itemHolder = this.GetComponent<ItemHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        double currentDistance = Vector3.Distance(this.player.transform.position, this.transform.position);
        bool isWithinDistance = currentDistance <= RADIUS;

        Vector3 targetScale = isWithinDistance ? Vector3.one : Vector3.zero;
        this.canvas.transform.localScale = Vector3.Lerp(canvas.transform.localScale, targetScale, INTERPOLATION);

        if (dialogueQueue.Count > 0)
        {
            if (isWithinDistance && Input.GetKeyDown(KeyCode.Space))
            {
                dialogueQueue.Enqueue(dialogueQueue.Dequeue());
            }
            dialogueText.text = dialogueQueue.Peek();
        }

        checkCurrentItems();
    }

    private void checkCurrentItems()
    {
        foreach (Inventory.Item item in this.itemHolder.itemList)
        {
            if (!itemTrade.ingredients.Contains(item.sprite))
            {
                // The item in the item holder is not an ingredient, so throw it out...
                dropItem(item);
                this.itemHolder.itemList.Remove(item);
            }
            else
            {
                // Color in respective image
                for(int i = 0; i<itemTrade.ingredients.Count; i++)
                {
                    if(itemTrade.ingredients[i] == item.sprite)
                    {
                        visualIngredients[i].color = Color.white;
                    }
                }
            }
        }

        if(this.itemHolder.itemList.Count == itemTrade.ingredients.Count)
        {
            // If you have 5 valid ingredients, drop the cake item
            dropItem(itemTrade.have);
            this.itemHolder.itemList.Clear();
            // Black out all images
            for (int i = 0; i < itemTrade.ingredients.Count; i++)
            {
                visualIngredients[i].color = Color.black;
            }
        }
    }

    private void dropItem(Inventory.Item item)
    {
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
