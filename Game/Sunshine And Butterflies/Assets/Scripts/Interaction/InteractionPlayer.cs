using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayer : Interactable
{
    [SerializeField] private GameObject otherPlayer = null;
    [SerializeField] private float horizontalYeetForce = 300.0f;
    [SerializeField] private float verticalYeetForce = 40.0f;

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
            rb.velocity = Vector3.zero;
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

    public override void Toss()
    {
        isLifted = false;
        rb.useGravity = true;
        //thisPlayer.Released();
        rb.AddForce((otherPlayer.transform.rotation * Vector3.forward * horizontalYeetForce) + (Vector3.up * verticalYeetForce));
    }

    public void GetPutDown()
    {
    }
}
