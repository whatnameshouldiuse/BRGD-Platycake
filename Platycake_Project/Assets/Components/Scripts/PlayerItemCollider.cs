using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollider : MonoBehaviour
{
    public Inventory inventory;

    void OnTriggerEnter(Collider collider) {
        // Check if the gameObject of the collider is an item
        if(collider.gameObject.layer == LayerMask.NameToLayer("Item")) {
            WorldItem worldItem = collider.gameObject.GetComponent<WorldItem>();
            if(this.inventory.AddItem(worldItem.GetItem())) {
                // Destroy item gameObject if it has successfully been added to the inventory.
                Destroy(collider.gameObject);
            }
        }
    }
}
