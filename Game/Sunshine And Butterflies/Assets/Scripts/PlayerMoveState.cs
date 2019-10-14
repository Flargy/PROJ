using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerMoveState")]
public class PlayerMoveState : PlayerBaseState
{
    public override void Update()
    {

        rgb.velocity = owner.transform.rotation * Vector3.forward;
    }

    public override void Enter()
    {
        base.Enter();
    }
}
