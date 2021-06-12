using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, GMTKControls.IGameplayActions
{
    GMTKControls controls;

    public WalkyPlayerCharacter InsidePlayerCharacter { get; private set; }

    public FloatyPlayerCharacter OutsidePlayerCharacter { get; private set; }

    public void InitializeCharacters(WalkyPlayerCharacter InsideCharacter, FloatyPlayerCharacter OutsideCharacter)
    {
        InsidePlayerCharacter = InsideCharacter;
        if(InsidePlayerCharacter)
        {
            InsidePlayerCharacter.playerController = this;
        }
        else
        {
            Debug.LogError("Null inside player character");
        }

        OutsidePlayerCharacter = OutsideCharacter;
        if(OutsidePlayerCharacter)
        {
            OutsidePlayerCharacter.playerController = this;
        }
        else
        {
            Debug.LogError("Null outside player character");
        }
    }

    private void Awake()
    {
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

        InsidePlayerCharacter.SetMoveInput(Vector3.right * moveInput.x + Vector3.up * moveInput.y);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton())
        {
            OutsidePlayerCharacter.SetThrust(true);
        }
        else
        {
            OutsidePlayerCharacter.SetThrust(false);
        }
    }

    void OnLevelStart()
    {
        controls.Gameplay.Enable();
    }

    void OnLevelEnd()
    {
        controls.Gameplay.Disable();
    }

    public Vector3 GetMouseLocation()
    {
        Vector3 mouseLocation = new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 0f);

        Debug.Log(mouseLocation);

        Ray mouseRay = Camera.main.ScreenPointToRay(mouseLocation);

        Vector3 mouseLocationWorld = mouseRay.GetPoint(-mouseRay.origin.z / mouseRay.direction.z);

        return mouseLocationWorld;
    }
}
