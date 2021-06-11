using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour, GMTKControls.IMenuActions
{
    GMTKControls controls;
    void Start()
    {
        controls = new GMTKControls();
        controls.Menu.SetCallbacks(this);

        controls.Menu.Enable();
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        bool bPressed = context.ReadValue<float>() > .5f;
        if(bPressed)
        {
            GameManager.LoadLevel(1);

            controls.Menu.Disable();
        }
    }
}
