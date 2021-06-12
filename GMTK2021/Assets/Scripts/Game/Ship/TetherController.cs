using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TetherController : ShipController
{
    public GameObject Tether;
    public Vector2 tetherMove;
    
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

    public Cinemachine.CinemachineSmoothPath TetherTrack;

    public float TetherSpeed = 0f;

    float TetherPos = 0f;

    private void Update()
    {
        MoveTether(Time.deltaTime * TetherSpeed * tetherMove.x);
    }

    public override void OnMove(InputAction.CallbackContext context)
    {
        tetherMove = context.ReadValue<Vector2>();
    }

    public override void OnInsideInteract(InputAction.CallbackContext context)
    {
        bool interact = context.performed;
    }
    void MoveTether(float deltaPos)
    {
        TetherPos += deltaPos;

        TetherPos = TetherTrack.StandardizePathDistance(TetherPos);

        Tether.transform.position = TetherTrack.EvaluatePosition(TetherPos);
        Tether.transform.rotation = TetherTrack.EvaluateOrientation(TetherPos);
    }

}
