using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionPlayer : Interactable
{
    [SerializeField] private GameObject otherPlayer = null;
    [SerializeField] private float horizontalYeetForce = 300.0f;
    [SerializeField] private float verticalYeetForce = 40.0f;
    [SerializeField] private Vector3 offsetVector = Vector3.zero;
    [SerializeField] private float inputPickupDelay = 3.0f;
    [SerializeField] private float animationDuration = 1.0f;

    private NewPlayerScript thisPlayer;
    
    private Rigidbody rb = null;
    private bool isLifted = false;
    private PlayerInput playerInput = null;
    private Coroutine breakFree = null;
    private bool noMovementAllowed = true; 
    private Collider[] colliders;//Eku

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        colliders = GetComponents<Collider>();//Eku
        Debug.Log(colliders);
        thisPlayer = GetComponent<NewPlayerScript>();
    }

    private void Update()
    {
        if (isLifted)
        {
            rb.MovePosition(otherPlayer.transform.position + otherPlayer.transform.localRotation * offsetVector);
            transform.rotation = otherPlayer.transform.rotation;
        }
    }

    public override void Interact(GameObject player)
    {
         if(thisPlayer.CanBeLifted() == true && isLifted == false)
        {
            thisPlayer.BecomeLifted();
            rb.velocity = Vector3.zero;
            isLifted = true;
            rb.useGravity = false;
            otherPlayer.GetComponent<NewPlayerScript>().PickUpObject(gameObject, animationDuration);
            //foreach (Collider col in colliders)
            //{
            //    col.enabled = false;//Eku
            //}
            playerInput.SwitchCurrentActionMap("BreakingFree");
            breakFree = StartCoroutine(BreakFreeDelay());
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
        //foreach (Collider col in colliders)
        //{
        //    col.enabled = true;//Eku
        //}
        playerInput.SwitchCurrentActionMap("Gameplay");
        noMovementAllowed = true;
    }

    public void GetPutDown()
    {
        thisPlayer.Released();
        isLifted = false;
        rb.useGravity = true;
        otherPlayer.GetComponent<NewPlayerScript>().DropObject();
        //foreach (Collider col in colliders)
        //{
        //    col.enabled = true;//Eku
        //}
        playerInput.SwitchCurrentActionMap("Gameplay");
        noMovementAllowed = true;

    }

    public void OnBreakFree()
    {
        if (noMovementAllowed == false)
        {
            GetPutDown();
            noMovementAllowed = true;
        }
    }

    private IEnumerator BreakFreeDelay()
    {
        yield return new WaitForSeconds(inputPickupDelay);
        noMovementAllowed = false;
    }
}
