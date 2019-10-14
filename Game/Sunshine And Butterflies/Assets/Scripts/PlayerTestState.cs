using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerTestState")]
public class PlayerTestState : PlayerBaseState
{
    [SerializeField] private int sendNumber;

    public override void Enter()
    {
        Debug.Log("Entered state Test");
    }
   

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PressButtonEventInfo pbei = new PressButtonEventInfo { number = sendNumber };
            EventHandeler.Current.FireEvent(EventHandeler.EVENT_TYPE.PressButton, pbei);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(owner);
            owner.TransitionTo<PlayerMoveState>();
        }
        
    }

   

}
