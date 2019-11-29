using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPickUp : Interactable
{
    [SerializeField] private float horizontalYeetForce = 300.0f;
    [SerializeField] private float verticalYeetForce = 40.0f;
    [SerializeField] private Vector3 offsetVector = Vector3.zero;
    [SerializeField] private Transform respawnPoint = null;
    [SerializeField] private bool showTrajectory = false;
    [SerializeField] private float animationDuration = 0.0f;

    private Rigidbody rb;
    private RenderPath rp;
    private bool isPickedUp;
    private GameObject currentHolder;
    private BoxCollider[] colliders;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        colliders = GetComponentsInChildren<BoxCollider>();
        if(showTrajectory == true)
        {
            rp = GetComponent<RenderPath>();
        }
    }

    private void Update()
    {
        if (isPickedUp == true)
        {
            rb.MovePosition(currentHolder.transform.position + currentHolder.transform.localRotation * offsetVector);
            transform.rotation = currentHolder.transform.rotation;
            
        }
    }

    public override void Interact(GameObject player)
    {
        if(isPickedUp == false)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.useGravity = false;
            transform.position += Vector3.up;
            isPickedUp = true;
            currentHolder = player;
            //GetComponent<BoxCollider>().enabled = false;
            //GetComponentInChildren<BoxCollider>().enabled = false;
            foreach(BoxCollider box in colliders)
            {
                box.enabled = false;
            }
            player.GetComponent<NewPlayerScript>().PickUpObject(gameObject, animationDuration);
            if(showTrajectory == true)
            {
                rp.SwapLifted();
            }

        }
        else if(player == currentHolder)
        {
            Drop();
            player.GetComponent<NewPlayerScript>().DropObject();
        }
    }

    public void Drop()
    {
        currentHolder.GetComponent<NewPlayerScript>().DropObject();
        transform.position = currentHolder.transform.position + currentHolder.transform.forward * 0.5f + currentHolder.transform.up * 0.3f;
        currentHolder = null;
        isPickedUp = false;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
        //GetComponent<BoxCollider>().enabled = true;
        //GetComponentInChildren<BoxCollider>().enabled = true;
        foreach (BoxCollider box in colliders)
        {
            box.enabled = true;
        }
        LineDisplay();
    }

    public override void Toss()
    {
        currentHolder.GetComponent<NewPlayerScript>().DropObject();
        rb.AddForce((currentHolder.transform.rotation * Vector3.forward * horizontalYeetForce) + (Vector3.up * verticalYeetForce));
        isPickedUp = false;
        rb.useGravity = true;
        currentHolder = null;
        rb.constraints = RigidbodyConstraints.None;
        //GetComponent<BoxCollider>().enabled = true;
        //GetComponentInChildren<BoxCollider>().enabled = true;
        foreach (BoxCollider box in colliders)
        {
            box.enabled = true;
        }
        LineDisplay();

    }

    public override void Teleport()
    {
        if(currentHolder != null)
        {
            currentHolder.GetComponent<NewPlayerScript>().DropObject();
            currentHolder = null;

        }
            isPickedUp = false;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;


    }

    public void Respawn()
    {
        if(respawnPoint != null)
        { 
            rb.velocity = Vector3.zero;
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation * Quaternion.Euler(0, 90, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LineDisplay()
    {
        if (showTrajectory == true)
        {
            rp.SwapLifted();
        }
    }
}
