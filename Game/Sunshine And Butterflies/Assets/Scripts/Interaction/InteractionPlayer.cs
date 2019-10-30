using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionPlayer : Interactable
{
    [SerializeField] private GameObject otherPlayer = null;
    [SerializeField] private float horizontalYeetForce = 300.0f;
    [SerializeField] private float verticalYeetForce = 40.0f;
    [SerializeField] private float verticalOffest = 1.0f;

    private NewPlayerScript thisPlayer;
    
    private Rigidbody rb = null;
    private bool isLifted = false;
    private PlayerInput playerInput = null;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        thisPlayer = GetComponent<NewPlayerScript>();
    }

    private void Update()
    {
        if (isLifted)
        {
            rb.MovePosition(otherPlayer.transform.position + Vector3.up * verticalOffest);
        }
    }

    public override void Interact(GameObject player)
    {
         if(thisPlayer.CanBeLifted() == true && isLifted == false)
        {
            rb.velocity = Vector3.zero;
            isLifted = true;
            rb.useGravity = false;
            otherPlayer.GetComponent<NewPlayerScript>().PickUpObject(gameObject);
            thisPlayer.BecomeLifted();
            playerInput.SwitchCurrentActionMap("BreakingFree");
        }
         else if(isLifted == true)
        {
            GetPutDown();
        }
    }

    public override void Toss()
    {
        isLifted = false;
        rb.useGravity = true;
        thisPlayer.Released();
        otherPlayer.GetComponent<NewPlayerScript>().DropObject();
        rb.AddForce((otherPlayer.transform.rotation * Vector3.forward * horizontalYeetForce) + (Vector3.up * verticalYeetForce));
        playerInput.SwitchCurrentActionMap("Gameplay");
    }

    public void GetPutDown()
    {
        thisPlayer.Released();
        isLifted = false;
        rb.useGravity = true;
        otherPlayer.GetComponent<NewPlayerScript>().DropObject();
        playerInput.SwitchCurrentActionMap("Gameplay");

    }

    public void OnBreakFree()
    {
        GetPutDown();
    }
}
