using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    public List<GameObject> asteroidPrefabs;

    public float minSpawnFreq;
    public float maxSpawnFreq;
    public float nextSpawnTime;



    public float spawnRadius = 35f;

    public Vector2 spawnLocation;

    public void spawn()
    {
        //spawn at circumference at spawnRadius
        int numAsteroidPrefabs = asteroidPrefabs.Count;

        spawnLocation = Random.insideUnitCircle.normalized* spawnRadius;
        Vector3 realSpawnLocation = new Vector3(spawnLocation.x, spawnLocation.y, 0f);
        Quaternion zeroRot = Quaternion.identity;
        Instantiate(asteroidPrefabs[Random.Range(0, numAsteroidPrefabs)], realSpawnLocation, zeroRot);
        nextSpawnTime = Random.Range(minSpawnFreq, maxSpawnFreq) + Time.time;
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
