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
        Vector3 PlayerPos = Vector3.zero;
        Quaternion PlayerRot = Quaternion.identity;

        GameObject PlayerSpawn = GameObject.FindWithTag(PlayerStartTag);
        if (PlayerSpawn)
        {
            PlayerPos = PlayerSpawn.transform.position;
            PlayerRot = PlayerSpawn.transform.rotation;
        }
        else
        {
            Debug.LogWarning("Failed to find player start");
        }

        GameManager.SpawnPlayer(PlayerPos, PlayerRot);
    }

    public System.Action OnLevelStart;

    public System.Action OnLevelEnd;
}
