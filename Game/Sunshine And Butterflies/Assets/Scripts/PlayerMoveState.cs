using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerMoveState")]
public class PlayerMoveState : PlayerBaseState
{

    private float jumpPower = 5;

    public override void Update()
    {
        MovementInput();
        Jump();
        base.Update();
        if (GroundCheck() == false)
        {
            owner.TransitionTo<PlayerAirState>();
        }

    }

    public override void Enter()
    {
        airMltiplier = 1.0f;
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump1") && GroundCheck())
        {

            rgb.velocity += Vector3.up * jumpPower;
        }
    }

    

   
}
