using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Declare a new array called animalPrefabs
    public GameObject[] animalPrefabs;
    public float spawnRangeX = 20;
    public float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    void Start()
    {   
        // Repeatedly call SpawnRandomAnimal function after a delay and at the given intervals
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void Update()
    {
    // Removed and added to start method so that animals will randomly appear at timed intervals instead of If S key is pressed instatiate SpawnRandomAnimal
        // if (Input.GetKeyDown(KeyCode.S)) {
        //     SpawnRandomAnimal();
        // }
    }
    
    // Randomize the animal index and spawn position Random.Range(x,y,z)
    void SpawnRandomAnimal(){
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos,
        animalPrefabs[animalIndex].transform.rotation);
    }
}
