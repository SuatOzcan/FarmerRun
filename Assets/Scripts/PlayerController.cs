using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator playerAnimator;
    public float jumpForce = 35f;
    //public float gravityModifier = 1f;
    public bool isOnGround = true;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        //Physics.gravity *= gravityModifier;
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

    // The OnCollisionEnter and OnTriggerEnter methods cannot be called at the same time because
    // the box collider cannot be at the same time a standard one and an isTrigger one.
    // There is a technique, however, to make this work. It goes like this.
    // I put a standard box collider on one object and an isTrigger box collider on the other.
    // This way I make both of them work.

    private void OnCollisionEnter(Collision collision)
    {
        // It works when both the player and the obstacle have Rigidbody component on them.
        // It does not work when the obstacle object does not have a Rigidbody component. Weird.
        //This does not work because on the obstacle IsTrigger option is true.
        // It actually works without a rigidbody on the obstacle when the player touches the fence on air.
        // This has something to do with the AddForce method. When the character is under the effect
        // of a force, this OnCollision method works.
        // Since there is not a rigidbody on the Obstacle, neither is there a force on the player,
        // this OnCollision method does not work.
        // To summarize, the OnCollisionEnter method works when the rigidbody is moving.
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
