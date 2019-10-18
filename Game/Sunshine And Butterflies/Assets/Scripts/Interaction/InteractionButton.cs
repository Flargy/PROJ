using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : Interactable
{
    [SerializeField] private AffectedObject affectedObject = null;

    public override void Interact(GameObject player)
    {
        affectedObject.ExecuteAction();
    }

    
}
