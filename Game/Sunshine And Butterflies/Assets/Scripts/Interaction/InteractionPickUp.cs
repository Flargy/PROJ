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

    private Rigidbody rb;
    private RenderPath rp;
    private bool isPickedUp;
    private GameObject currentHolder;
    public float holdDistance = 0.5f;
    public float holdOffset = 1.0f;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(showTrajectory == true)
        {
            rp = GetComponent<RenderPath>();
        }
    }

    private void Update()
    {
        if (isPickedUp == true)
        {
            rb.MovePosition(currentHolder.transform.position + offsetVector);
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
            player.GetComponent<NewPlayerScript>().PickUpObject(gameObject);
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
        rb.AddForce((currentHolder.transform.rotation * Vector3.forward * horizontalYeetForce / 3) + (Vector3.up * verticalYeetForce / 3));
        currentHolder = null;
        isPickedUp = false;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
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
