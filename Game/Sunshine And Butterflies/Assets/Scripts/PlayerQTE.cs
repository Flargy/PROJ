using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerQTE : MonoBehaviour
{
    private InteractionLever currentLever = null;
    private PlayerInput playerInput = null;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

    }

    public void SwapToQTE(InteractionLever lever)
    {
        currentLever = lever;
        playerInput.SwitchCurrentActionMap("QTE");
    }

    public void SwapToMovement()
    {
        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    public void OnLeft()
    {
        currentLever.ReceiveAnswer(1);
    }

    public void OnRight()
    {
        currentLever.ReceiveAnswer(3);
    }

    public void OnUp()
    {
        currentLever.ReceiveAnswer(2);
    }

    public void OnDown()
    {
        currentLever.ReceiveAnswer(0);
    }
}
