using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayer : Interactable
{
    [SerializeField] private GameObject otherPlayer;

    private NewPlayerScript thisPlayer;

    private Rigidbody rb = null;
    private bool isLifted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        thisPlayer = GetComponent<NewPlayerScript>();
    }

    private void Update()
    {
        if (isLifted)
        {
            rb.MovePosition(otherPlayer.transform.position + Vector3.up * 3);
        }
    }

    public override void Interact(GameObject player)
    {
         if(thisPlayer.CanBeLifted() == true && isLifted == false)
        {
            isLifted = true;
            rb.useGravity = false;
            otherPlayer.GetComponent<NewPlayerScript>().PickUpObject(gameObject);
            thisPlayer.BecomeLifted();
        }
         else if(isLifted == true)
        {
            isLifted = false;
            rb.useGravity = true;
            thisPlayer.Released();
            GetPutDown();
        }
    }

    public void GetPutDown()
    {
    }
}
