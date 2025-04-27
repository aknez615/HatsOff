using System.Collections;
using System.Collections.Generic;
using teamFourFinalProject;
using UnityEngine;

public class DoorManager : MonoBehaviour, IDataPersistence
{
    public static SceneManager instance;

    public KeyData requiredKey;
    private KeyManager keyManager;

    public GameObject lockedDoorVisual;
    public GameObject unlockedDoorVisual;

    private bool keyOwned = false;


    void Start()
    {
        keyManager = FindObjectOfType<KeyManager>();

        if (keyManager == null)
        {
            Debug.LogError("Key manager not found");
        }
    }

    void Update()
    {
        UpdateDoorVisual();
    }

    public void LoadData(GameData data)
    {
        keyOwned = keyManager.HasKey(requiredKey.keyID);
        
        lockedDoorVisual.SetActive(!keyOwned);
        unlockedDoorVisual.SetActive(keyOwned);
    }

    public void SaveData(ref GameData data) { }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && keyManager != null)
        {
            if (keyManager.HasKey(requiredKey.keyID))
            {
                SceneManager.instance.LoadLevel(requiredKey.levelName);
            }

            else
            {
                Debug.LogWarning($"Player does not have the required key: {requiredKey.keyID}. Current keys: {string.Join(", ", keyManager.collectedKeys)}");
            }
        }
    }

    private void UpdateDoorVisual()
    {
        keyOwned = keyManager.HasKey(requiredKey.keyID);
        lockedDoorVisual.SetActive(!keyOwned);
        unlockedDoorVisual.SetActive(keyOwned);
    }
}
