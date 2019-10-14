using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerAirState")]
public class PlayerAirState : PlayerBaseState
{
    public override void Update()
    {
        MovementInput();
        if (GroundCheck() == true)
        {
            owner.TransitionTo<PlayerMoveState>();
        }
        base.Update();
    }

    public override void Enter()
    {
        airMltiplier = 0.2f;
    }
}
