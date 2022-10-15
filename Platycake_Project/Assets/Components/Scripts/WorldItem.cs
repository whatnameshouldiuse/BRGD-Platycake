using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    private Inventory.Item item;
    private Inventory inventory;
    private float cooldown;

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player" && cooldown == 0) {
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
        cooldown = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
    }
}
