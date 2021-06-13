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
            other.gameObject.GetComponent<WalkyPlayerCharacter>().stationImUsing = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<WalkyPlayerCharacter>())
        {
            other.gameObject.GetComponent<WalkyPlayerCharacter>().currentStation = null;
            other.gameObject.GetComponent<WalkyPlayerCharacter>().stationImUsing = 0;
        }
    }

    public Cinemachine.CinemachineSmoothPath TetherTrack;

    public float TetherSpeed = 0f;

    float TetherPos = 0f;

    private void Update()
    {
        float deltaPos = Time.deltaTime * TetherSpeed * tetherMove.x;
        TetherPos += deltaPos;

        TetherPos = TetherTrack.StandardizePathDistance(TetherPos);

        Tether.GetComponent<Tether>().TetherAnchor.transform.position = TetherTrack.EvaluatePositionAtUnit(TetherPos, Cinemachine.CinemachinePathBase.PositionUnits.Distance);
        Vector3 tangent = TetherTrack.EvaluateTangentAtUnit(TetherPos, Cinemachine.CinemachinePathBase.PositionUnits.Distance);

        Vector3 up = Vector3.Cross(Vector3.forward, tangent).normalized;

        Tether.GetComponent<Tether>().TetherAnchor.transform.rotation = Quaternion.LookRotation(Vector3.forward, up);

        MoveTether();

        if(playerUsing)
        {
            GameManager.playerController.OutsidePlayerCharacter.KickOffControls();
        }
    }

    private void FixedUpdate()
    {
        //MoveTether();
    }

    public override void OnMove(InputAction.CallbackContext context)
    {
        tetherMove = context.ReadValue<Vector2>();
    }

    public override void OnInsideInteract(InputAction.CallbackContext context)
    {
        bool interact = context.performed;
    }
    void MoveTether()
    {
        Tether.transform.position = TetherTrack.EvaluatePositionAtUnit(TetherPos, Cinemachine.CinemachinePathBase.PositionUnits.Distance);
    }

}
