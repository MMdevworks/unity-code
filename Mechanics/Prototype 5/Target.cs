using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public ParticleSystem explosionParticle;
    public int pointValue;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        //get reference to game manager script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //add upward force between 12 and 16
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //add torque to apply rotation randomly in xyz
        targetRb.AddTorque(RandomTorque(),RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //set position of target, random range between -4 and 4 on x, below player view (-2) on y
        transform.position = RandomSpawnPos();
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown() {
        if(gameManager.isGameActive){
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        //call method from game manager script
        gameManager.UpdateScore(pointValue);
        }

    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")){
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
