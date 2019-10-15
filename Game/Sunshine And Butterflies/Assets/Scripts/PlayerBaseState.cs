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
    protected Rigidbody rgb;

    protected float moveSpeed = 6.0f;
    protected float airMltiplier = 1.0f;

    public override void Initialize(StateMachine owner) {
        this.owner = (PlayerStateMashine)owner;

        rgb = owner.GetComponent<Rigidbody>();
        
        
    }

    public override void Update()
    {
        ApplyVelocity();
        Interact();
      
    }

    public void MovementInput()
    {
        HorizontalDirection = Input.GetAxisRaw("Horizontal1");
        VerticalDirection = Input.GetAxisRaw("Vertical1");

    }

    public void Interact()
    {
        RaycastHit ray;
        if (Input.GetButtonDown("Interact1")) // placeholder
        {

            if(Physics.Raycast(owner.transform.position, owner.transform.forward, out ray, 2.0f, interactionLayer)){
                Interactable interactionObject = ray.collider.GetComponent<Interactable>();
                interactionObject.DistanceCheck(owner.transform.position);
            }
        }
    }

    public void ApplyVelocity()
    {
        rgb.velocity = (new Vector3(HorizontalDirection, 0, VerticalDirection) * moveSpeed) + new Vector3(0, rgb.velocity.y, 0);
        if (rgb.velocity.magnitude >= 2.51f)
        {
            rgb.velocity = Vector3.ClampMagnitude(rgb.velocity, 2.5f);
        }
    }


    public bool GroundCheck()
    {
        if (Physics.Raycast(owner.transform.position, Vector3.down, 0.55f, groundLayer))
        {
            return true;
        }
        return false;
    }


}
