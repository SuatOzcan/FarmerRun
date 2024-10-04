using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator playerAnimator;
    public float jumpForce = 15f;
    public float gravityModifier = 1f;
    private bool isOnGround = true;
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
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        //if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
        //if (collision.gameObject.CompareTag("Obstacle")) // Some how it doesn't work.
        //{                                                // It worked when I instantiate with
        //                                                 // Instantiate(obstaclePrefab);
        //                                                 // Still it doesn't work when
        //                                                 // I use Instantiate in InvokeRepeating.
        //    isGameOver = true;
        //    Debug.Log("Game Over!");
        //}
    }

    private void OnTriggerEnter(Collider other) // I.ve written this to work with
                                                // the longer Instantiate declaration.
    {
        if (other.gameObject.CompareTag("Obstacle")) // Some how it doesn't work.
        {
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            isGameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
