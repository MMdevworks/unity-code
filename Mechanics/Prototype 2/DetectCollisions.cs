using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Destroy game objects when they collide with eachother
    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
