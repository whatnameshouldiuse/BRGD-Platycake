using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItemCollider : MonoBehaviour
{
    public Inventory inventory;
    public PlayerMovement playerScript;
    [SerializeField] private Image fishingRodUI;
    [SerializeField] private TextMeshProUGUI fishingText;

    void OnTriggerEnter(Collider collider) {
        // Check if the gameObject of the collider is an item
        if(collider.gameObject.layer == LayerMask.NameToLayer("Item")) {
            WorldItem worldItem = collider.gameObject.GetComponent<WorldItem>();
            if(this.inventory.AddItem(worldItem.GetItem())) {
                // Destroy item gameObject if it has successfully been added to the inventory.
                Destroy(collider.gameObject);
            }
        }
        else if(collider.gameObject.layer == LayerMask.NameToLayer("FishingRod"))
        {
            Destroy(collider.gameObject);
            fishingRodUI.gameObject.SetActive(true);
        }
        else if(collider.gameObject.layer == LayerMask.NameToLayer("Pond"))
        {
            playerScript.canFish = true;
            fishingText.gameObject.SetActive(true);
            if (fishingRodUI.gameObject.activeSelf)
            {
                fishingText.text = "Press F to go fishing!";
            }
            else
            {
                fishingText.text = "You need a fishing rod!";
            }
            IEnumerator coroutine = ShowThenHideText();
            StartCoroutine(coroutine);
        }
        else if (collider.gameObject.layer == LayerMask.NameToLayer("WingTree"))
        {
            playerScript.canTree = true;
            fishingText.gameObject.SetActive(true);
            if (fishingRodUI.gameObject.activeSelf)
            {
                fishingText.text = "Press F to retrieve wing";
            }
            else
            {
                fishingText.text = "You need a fishing rod to reach the wing!";
            }
            IEnumerator coroutine = ShowThenHideText();
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GetComponent<Collider>().gameObject.layer == LayerMask.NameToLayer("Pond"))
        {
            playerScript.canFish = false;
        }
        if (GetComponent<Collider>().gameObject.layer == LayerMask.NameToLayer("WingTree"))
        {
            playerScript.canTree = false;
        }
    }

        private IEnumerator ShowThenHideText()
    {
        yield return new WaitForSeconds(5);
        fishingText.gameObject.SetActive(false);
    }
}
