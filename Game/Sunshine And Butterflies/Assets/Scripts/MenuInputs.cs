using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuInputs : MonoBehaviour
{
    //public Toggle trueNorthToggle;
    //[SerializeField] private NewPlayerScript player1 = null;
    //[SerializeField] private NewPlayerScript player2 = null;
    private Vector2 moveInput;
    [SerializeField] private GameObject pauseMenuUI;
    private PlayerInput playerInput = null;
    private EventSystem es = null;
    private Button btn = null;

    public static bool isGamePaused = false;
    // private static NewPlayerScript Player;

    //public static MenuInputs Instance;

    //private void Awake()
    //{
    //    Instance = this;
    //}

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

    //public void OnStartFromNewPlayerScript(NewPlayerScript player)
    //{
    //    pauseMenuUI.SetActive(true);
    //    btn = GameObject.Find("ResumeButton").GetComponent<Button>();
    //    es = GameObject.Find("PauseMenuEventSystem").GetComponent<EventSystem>();
    //    es.SetSelectedGameObject(btn.gameObject);
    //    //playerInput.SwitchCurrentActionMap("Menu");
    //    Time.timeScale = 0f;
    //    isGamePaused = true;

    //    Player = player;
    //    if (trueNorthToggle != null)
    //        trueNorthToggle.isOn = Player.UsingScreenNorth;
    //}

    public void PauseResume()
    {
        pauseMenuUI.SetActive(false);
        es.SetSelectedGameObject(null);
        Time.timeScale = 1f;
        var allPlayerÏnputComponents = FindObjectsOfType<PlayerInput>();
        foreach (var p in allPlayerÏnputComponents)
            p.SwitchCurrentActionMap("Gameplay");

        //playerInput.SwitchCurrentActionMap("Gameplay");
        isGamePaused = false;

    }

    public void OptionsButtonBackSelection()
    {
        btn = GameObject.Find("BackButton").GetComponent<Button>();
        es = GameObject.Find("PauseMenuEventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(btn.gameObject);
    }
    
    public void MainMenuOptionsBackSelection()
    {
        btn = GameObject.Find("BackButton").GetComponent<Button>();
        es = GameObject.Find("MainMenuEventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(btn.gameObject);
    }

    public void ResumeButtonSelection()
    {
        btn = GameObject.Find("ResumeButton").GetComponent<Button>();
        es = GameObject.Find("PauseMenuEventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(btn.gameObject);
    }

    public void MainMenuPlayButtonSelection()
    {
        btn = GameObject.Find("PlayButton").GetComponent<Button>();
        es = GameObject.Find("MainMenuEventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(btn.gameObject);
    }

    //public void ToggleHandler(bool value)
    //{
    //    Player.SetTrueNorth(value);
    //}

    /*
     * -------------------
     * MAIN MENU FUNCTIONS 
     * --------------------
     * --------------------
     */

    public void PlayButton()
    {
        SceneManager.LoadScene("Level_1_1");

    }


    public void QuitBUtton()
    {
        Application.Quit();
    }
}
