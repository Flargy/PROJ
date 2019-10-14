using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Author: Debatable

public class PlayerStateMashine : StateMachine
{

    protected override void Awake()
    {
      
       
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

       

    }
    
   
}
