using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : Interactable
{
    [SerializeField] private AffectedObject affectedObject = null;

    public override void Interact(GameObject player)
    {
        if (interacting == false)
        {
            affectedObject.ExecuteAction();
            interacting = true;
            StartCoroutine(InteractionCooldown());
        }
    }

    private IEnumerator InteractionCooldown()
    {
        yield return new WaitForSeconds(interactionCooldownTimer);
        interacting = false;
    }

    
}
