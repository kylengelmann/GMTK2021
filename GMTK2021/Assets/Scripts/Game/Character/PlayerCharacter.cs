using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{ 
    protected Vector3 moveInput { get; private set; }

    protected Vector3 velocity;

    public PlayerController playerController;

    protected virtual void Start()
    {

    }

    private void Update()
    {
        UpdateMovement(Time.deltaTime);
    }

    protected virtual void UpdateMovement(float deltaTime) { }

    public void SetMoveInput(in Vector3 inMoveInput)
    {
        moveInput = inMoveInput;
    }
}
