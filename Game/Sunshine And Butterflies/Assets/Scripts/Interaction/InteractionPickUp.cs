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
            //rgb.isKinematic = true;
            transform.position += Vector3.up;
            //rgb.MovePosition(transform.position + transform.forward * holdDistance * Time.deltaTime);
            //transform.parent = player.transform;
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
        isPickedUp = false;
        rb.useGravity = true;
        //rgb.isKinematic = false;
        transform.parent = null;
    }

    public override void Toss()
    {
        isPickedUp = false;
        rb.useGravity = true;
        //thisPlayer.Released();
        rb.AddForce((currentHolder.transform.rotation * Vector3.forward * horizontalYeetForce) + (Vector3.up * verticalYeetForce));
    }
}
