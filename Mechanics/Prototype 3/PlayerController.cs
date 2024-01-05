using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //get players rigidbody
    private Rigidbody playerRb;
    //get players animator
    private Animator playerAnim;
    //get explosion particle on player
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 750;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        //if && condition to prevent spamming jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        //Jump_trig is a parameter in the animator
        playerAnim.SetTrigger("Jump_trig");
        dirtParticle.Stop();
        playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    
    //if else to check the tag of the obj player comes into contact with, if its an obstacle then game over
    private void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.CompareTag("Ground")) {
        isOnGround = true;
        dirtParticle.Play();
       } else if (collision.gameObject.CompareTag("Obstacle")) {
        gameOver = true;
        Debug.Log("Game Over!");
        //play explosion particle
        explosionParticle.Play();
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSound, 1.0f);
        //set animator death_b parameter to true, and set death type
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
       }
    }
}
