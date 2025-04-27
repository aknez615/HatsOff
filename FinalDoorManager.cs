using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorManager : MonoBehaviour
{
    public GameObject lockedDoorVisual;
    public GameObject unlockedDoorVisual;

    private void Start()
    {
        bool unlocked = SceneManager.instance.AllKeysCollected();

        lockedDoorVisual.SetActive(!unlocked);
        unlockedDoorVisual.SetActive(unlocked);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SceneManager.instance.AllKeysCollected())
            {
                SceneManager.instance.LoadLevel("youWin");
            }
            else
            {
                Debug.Log("You need all 4 keys to unlock this door.");
            }
        }
    }
}