using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    protected Rigidbody characterRigidbody { get; private set; }

    protected Vector3 moveInput { get; private set; }

    public ShipController currentStation;
    public bool usingStation;

    protected Vector3 velocity;

    public PlayerController playerController;

    public List<GameObject> heads;

    protected virtual void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        int numHeads = heads.Count;
        heads[Random.Range(0, numHeads)].SetActive(true);
    }

    private void FixedUpdate()
    {
        if (!usingStation)
        {
            UpdateMovement(Time.fixedDeltaTime);
            Collidable(true);
            characterRigidbody.isKinematic = false;
        }
        if (usingStation)
        {
            characterRigidbody.isKinematic = true;
            Collidable(false);
        }
    }

    protected virtual void UpdateMovement(float deltaTime) { }
    protected virtual void Collidable(bool collidable) { }

    public void SetMoveInput(in Vector3 inMoveInput)
    {
        moveInput = inMoveInput;
    }

    public void OnInteract()
    {
        usingStation = !usingStation && currentStation;
        if (currentStation)
        {
            currentStation.setPlayerUsing(usingStation);
         }
    }
}
