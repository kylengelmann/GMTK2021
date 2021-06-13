using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    public GameObject asteroid_1;
    public GameObject asteroid_2;
    public GameObject asteroid_3;

    public float minSpawnFreq;
    public float maxSpawnFreq;
    public float nextSpawnTime;

    public float spawnRadius = 35f;

    public Vector2 spawnLocation;

    public void spawn()
    {
        //spawn at circumference at spawnRadius
        spawnLocation = Random.insideUnitCircle.normalized* spawnRadius;
        Vector3 realSpawnLocation = new Vector3(spawnLocation.x, spawnLocation.y, 0f);
        Quaternion zeroRot = Quaternion.identity;
        Instantiate(asteroid, realSpawnLocation, zeroRot);
        float nextSpawnTime = Random.Range(minSpawnFreq, maxSpawnFreq) + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       if(nextSpawnTime < Time.time)
        {
            spawn();
        }
    }
}
