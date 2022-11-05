using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public List<Inventory.Item> itemList = new List<Inventory.Item>();

    // List of items representing the items the holder can hold
    //public List<Inventory.Item> recognizedItems = new List<Inventory.Item>();

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Item")) {
            WorldItem worldItem = collider.gameObject.GetComponent<WorldItem>();
            Inventory.Item item = worldItem.GetItem();
            // Only add the item if it was from the player
            if(item.fromPlayer) {
                itemList.Add(item);
                Destroy(collider.gameObject);
            }
        }
    }
}
