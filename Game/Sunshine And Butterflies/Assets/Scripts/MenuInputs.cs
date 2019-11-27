using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputs : MonoBehaviour
{
    [SerializeField] private NewPlayerScript player1 = null;
    [SerializeField] private NewPlayerScript player2 = null;

    private Vector2 moveInput;
    [SerializeField]private GameObject pauseMenuUI;
    private PlayerInput playerInput = null;
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        pauseMenuUI.SetActive(false);
    }

    public void OnAccept()
    {

    }

    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }

    public void OnBack()
    {
        //pauseMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        //playerInput.SwitchCurrentActionMap("Gameplay");
    }

    public void OnStart()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;


    }

    public void PauseResume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        playerInput.SwitchCurrentActionMap("Gameplay");

    }
}
