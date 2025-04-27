using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressManager : MonoBehaviour, IDataPersistence
{
    public int currentLevel = 1;
    public int unlockedLevels = 1;

    public void LoadData(GameData data)
    {
        this.currentLevel = data.currentLevel;
        this.unlockedLevels = data.unlockedLevels;
    }

    public void SaveData(ref GameData data)
    {
        data.currentLevel = this.currentLevel;
        data.unlockedLevels = this.unlockedLevels;
    }

    public void UnlockNextLevel()
    {
        if (currentLevel >= unlockedLevels)
        {
            unlockedLevels = currentLevel + 1;
        }
    }
}
