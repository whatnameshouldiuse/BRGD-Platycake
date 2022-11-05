using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    private Inventory.Item item;
    private float cooldown;

    public void SetItem(Inventory.Item item) {
        this.item = item;
    }

    public Inventory.Item GetItem() {
        return this.item;
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
