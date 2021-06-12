using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class WalkyPlayerCharacter : PlayerCharacter
{
    CharacterController characterController;

    float minGroundNormalY;

    GameObject Ground;

    bool bIsGrounded;

    Vector3 groundNormal = Vector3.up;

    [System.Serializable]
    public struct MovementParams
    {
        public float Speed;

        public float WalkingAcceleration;

        public float BrakingAcceleration;

        public float AirControl;
    }

    public MovementParams moveParams = new MovementParams() { Speed = 8f, WalkingAcceleration = 10f, BrakingAcceleration = 15f };

    protected override void Start()
    {
        base.Start();

        characterController = GetComponent<CharacterController>();
        minGroundNormalY = Mathf.Sin(Mathf.Deg2Rad * characterController.slopeLimit);
    }

    protected override void UpdateMovement(float deltaTime)
    {
        float moveAxisMagnitude = moveInput.magnitude;

        Vector3 moveAxisDirection = Mathf.Approximately(moveAxisMagnitude, 0f) ? velocity.normalized : moveInput / moveAxisMagnitude;

        moveAxisMagnitude = Mathf.Min(moveAxisMagnitude, 1f);

        Vector3 perpendicularDirection = Vector3.Cross(moveAxisDirection, Vector3.up);

        Vector3 moveDirection = Vector3.Cross(groundNormal, perpendicularDirection);

        float goalSpeed = moveAxisMagnitude * moveParams.Speed;

        float parallelSpeed = Vector3.Dot(moveDirection, velocity);

        float perpendicularSpeed = Vector3.Dot(perpendicularDirection, velocity);

        float parallelAcceleration = 0f;
        if (goalSpeed * parallelSpeed < -Mathf.Epsilon)
        {
            // pivoting
            parallelAcceleration = moveParams.BrakingAcceleration;
        }
        else if (goalSpeed < Mathf.Abs(parallelSpeed))
        {
            // braking
            parallelAcceleration = -Mathf.Sign(parallelSpeed) * moveParams.BrakingAcceleration;
        }
        else if (goalSpeed > Mathf.Abs(parallelSpeed))
        {
            // speeding up
            parallelAcceleration = moveParams.WalkingAcceleration;
        }

        if (!Mathf.Approximately(parallelAcceleration, 0f))
        {
            float maxDeltaParallelSpeed = goalSpeed - parallelSpeed;

            float deltaParallelSpeed = parallelAcceleration * deltaTime;

            // prevent overshoot
            if (Mathf.Approximately(Mathf.Sign(maxDeltaParallelSpeed), Mathf.Sign(deltaParallelSpeed)) &&
                Mathf.Abs(deltaParallelSpeed) > Mathf.Abs(maxDeltaParallelSpeed))
            {
                deltaParallelSpeed = maxDeltaParallelSpeed;
            }

            parallelSpeed += deltaParallelSpeed;
        }

        float perpendicularAcceleration = -Mathf.Sign(perpendicularSpeed) * moveParams.BrakingAcceleration;
        if (!Mathf.Approximately(perpendicularAcceleration, 0f))
        {
            float maxDeltaPerpendicularSpeed = -perpendicularSpeed;
            float deltaPerpendicularSpeed = perpendicularAcceleration * deltaTime;

            // prevent overshoot
            if (Mathf.Abs(maxDeltaPerpendicularSpeed) < Mathf.Abs(deltaPerpendicularSpeed))
            {
                deltaPerpendicularSpeed = maxDeltaPerpendicularSpeed;
            }

            perpendicularSpeed += deltaPerpendicularSpeed;
        }

        float gravity = Vector3.Dot(Physics.gravity, groundNormal);
        float fallingSpeed = Vector3.Dot(groundNormal, velocity);

        fallingSpeed += gravity * deltaTime;

        velocity = parallelSpeed * moveDirection + perpendicularSpeed * perpendicularDirection + fallingSpeed * groundNormal;

        Vector3 deltaPos = velocity * deltaTime;
        deltaPos.z = -transform.position.z; // Lock players to 0 in the z (forwards) axis

        Ground = null;
        bIsGrounded = false;
        groundNormal = Vector3.up;

        if(usingStation)
        {
            deltaPos = Vector2.zero;
            velocity = Vector2.zero;
        }

        characterController.Move(deltaPos);
    }

    protected override void Collidable(bool collidable)
    {
        Physics.IgnoreLayerCollision(6, 9, !collidable);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        velocity = Vector3.ProjectOnPlane(velocity, hit.normal);

        if (hit.normal.y >= minGroundNormalY)
        {
            Ground = hit.gameObject;
            groundNormal = hit.normal;
            bIsGrounded = true;
        }
    }
}
