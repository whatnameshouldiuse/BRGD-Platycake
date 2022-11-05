using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController myCharacter;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirectionForward = Vector3.forward * verticalInput;
        Vector3 moveDirectionSide = Vector3.right * horizontalInput;

        Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
        Vector3 distance = direction * speed * Time.deltaTime;

        myCharacter.Move(distance);

        //animation handler
        if (horizontalInput != 0 || verticalInput != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown("e"))
        {
            animator.SetBool("isThrowing", true);
        }
        if (Input.GetKeyUp("e"))
        {
            animator.SetBool("isThrowing", false);
        }
    }
}
