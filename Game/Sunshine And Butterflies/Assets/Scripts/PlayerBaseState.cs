using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Author: Debatable

public class PlayerBaseState : State
{
    protected PlayerStateMashine owner;


    public override void Initialize(StateMachine owner) {
        this.owner = (PlayerStateMashine)owner;
       
    }

    public override void Update()
    {
       
    }
    
    

}
