using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerAirState")]
public class PlayerAirState : PlayerBaseState
{
    public override void Update()
    {
        AirMovement();
        ApplyAirVelocity();
        if (GroundCheck() == true)
        {
            owner.TransitionTo<PlayerMoveState>();
        }
    }

    public override void Enter()
    {
    }

    public void AirMovement()
    {
        HorizontalDirection = Input.GetAxisRaw("Horizontal1");
        VerticalDirection = Input.GetAxisRaw("Vertical1");

    }

    public void ApplyAirVelocity()
    {
        Vector2 direction = new Vector2(HorizontalDirection, VerticalDirection);
        Vector2 currentVelocity = new Vector2(rgb.velocity.x, rgb.velocity.z);
        float turndot = Vector2.Dot(currentVelocity, direction);
        if(turndot < 0.3)
        {
            rgb.velocity += (new Vector3(HorizontalDirection, 0, VerticalDirection) * 0.05f);

        }
        //if (new Vector3(rgb.velocity.x, 0, rgb.velocity.y).magnitude >= 2.51f)
        //{
        //    float yVelocity = rgb.velocity.y;
        //    rgb.velocity = Vector3.ClampMagnitude(rgb.velocity, 2.5f);
        //    rgb.velocity = new Vector3(rgb.velocity.x, yVelocity, rgb.velocity.z);
        //}
    }
}
