using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace teamFourFinalProject
{
    public class KeyPickup : MonoBehaviour
    {
        [SerializeField] KeyData keyData;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && keyData != null)
            {
                KeyManager.instance.AddKey(keyData.keyID);
                Debug.Log("Picked up key: " + keyData.keyID);

                if (keyData.keyID != "key0")
                {
                    DataPersistenceManager.instance.SaveGame();
                    Debug.Log("Returning to Hub");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Hub");
                }

                else
                {
                    Destroy(gameObject);
                }

                gameObject.SetActive(false); //Prevent duplicates
            }
        }
    }
}
