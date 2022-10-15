using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    private Inventory.Item item;
    private Inventory inventory;

    void OnTriggerEnter(Collider collider) {
        if(collider.tag == "Player") {
            if(this.inventory.AddItem(this.item)) {
                Destroy(this.gameObject);
            }
        }
    }

    public void SetItem(Inventory.Item item) {
        this.item = item;
    }

    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
