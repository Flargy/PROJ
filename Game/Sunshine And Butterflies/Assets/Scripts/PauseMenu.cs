using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

    }
    public void SwapToPause()
    {
        playerInput.SwitchCurrentActionMap("Menu");

    }

    public void SwapToGamePlay()
    {
        playerInput.SwitchCurrentActionMap("GamePlay");

    }

    public void OnResume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
        SwapToGamePlay();
    }

    public void OnPause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        SwapToPause();
    }


}
