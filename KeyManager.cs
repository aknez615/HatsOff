using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace teamFourFinalProject
{
    public class KeyManager : MonoBehaviour, IDataPersistence
    {
        public static KeyManager instance;
        public List<string> collectedKeys = new List<string>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddKey(string keyID)
        {
            if (!collectedKeys.Contains(keyID))
            {
                collectedKeys.Add(keyID);
                Debug.Log($"Collected key: {keyID}");
            }
            else
            {
                Debug.Log($"Key {keyID} is already collected.");
            }
        }

        public bool HasKey(string keyID)
        {
            return collectedKeys.Contains(keyID);
        }

        public void ResetKeys()
        {
            collectedKeys.Clear();
            Debug.Log("KeyManager reset - keys cleared");
        }

        public void SaveData(ref GameData data)
        {
            data.keysCollected.Clear();
            data.keysCollected.AddRange(collectedKeys); 
        }

        public void LoadData(GameData data)
        {
            collectedKeys.Clear();
            if (data != null && data.keysCollected != null)
            {
                collectedKeys.AddRange(data.keysCollected);
            }
        }
    }
}