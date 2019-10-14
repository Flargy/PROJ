using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Author: Debatable

public class PlayerStateMashine : StateMachine
{
    public float HorizontalDirection { get; set; }
    public float VerticalDirection { get; set; }
    public LayerMask GroundCheckLayer;


    protected override void Awake()
    {

        base.Awake();
    }

    /// <summary>
    /// Registers listeners.
    /// </summary>
    public void Start()
    {
        //GameComponents.FairGameList.Add(gameObject); // dynamically adds the player to the list once it awakes
        //EventHandeler.Current.RegisterListener(EventHandeler.EVENT_TYPE.TorchPickup, PickUpTorch);
        //EventHandeler.Current.RegisterListener(EventHandeler.EVENT_TYPE.QuestReward, AddReward);
        //EventHandeler.Current.RegisterListener(EventHandeler.EVENT_TYPE.Save, SavePlayer);
        //EventHandeler.Current.RegisterListener(EventHandeler.EVENT_TYPE.Load, LoadPlayer);
        //EventHandeler.Current.RegisterListener(EventHandeler.EVENT_TYPE.PlayerInteracting, FreezeMovement);
        //EventHandeler.Current.RegisterListener(EventHandeler.EVENT_TYPE.CinematicFreeze, CinematicFreeze);
        //EventHandeler.Current.RegisterListener(EventHandeler.EVENT_TYPE.CinematicResume, CinematicResume);

        EventHandeler.Current.RegisterListener(EventHandeler.EVENT_TYPE.PressButton, ChangeState);
        
    }

    //public void OnTest()
    //{
    //    TestEventInfo tei = new TestEventInfo { };
    //    EventHandeler.Current.FireEvent(EventHandeler.EVENT_TYPE.TestEvent, tei);
    //}

    private void ChangeState(EventInfo info)
    {
        PressButtonEventInfo pbei = (PressButtonEventInfo)info;
        Debug.Log(pbei.number);
    }


}
