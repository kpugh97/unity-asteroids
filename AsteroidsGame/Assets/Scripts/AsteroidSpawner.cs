using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //array to spawn in different asteroids into game
    public GameObject[] asteroidSpawns;
    float maxTime = 5;
    float minTime = 2;

    private float time;
    private float spawnTime; 

    // Start is called before the first frame update

    void Start()
    {
        SetRandomTime();
        time = minTime;  
    }


    void FixedUpdate()
    {
        //increasing time over time
        time += Time.deltaTime;

        //while the time is less than the spawn time
        while(time > spawnTime)
        {
            GenerateAsters();
        }
    }
    //generates asteroids to game
    void GenerateAsters()
    {
        time = 0;
        int i = Random.Range(0, asteroidSpawns.Length);
        //create a clone of one of the 4 asteroids 
        GameObject asterClone = Instantiate(asteroidSpawns[i]);
        //spawn asteroids at a random position within the radius of a circle
        asterClone.transform.position = Random.insideUnitCircle * 5;
    }

    void SetRandomTime() 
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
