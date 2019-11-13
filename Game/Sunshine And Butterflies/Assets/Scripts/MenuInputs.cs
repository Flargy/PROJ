using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputs : MonoBehaviour
{
    private Vector2 moveInput;
    public GameObject pauseMenuUI;
    

    private PlayerInput playerInput = null;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        pauseMenuUI.SetActive(false);
    }

    public void OnAccept()
    {
        Debug.Log("Input: Accepted");
    }


    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
        Debug.Log("Input: Move");
    }

    public void OnBack()
    {
        Debug.Log("Input: Back");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    public void OnStart()
    {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;

    }

    public void OnResume()
    {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            playerInput.SwitchCurrentActionMap("Gameplay");
    }
}
