using System;
using System.Collections;
using System.Collections.Generic;
using teamFourFinalProject;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour, IDataPersistence
{
    public static SceneManager instance;

    public int currentLevel = 0;
    public int unlockedLevels = 1;

    public List<string> collectedKeyIDs = new List<string>();

    private void OnDisable()
    {
        Debug.Log("");

    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            //Destroy(gameObject);
        }
    }
    public void LoadNextScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < unlockedLevels)
        {
            currentLevel = levelIndex;
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelIndex);
        }

        else
        {
            Debug.Log("level " + levelIndex + " is locked");
        }
    }

    public bool AllKeysCollected()
    {
        return collectedKeyIDs.Count >= 4;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("The game has closed");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("The game has closed");
        }
    }

    public void LoadData(GameData data)
    {
        currentLevel = data.currentLevel;
        unlockedLevels = data.unlockedLevels;
        collectedKeyIDs = new List<string>(data.collectedKeyIDs ?? new List<string>());
    }

    public void SaveData(ref GameData data)
    {
        data.currentLevel = currentLevel;
        data.unlockedLevels = unlockedLevels;
        data.collectedKeyIDs = new List<string>(collectedKeyIDs);
    }

    public void CompleteLevel(KeyData keyData)
    {
        if (keyData != null && !collectedKeyIDs.Contains(keyData.keyID))
        {
            collectedKeyIDs.Add(keyData.keyID);
            Debug.Log("Collected key: " + keyData.keyID);
        }

        LoadLevel("Hub"); // After completing the level, return to the hub
    }
}
