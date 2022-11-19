using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private float speed = 500f;
    private Rigidbody rb;
    public Animator animator;
    public bool canFish = false;
    public bool canTree = false;
    private bool droppedWing = false;
    [SerializeField] private Inventory.Item fish;
    [SerializeField] private Inventory.Item wing;
    public GameObject worldItem;
    [SerializeField] private GameObject wingTree;
    [SerializeField] private GameObject winglessTree;
    [SerializeField] private TextMeshProUGUI fishingText;
    [SerializeField] private GameObject platypusSprite;


    // Start is called before the first frame update
    void Start()
    {
        //audioSource.volume = 0f;
        audioSource.Play();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(x, rb.velocity.y, z) * speed * Time.deltaTime;
        if(x < 0)
        {
            platypusSprite.transform.localScale = Vector3.one;
        }
        else if(x > 0)
        {
            platypusSprite.transform.localScale = Vector3.one - 2 * Vector3.right;
        }

        //animation handler
        if (x != 0 || z != 0)
        {
            audioSource.volume = 1.0f;
            animator.SetBool("isWalking", true);
        }
        else
        {
            audioSource.volume = 0f;
            animator.SetBool("isWalking", false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (canFish)
            {
                dropFish();
            }
            if (canTree & !droppedWing)
            {
                dropWing();
                droppedWing = true;
            }
        }
        if (Input.GetKeyDown("e"))
        {
            animator.SetTrigger("throw");
        }
    }

    private void dropFish()
    {
        GameObject itemObject = Instantiate(worldItem) as GameObject;
        itemObject.GetComponent<SpriteRenderer>().sprite = fish.sprite;

        WorldItem worldItemScript = itemObject.GetComponent<WorldItem>();
        fish.fromPlayer = false;
        worldItemScript.SetItem(fish);

        itemObject.transform.position = this.transform.position + Vector3.up*6;
    }

    private void dropWing()
    {
        wingTree.SetActive(false);
        winglessTree.SetActive(true);
        fishingText.gameObject.SetActive(false);
        GameObject itemObject = Instantiate(worldItem) as GameObject;
        itemObject.GetComponent<SpriteRenderer>().sprite = wing.sprite;

        WorldItem worldItemScript = itemObject.GetComponent<WorldItem>();
        wing.fromPlayer = false;
        worldItemScript.SetItem(wing);

        itemObject.transform.position = this.transform.position + Vector3.up * 6;
    }
}
