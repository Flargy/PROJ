using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPickUp : Interactable
{

    private Rigidbody rgb;
    private bool isPickedUp;

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
