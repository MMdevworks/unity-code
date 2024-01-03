using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 35;
    private float lowerBound = -12;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.z > topBound) {
            Destroy(gameObject);
        } else if (transform.position.z < lowerBound) {
            Destroy(gameObject);
            Debug.Log("GAME OVER");
        }
    }
}
