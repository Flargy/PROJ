using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputs : MonoBehaviour
{

    private Vector2 moveInput;

    public void OnAccept()
    {
        Debug.Log("Input: Accepted");
    }


    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
        Debug.Log("Input: Move");
    }

    public void Onback()
    {
        Debug.Log("Input: Back");
    }
}
