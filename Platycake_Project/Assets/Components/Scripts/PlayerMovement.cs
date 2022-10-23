using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 500f;
    private Rigidbody rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(x, rb.velocity.y, z) * speed * Time.deltaTime;
       
       //animation handler
        if (x != 0 || z !=0) {
             animator.SetBool("isWalking",true);
        }
        else{
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
