using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private float speed = 500f;
    private Rigidbody rb;
    public Animator animator;
    public bool canFish = false;
    public bool canTree = false;
    [SerializeField] private Inventory.Item fish;
    [SerializeField] private Inventory.Item wing;
    public GameObject worldItem;

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
       
       //animation handler
        if (x != 0 || z !=0) {
            audioSource.volume = 1.0f;
             animator.SetBool("isWalking",true);
        }
        else{
            audioSource.volume = 0f;
            animator.SetBool("isWalking",false);
        }
        
        if(Input.GetKeyDown("e")){
            animator.SetBool("isThrowing",true);
        }
         if(Input.GetKeyUp("e")){
            animator.SetBool("isThrowing",false);
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
            if (canTree)
            {
                dropWing();
            }
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
        GameObject itemObject = Instantiate(worldItem) as GameObject;
        itemObject.GetComponent<SpriteRenderer>().sprite = wing.sprite;

        WorldItem worldItemScript = itemObject.GetComponent<WorldItem>();
        wing.fromPlayer = false;
        worldItemScript.SetItem(wing);

        itemObject.transform.position = this.transform.position + Vector3.up * 6;
    }
}
