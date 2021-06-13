using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float speed;

    public float minScale;
    public float maxScale;
    public float scale;

    public float minRot;
    public float maxRot;
    public float rot;
    public Vector3 rotDir;

    public float targetRadius = 14f;
    public Vector2 targetLocation;
    Rigidbody asteroidBody;
    public float timeSpawned;
    public float maxDuration;

    public Vector3 direction;

    private void Start()
    {
        scale = Mathf.Lerp(minScale, maxScale, Random.value);
        speed = Mathf.Lerp(minSpeed, maxSpeed, Random.value);
        rot = Mathf.Lerp(minRot, maxRot, Random.value);
        rotDir = Random.onUnitSphere;

        asteroidBody = GetComponent<Rigidbody>();
        asteroidBody.transform.localScale = new Vector3(scale, scale, scale);

        targetLocation = Random.insideUnitCircle* targetRadius;
        direction = Vector3.Normalize(new Vector3 (targetLocation.x, targetLocation.y, 0) - transform.position);
        asteroidBody.AddForce(direction * speed, ForceMode.Impulse);
        asteroidBody.AddTorque(rotDir * rot, ForceMode.Impulse);
        timeSpawned = Time.time;
    }

    private void Update()
    {
        if (Time.time > timeSpawned + maxDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public void OnShot()
    {
        Destroy(gameObject);
    }
}
