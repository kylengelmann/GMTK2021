using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    const string PlayerStartTag = "PlayerSpawn";

    public void StartLevel()
    {
        StartLevelInternal();

        LevelStart();

        if(OnLevelStart != null)
        {
            OnLevelStart();
        }
    }

    protected virtual void LevelStart() { }

    public void EndLevel()
    {
        LevelEnd();

        if (OnLevelEnd != null)
        {
            OnLevelEnd();
        }
    }

    protected virtual void LevelEnd() { }

    private void StartLevelInternal()
    {
        // Spawn the player
        GameObject PlayerSpawn = GameObject.FindWithTag(PlayerStartTag);
        if (PlayerSpawn)
        {
            GameManager.SpawnPlayer(PlayerSpawn);
        }
        else
        {
            Debug.LogWarning("Failed to find player start");
        }
    }

    public System.Action OnLevelStart;

    public System.Action OnLevelEnd;
}
