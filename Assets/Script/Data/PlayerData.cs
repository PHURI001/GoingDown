using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public bool[] LevelUnlock = new bool[3] { true, false, false };

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockLevel(int levelIndex)
    {
        levelIndex -= 1;
        if (levelIndex >= 0 && levelIndex < LevelUnlock.Length)
        {
            LevelUnlock[levelIndex] = true;
        }
    }
}
