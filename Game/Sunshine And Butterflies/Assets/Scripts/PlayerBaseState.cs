using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Author: Debatable

public class PlayerBaseState : State
{
    protected float HorizontalDirection { get { return owner.HorizontalDirection; } set { owner.HorizontalDirection = value; } }
    protected float VerticalDirection { get { return owner.VerticalDirection; } set { owner.VerticalDirection = value; } }
    protected LayerMask groundLayer { get { return owner.groundCheckLayer; } }
    protected LayerMask interactionLayer { get { return owner.interactionLayer; } }

    protected PlayerStateMashine owner;
    protected Rigidbody rb;

    protected float moveSpeed = 6.0f;
    protected float airMltiplier = 1.0f;
    protected bool carryingBox;
    protected GameObject carryBox;

    public override void Initialize(StateMachine owner) {
        this.owner = (PlayerStateMashine)owner;

        rb = owner.GetComponent<Rigidbody>();
        
        
    }

    public override void Update()
    {
        ApplyVelocity(); // kommer behövas för carry state
        Interact();
        TurnToFace();
      
    }

    public void TurnToFace()
    {
        Vector3 movementVector = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (movementVector != Vector3.zero)
        {
            owner.transform.rotation = Quaternion.LookRotation(movementVector);
        }
    }

    public void MovementInput() // kommer behövas för carry state
    {
        HorizontalDirection = Input.GetAxisRaw("Horizontal1");
        VerticalDirection = Input.GetAxisRaw("Vertical1");

    }

    public void Interact()
    {
        
        
        RaycastHit ray;
        if (Input.GetButtonDown("Interact1") && carryingBox == false) // placeholder
        {

            if (Physics.Raycast(owner.transform.position, owner.transform.forward, out ray, 2.0f, interactionLayer))
            {
                if (ray.collider.CompareTag("CarryBox"))
                {
                    carryBox = ray.collider.gameObject;
                    Interactable interactionObject = ray.collider.GetComponent<Interactable>();
                    interactionObject.Interact(owner.gameObject);
                    carryingBox = true;

                }
                else
                {
                    Interactable interactionObject = ray.collider.GetComponent<Interactable>();
                    interactionObject.DistanceCheck(owner.transform.position);
                }
            }
        }
        
        else if (carryingBox == true && Input.GetButtonDown("Interact1")) //Ska brytas ut till egen state
        {

            carryBox.GetComponent<InteractionPickUp>().Drop();
            carryingBox = false;
        }
    }

    public void ApplyVelocity()
    {
        rb.velocity = (new Vector3(HorizontalDirection, 0, VerticalDirection) * moveSpeed) + new Vector3(0, rb.velocity.y, 0);
        if (new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude >= 2.51f)
        {
            float yVelocity = rb.velocity.y;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 2.5f);
            rb.velocity = new Vector3(rb.velocity.x, yVelocity, rb.velocity.z);
        }
    }


    public bool GroundCheck()
    {
        if (Physics.Raycast(owner.transform.position, Vector3.down, 0.8f, groundLayer))
        {
            return true;
        }
        return false;
    }


}
