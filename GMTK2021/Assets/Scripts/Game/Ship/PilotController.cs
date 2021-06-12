using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PilotController : ShipController
{
    public Vector2 pilotMove;
    public Rigidbody shipBody;
    public Vector2 force;
    public Vector2 forceDirection;

    public float SpeedInThrustDir;
    public float acceleration = 10f;
    public float maxSpeed = 10f;
    public float maxThrustSpeed = 10f;
    public float ThrustForceFalloffStartSpeed = 5f;


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WalkyPlayerCharacter>())
        {
            other.gameObject.GetComponent<WalkyPlayerCharacter>().currentStation = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<WalkyPlayerCharacter>())
        {
            other.gameObject.GetComponent<WalkyPlayerCharacter>().currentStation = null;
        }
    }

    public override void OnMove(InputAction.CallbackContext context)
    {
        pilotMove = context.ReadValue<Vector2>();
    }

    public override void OnInsideInteract(InputAction.CallbackContext context)
    {
        bool interact = context.performed;
    }

    private void Update()
    {
        UpdateMovement(Time.deltaTime);
    }

    private void UpdateMovement(float deltaTime)
    {

        forceDirection = pilotMove;

        float SpeedInThrustDir = Vector3.Dot(shipBody.velocity, forceDirection);

        float forceSpeedFalloff = Mathf.Clamp01((SpeedInThrustDir - ThrustForceFalloffStartSpeed) / (maxThrustSpeed - ThrustForceFalloffStartSpeed));
       
        Vector3 force = forceDirection * Mathf.Lerp(acceleration, 0, forceSpeedFalloff);

        shipBody.AddForce(force, ForceMode.Acceleration);
    }
}
