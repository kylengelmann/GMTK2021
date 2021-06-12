using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherController : ShipController
{
    public GameObject Tether;

    public Cinemachine.CinemachineSmoothPath TetherTrack;

    public float TetherSpeed = 1f;

    float TetherPos = 0f;

    private void Update()
    {
        MoveTether(Time.deltaTime * TetherSpeed);
    }

    void MoveTether(float deltaPos)
    {
        TetherPos += deltaPos;

        TetherPos = TetherTrack.StandardizePathDistance(TetherPos);

        Tether.transform.position = TetherTrack.EvaluatePosition(TetherPos);
        Tether.transform.rotation = TetherTrack.EvaluateOrientation(TetherPos);
    }
}
