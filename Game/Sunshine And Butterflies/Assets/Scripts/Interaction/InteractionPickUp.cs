using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPickUp : Interactable
{

    private Rigidbody rgb;
    private bool isPickedUp;
    private GameObject currentHolder;

    public float holdDistance = 0.5f;
    public float holdOffset = 1.0f;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isPickedUp == true)
        {
            rgb.MovePosition(currentHolder.transform.position + currentHolder.transform.up * holdOffset + currentHolder.transform.forward * holdDistance);
            
        }
    }

    public override void Interact(GameObject player)
    {
        if(isPickedUp == false)
        {

            rgb.useGravity = false;
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
        rgb.useGravity = true;
        //rgb.isKinematic = false;
        transform.parent = null;
    }
}
