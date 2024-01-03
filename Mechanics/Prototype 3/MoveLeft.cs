using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private float leftBound = -15;
    // used to reference another script (PlayerController)
    private PlayerController playerControllerScript;
    void Start()
    {
        // used to communicate another script (PlayerController), find GameObject Player and get its component PlayerController script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //if the game is not over, everthing keeps moving
        if (playerControllerScript.gameOver == false){
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject); 
        }
    }
}
