using UnityEngine;

// Prevents multiple of this type from spawning and provides a static reference to the spawned instance
abstract public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    protected bool bIsSingletonInstance { get; private set; }

    protected virtual void Awake()
    {
        if(Instance != null)
        {
            if(Instance == this)
            {
                return;
            }
            else
            {
                bIsSingletonInstance = false;
                Destroy(this);
                return;
            }
        }

        Instance = (T)this;
        bIsSingletonInstance = true;
    }
}
