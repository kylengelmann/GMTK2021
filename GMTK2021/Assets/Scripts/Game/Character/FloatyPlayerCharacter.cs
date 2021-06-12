using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatyPlayerCharacter : PlayerCharacter
{
    Rigidbody floatyRigidbody;

    public float acceleration = 10f;
    public float thrustDrag = 1f;

    public float maxThrustSpeed = 10f;
    public float ThrustForceFalloffStartSpeed = 5f;
    public float ThrustForceFalloffStartDistance = 1.5f;

    public bool bIsThrusting { get; private set; }
    public Vector3 ThrustLocation { get; private set; }

    protected override void Start()
    {
        base.Start();

        floatyRigidbody = GetComponent<Rigidbody>();
    }

    protected override void UpdateMovement(float deltaTime)
    {
        if(!bIsThrusting)
        {
            return;
        }

        Vector3 forceDirection = playerController.GetMouseLocation() - transform.position;
        forceDirection.z = 0f;

        float distanceFromCursor = forceDirection.magnitude;
        forceDirection = forceDirection / distanceFromCursor;

        float SpeedInThrustDir = Vector3.Dot(floatyRigidbody.velocity, forceDirection);

        float forceSpeedFalloff = Mathf.Clamp01((SpeedInThrustDir - ThrustForceFalloffStartSpeed) / (maxThrustSpeed - ThrustForceFalloffStartSpeed));
        float forceDistanceFalloff = Mathf.Clamp01(ThrustForceFalloffStartDistance - distanceFromCursor);

        Debug.Log(forceDistanceFalloff);

        Vector3 force = forceDirection * Mathf.Lerp(acceleration, 0, forceSpeedFalloff*forceDistanceFalloff);

        floatyRigidbody.AddForce(force, ForceMode.Acceleration);
    }

    public void SetThrust(bool newIsThrusting)
    {
        bIsThrusting = newIsThrusting;
    }
}
