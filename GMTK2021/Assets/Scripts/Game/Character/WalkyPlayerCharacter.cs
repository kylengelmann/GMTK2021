using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkyPlayerCharacter : PlayerCharacter
{
    public float maxSpeed = 8f;
    public float WalkForceFalloffStartSpeed = 5f;
    public float WalkForce = 30f;

    protected override void UpdateMovement(float deltaTime)
    {
        float moveInputX = moveInput.x;
        float moveAxisMagnitude = moveInputX;

        Vector3 moveAxisDirection = moveInputX > 0f ? Vector3.right : Vector3.left;

        moveAxisMagnitude = Mathf.Abs(moveAxisMagnitude);
        moveAxisMagnitude = Mathf.Min(moveAxisMagnitude, 1f);

        float currentSpeed = Vector3.Dot(characterRigidbody.velocity, moveAxisDirection);
        float forceSpeedFalloff = (maxSpeed*moveAxisMagnitude - WalkForceFalloffStartSpeed) > Mathf.Epsilon ? Mathf.Clamp01((currentSpeed - WalkForceFalloffStartSpeed) / (maxSpeed*moveAxisMagnitude - WalkForceFalloffStartSpeed)) : 1f;

        float forceMagnitude = Mathf.Lerp(WalkForce, 0f, forceSpeedFalloff);

        characterRigidbody.AddForce(moveAxisDirection *forceMagnitude, ForceMode.Acceleration);
    }

    protected override void Collidable(bool collidable)
    {
        Physics.IgnoreLayerCollision(6, 9, !collidable);
    }
}
