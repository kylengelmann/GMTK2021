using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public float speed;
    public float targetRadius = 14f;
    public Vector2 targetLocation;
    Rigidbody asteroidBody;

    public Vector3 direction;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        targetLocation = Random.insideUnitCircle* targetRadius;
        direction = Vector3.Normalize(new Vector3 (targetLocation.x, targetLocation.y, 0) - transform.position);
        asteroidBody.velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
