using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class levelSelect : MonoBehaviour, GMTKControls.IMenuActions
{
    GMTKControls controls;
    public int thisLevel;
    void Start()
    {
        controls = new GMTKControls();
        controls.Menu.SetCallbacks(this);

        controls.Menu.Enable();
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        bool bPressed = context.ReadValue<float>() > .5f;
        if (bPressed)
        {
            GameManager.LoadLevel(thisLevel);

            controls.Menu.Disable();
        }

    }
}
