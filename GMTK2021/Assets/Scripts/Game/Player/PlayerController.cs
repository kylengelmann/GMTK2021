using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, GMTKControls.IGameplayActions
{
    GMTKControls controls;

    public PlayerCharacter playerCharacter { get; private set; }

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();

        controls = new GMTKControls();
        controls.Gameplay.SetCallbacks(this);

        GameManager.currentLevel.OnLevelStart += OnLevelStart;
        GameManager.currentLevel.OnLevelEnd += OnLevelEnd;
    }

    void OnDestroy()
    {
        GameManager.currentLevel.OnLevelStart -= OnLevelStart;
        GameManager.currentLevel.OnLevelEnd -= OnLevelEnd;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        Vector3 moveInputWorld = Camera.main.transform.forward * moveInput.y + Camera.main.transform.right * moveInput.x;

        playerCharacter.SetMoveInput(moveInputWorld);
    }

    public void OnLook(InputAction.CallbackContext context)
    {

    }

    void OnLevelStart()
    {
        controls.Gameplay.Enable();
    }

    void OnLevelEnd()
    {
        controls.Gameplay.Disable();
    }
}
