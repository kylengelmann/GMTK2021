using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Custom/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int SceneBuildIndex;

    public int[] AdditionalLevels;
}
