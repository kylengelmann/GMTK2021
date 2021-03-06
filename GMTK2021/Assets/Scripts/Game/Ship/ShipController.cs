using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour, GMTKControls.IGameplayActions
{
    GMTKControls controls;

    public bool playerUsing;

    private void Awake()
    {
        controls = new GMTKControls();
        controls.Gameplay.SetCallbacks(this);
    }

    public virtual void OnMove(InputAction.CallbackContext context)
    {

    }

    public virtual void OnInsideInteract(InputAction.CallbackContext context)
    {

    }

    public virtual void OnClick(InputAction.CallbackContext context)
    {

    }

    public void SetEnabled(bool bNewEnabled)
    {
        GetComponent<Collider>().enabled = bNewEnabled;
        if(!bNewEnabled)
        {
            if(GameManager.playerController.OutsidePlayerCharacter.usedStation == this)
            {
                GameManager.playerController.OutsidePlayerCharacter.KickOffControls();
            }
            else if(GameManager.playerController.InsidePlayerCharacter.usedStation == this)
            {
                GameManager.playerController.InsidePlayerCharacter.KickOffControls();
            }
        }
    }

    public virtual void setPlayerUsing(bool newIsPlayerUsing)
    {
        playerUsing = newIsPlayerUsing;
        if(playerUsing)
        {
            controls.Gameplay.Enable();
        }
        else
        {
            controls.Gameplay.Disable();
        }
    }
    //when player enter trigger, make it so that controls are enabled, when player leaves, disable them
    //define the thing
    //player in trigger, copy the player's input into shipController inputs
    //disable player input, enable shipcontroller input
}
