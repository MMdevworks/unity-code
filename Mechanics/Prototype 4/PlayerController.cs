using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    public float speed = 1.0f;
    public bool hasPowerup;
    private float powerUpStrength = 30.0f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        //set position of indicator on player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Powerup")){
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            //starts PowerupCoundownRoutine
            StartCoroutine(PowerupCoundownRoutine());
        }
    }

    //Ienumerator - interface.
    IEnumerator PowerupCoundownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision){

        if(collision.gameObject.CompareTag("Enemy") && hasPowerup){
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            //send enemy away from player
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + " and powerup set to: " + hasPowerup );
        }
    }
}
