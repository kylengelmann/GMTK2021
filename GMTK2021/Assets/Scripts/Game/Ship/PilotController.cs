using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PilotController : ShipController
{
    public Vector2 pilotMove;

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

    public float TetherSpeed = 0f;

    float TetherPos = 0f;

    private void Update()
    {
        MoveTether(Time.deltaTime * TetherSpeed * pilotMove.x);
    }

    public override void OnMove(InputAction.CallbackContext context)
    {
        pilotMove = context.ReadValue<Vector2>();
    }

    public override void OnInsideInteract(InputAction.CallbackContext context)
    {
        bool interact = context.performed;
    }
    void MoveTether(float deltaPos)
    {
        TetherPos += deltaPos;
    }

}
