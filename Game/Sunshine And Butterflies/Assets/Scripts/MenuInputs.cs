using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuInputs : MonoBehaviour
{
    //[SerializeField] private NewPlayerScript player1 = null;
    //[SerializeField] private NewPlayerScript player2 = null;
    private Vector2 moveInput;
    [SerializeField]private GameObject pauseMenuUI;
    private PlayerInput playerInput = null;
    private EventSystem es = null;
    private Button btn = null;

    public static bool isGamePaused = false;
    
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        //pauseMenuUI.SetActive(false);
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
        btn = GameObject.Find("ResumeButton").GetComponent<Button>();
        es = GameObject.Find("PauseMenuEventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(btn.gameObject);
        playerInput.SwitchCurrentActionMap("Menu");
        Time.timeScale = 0f;
        isGamePaused = true;


    }

    public void PauseResume()
    {
        pauseMenuUI.SetActive(false);
        es.SetSelectedGameObject(null);
        Time.timeScale = 1f;
        playerInput.SwitchCurrentActionMap("Gameplay");
        isGamePaused = false;

    }

    public void OptionsButtonBackSelection()
    {
        btn = GameObject.Find("BackButton").GetComponent<Button>();
        es = GameObject.Find("PauseMenuEventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(btn.gameObject);
    }

    public void ResumeButtonSelection()
    {
        btn = GameObject.Find("ResumeButton").GetComponent<Button>();
        es = GameObject.Find("PauseMenuEventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(btn.gameObject);
    }
}
