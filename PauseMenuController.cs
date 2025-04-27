using System.Collections;
using System.Collections.Generic;
using teamFourFinalProject;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private PauseMenu pauseMenu;

    private void OnEnable()
    {
        inputReader.Pause += TogglePause;
    }

    private void OnDisable()
    {
        inputReader.Pause -= TogglePause;
    }

    private void TogglePause()
    {
        if (PauseMenu.GameIsPaused)
            pauseMenu.Resume();
        else
            pauseMenu.Pause();
    }
}
