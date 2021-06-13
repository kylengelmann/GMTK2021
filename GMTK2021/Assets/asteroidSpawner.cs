using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    public List<GameObject> asteroidPrefabs;

    public float minSpawnTime;
    public float maxSpawnTime;
    public float baseSpawnTime;
    public float nextSpawnTime;
    public float difficulty;
    public float maxDiffTime;
    public float maxDifficulty;
    public float diffScale_1;
    public float phase1scale;
    public float diffScale_2;
    public float phase2scale;
    public float diffScale_3;
    public bool diffRise;
    public float endDownScale;
    public float endUpScale;
    public float diffScale;
    public float wobblePeriod;
    public float wobbleTime;
    public float currentDifficulty;
    public int currentPhase;
    public float currentTime;

    //maximum difficulty at ~300?
    //times and a fake sine


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

        //nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime) + Time.time;
        //minSpawnFreq and maxSpawnFreq are dependent on difficulty
        //difficulty is dependent on time

        nextSpawnTime = Time.time + Mathf.Lerp(maxSpawnTime, minSpawnTime, currentDifficulty);
    }

    private void Start()
    {
        diffScale = endDownScale;
        diffRise = false;
        maxDifficulty = maxDiffTime * (diffScale_1 + diffScale_2 + diffScale_3) / 3;
        wobbleTime = maxDiffTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        currentDifficulty = difficulty / maxDifficulty;
        //Mathf.Lerp(0, maxDifficulty, t);

        if (currentTime < maxDiffTime*phase1scale) //phase 1
        {
            difficulty = diffScale_1 * currentTime;
            currentPhase = 1;
        }
        if (currentTime > maxDiffTime * phase1scale && currentTime < maxDiffTime * phase2scale) //phase 2
        {
            difficulty = diffScale_2 * Time.time;
            currentPhase = 2;
        }
        if (currentTime > maxDiffTime * phase2scale && currentTime < maxDiffTime) //phase 3
        {
            difficulty = diffScale_3 * currentTime;
            currentPhase = 3;
        }
        if (currentTime > maxDiffTime) //endgame wobble
        {
            difficulty += diffScale * Time.fixedDeltaTime;

            if (currentTime > wobbleTime)
            {
                wobbleTime = currentTime + wobblePeriod;
            if (diffRise)
            {
                diffScale = endDownScale;
                diffRise = false;
                currentPhase = 4;
            }
            else
            {
                diffScale = endUpScale;
                diffRise = true;
                currentPhase = 5;
            }
            }
        }
    
        if (nextSpawnTime < Time.time)
        {
            spawn();
        }
    }
}
