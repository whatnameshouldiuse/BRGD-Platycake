using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioSource;
    private float speed = 500f;
    private Rigidbody rb;
    public Animator animator;

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
}
