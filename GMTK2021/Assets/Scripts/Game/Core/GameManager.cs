using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public LevelData[] Levels;

    public int DEBUG_LEVEL_TO_LOAD = 0;

    [System.Serializable]
    public struct GameData
    {
        public GameObject PlayerPrefab;
    }

    [SerializeField] private GameData _gameData;

    public static PlayerController playerController { get; private set; }

    public static LevelScript currentLevel { get; private set; }

    private int currentLevelIndex = -1;

    private Queue<int> loadingLevels = new Queue<int>();

    public static bool bIsLoading { get; private set; }

    public static GameData gameData 
    {
        get
        {
            return Instance._gameData;
        }
    }

    protected override void Awake()
    {
        base.Awake();

        if(!bIsSingletonInstance)
        {
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
#if UNITY_EDITOR
        if (SceneManager.sceneCount == 1)
        {
            LoadLevelInternal(DEBUG_LEVEL_TO_LOAD);
        }
        else
        {
            StartCurrentLevel();
        }
#else
        LoadLevelInternal(0);
#endif // DEBUG
    }

    public static void LoadLevel(int LevelIndex)
    {
        Instance.LoadLevelInternal(LevelIndex);
    }

    private void LoadLevelInternal(int LevelIndex)
    {
        if(bIsLoading)
        {
            Debug.LogError("LoadLevelInternal called while levels are still being loaded");
            return;
        }

        if (Levels.Length > LevelIndex && LevelIndex >= 0)
        {
            currentLevelIndex = LevelIndex;

            LevelData levelData = Levels[LevelIndex];
            if (levelData)
            {
                bIsLoading = true;

                AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(levelData.SceneBuildIndex, LoadSceneMode.Single);
                loadSceneOperation.completed += OnLevelLoaded;

                foreach (int level in levelData.AdditionalLevels)
                {
                    loadingLevels.Enqueue(level);
                }
            }
        }
        else
        {
            Debug.LogError("Attempting to load invalid level index " + LevelIndex);
        }
    }

    private void OnLevelLoaded(AsyncOperation loadOperation)
    {
        if(!bIsLoading)
        {
            Debug.LogError("OnLevelLoaded called when no levels are loading");
            return;
        }

        if(loadingLevels.Count == 0)
        {
            bIsLoading = false;
            StartCurrentLevel();
        }
        else
        {
            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(loadingLevels.Dequeue(), LoadSceneMode.Additive);
            loadSceneOperation.completed += OnLevelLoaded;
        }
    }

    private void StartCurrentLevel()
    {
        currentLevel = FindObjectOfType<LevelScript>();
        if(currentLevel)
        {
            currentLevel.StartLevel();
        }
    }

    public static void SpawnPlayer(Vector3 location, Quaternion rotation)
    {
        if (gameData.PlayerPrefab)
        {
            GameObject Player = Instantiate(gameData.PlayerPrefab, location, rotation);

            if(!Player)
            {
                Debug.LogError("Failed to spawn player");
            }

            playerController = Player.GetComponent<PlayerController>();

            if(!playerController)
            {
                Debug.LogError("No player component on spawned player");
            }
        }
        else
        {
            Debug.LogError("Missing player prefab");
        }
    }
}
