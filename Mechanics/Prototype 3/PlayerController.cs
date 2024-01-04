using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float jumpForce = 30f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        //if && condition to prevent spamming jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        }
    }
    
    //if else to check the tag of the obj player comes into contact with, if its an obstacle then game over
    private void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.CompareTag("Ground")) {
        isOnGround = true;
       } else if (collision.gameObject.CompareTag("Obstacle")) {
        gameOver = true;
        Debug.Log("Game Over!");
       }
    }
}
