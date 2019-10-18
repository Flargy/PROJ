using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPickUp : Interactable
{
    [SerializeField] private float horizontalYeetForce = 300.0f;
    [SerializeField] private float verticalYeetForce = 40.0f;

    private Rigidbody rb;
    private bool isPickedUp;
    private GameObject currentHolder;

    public float holdDistance = 0.5f;
    public float holdOffset = 1.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isPickedUp == true)
        {
            rb.MovePosition(currentHolder.transform.position + currentHolder.transform.up * holdOffset + currentHolder.transform.forward * holdDistance);
            
        }
    }

    public override void Interact(GameObject player)
    {
        if(isPickedUp == false)
        {

            rb.useGravity = false;
            transform.position += Vector3.up;
            isPickedUp = true;
            currentHolder = player;
            player.GetComponent<NewPlayerScript>().PickUpObject(gameObject);

        }
        else
        {
            Drop();
            player.GetComponent<NewPlayerScript>().DropObject();
        }
    }

    public void Drop()
    {
        currentHolder = null;
        isPickedUp = false;
        rb.useGravity = true;
        transform.parent = null;
    }

    public override void Toss()
    {
        currentHolder = null;
        currentHolder.GetComponent<NewPlayerScript>().DropObject();
        isPickedUp = false;
        rb.useGravity = true;
        rb.AddForce((currentHolder.transform.rotation * Vector3.forward * horizontalYeetForce) + (Vector3.up * verticalYeetForce));
    }
}
