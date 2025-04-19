using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator playerAnimator;
    public float jumpForce = 35f;
    public float gravityModifier = 1f;
    public bool isOnGround = true;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // It works when both the player and the obstacle have Rigidbody component on them.
        // It does not work when the obstacle object does not have a Rigidbody component. Weird.
        //This does not work because on the obstacle IsTrigger option is true.
        if (collision.gameObject.CompareTag("Obstacle"))
        {                                                
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            isGameOver = true;
            Debug.Log("Game Over!");
        }

        // This works even when there is not a Rigidbody component on the ground object.
        // Weird.
        if (collision.gameObject.CompareTag("Ground"))
        //if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    //private void OnTriggerEnter(Collider other) 
    //                                            
    //{
    //    if (other.gameObject.CompareTag("Obstacle"))
    //    {
    //        playerAnimator.SetBool("Death_b", true);
    //        playerAnimator.SetInteger("DeathType_int", 1);
    //        isGameOver = true;
    //        Debug.Log("Game Over!");
    //    }

    //    //else if (other.gameObject.CompareTag("Ground")) // This does not work. 
    //    //{
    //    //    isOnGround = true;
    //    //}
    //}
}
