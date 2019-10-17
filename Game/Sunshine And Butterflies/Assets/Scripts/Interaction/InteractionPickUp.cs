using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPickUp : Interactable
{

    private Rigidbody rgb;
    private bool isPickedUp;
    private GameObject currentHolder;

    void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    public override void Interact(GameObject player)
    {
        if(isPickedUp == false)
        {

            rgb.useGravity = false;
            rgb.isKinematic = true;
            transform.position += Vector3.up;
            transform.parent = player.transform;
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
        rgb.isKinematic = false;
        transform.parent = null;
    }
}
