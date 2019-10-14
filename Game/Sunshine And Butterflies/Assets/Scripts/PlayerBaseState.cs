using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Author: Debatable

public class PlayerBaseState : State
{
    protected PlayerStateMashine owner;
    protected Rigidbody rgb;


    public override void Initialize(StateMachine owner) {
        this.owner = (PlayerStateMashine)owner;
        Debug.Log(owner);
        rgb = owner.GetComponent<Rigidbody>();
        
        
    }






}
