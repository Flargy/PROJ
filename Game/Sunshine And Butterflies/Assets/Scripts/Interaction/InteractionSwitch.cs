using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSwitch : Interactable
{
    [SerializeField] public List<AffectedSwitch> affectedObjects;

    public override void Interact(GameObject player)
    {
        foreach(AffectedSwitch affected in affectedObjects)
        {
  
            affected.ExecuteAction();
        
        }
    }

}
