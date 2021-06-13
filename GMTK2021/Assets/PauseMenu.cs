using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour, GMTKControls.IPauseMenuActions
{
    public GameObject pauseMenuUI;

    public bool isPaused = false;

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
           Pause();
        }

        if (isPaused)
        {
           Resume();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("laodgin menu");
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
