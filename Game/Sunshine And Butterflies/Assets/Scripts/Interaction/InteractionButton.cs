using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : Interactable
{
    [SerializeField] private AffectedObject affectedObject;

    public override void Interact()
    {
        affectedObject.ExecuteAction();
    }

    
}
