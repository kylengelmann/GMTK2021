using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkyPlayerCharacter : PlayerCharacter
{
    Rigidbody walkyRigidbody;

    public float maxSpeed = 8f;
    public float WalkForceFalloffStartSpeed = 5f;
    public float WalkForce = 30f;

    protected override void Start()
    {
        base.Start();

        walkyRigidbody = GetComponent<Rigidbody>();
    }

    protected override void UpdateMovement(float deltaTime)
    {
        float moveAxisMagnitude = moveInput.magnitude;

        Vector3 moveAxisDirection = Mathf.Approximately(moveAxisMagnitude, 0f) ? walkyRigidbody.velocity : moveInput / moveAxisMagnitude;

        moveAxisMagnitude = Mathf.Min(moveAxisMagnitude, 1f);

        float currentSpeed = Vector3.Dot(walkyRigidbody.velocity, moveAxisDirection);
        float forceSpeedFalloff = (maxSpeed*moveAxisMagnitude - WalkForceFalloffStartSpeed) > Mathf.Epsilon ? Mathf.Clamp01((currentSpeed - WalkForceFalloffStartSpeed) / (maxSpeed*moveAxisMagnitude - WalkForceFalloffStartSpeed)) : 1f;

        float forceMagnitude = Mathf.Lerp(WalkForce, 0f, forceSpeedFalloff);

        Debug.Log(forceMagnitude);

        if (usingStation)
        {
            walkyRigidbody.velocity = Vector3.zero;
            walkyRigidbody.isKinematic = true;
        }
        else
        {
            walkyRigidbody.isKinematic = false;
            walkyRigidbody.AddForce(moveAxisDirection *forceMagnitude, ForceMode.Acceleration);
        }
        

    }

    protected override void Collidable(bool collidable)
    {
        Physics.IgnoreLayerCollision(6, 9, !collidable);
    }
}
