using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactionRadius = 2.0f; // Position for player to stand when interacting
    public float interactionCooldownTimer = 2.0f;
    public bool interacting = false;
    public GameObject interactionIcon = null;
    
    //Possible improvements: Break out the list and cooldown start function to this script

    public virtual void Interact(GameObject player)
    {
        // will be overwritten by inheritage
    }

    public virtual void Toss()
    {
        // will be overwritten by inheritage
    }

    public virtual void Teleport()
    {
        // will be overwritten by inheritage
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    public void DistanceCheck(GameObject player)
    {
        if((player.transform.position - transform.position).sqrMagnitude < interactionRadius * interactionRadius)
        {
            Interact(player);
        }
    }

    public void ShowInteraction()
    {
        if(interactionIcon != null)
        {
            interactionIcon.SetActive(true);
        }
    }

    public void HideInteraction()
    {
        if (interactionIcon != null)
        {
            interactionIcon.SetActive(false);
        }
    }

    public void StartInteraction()
    {
        StartCoroutine(InteractionCooldown());
    }

    public virtual IEnumerator InteractionCooldown()
    {
        interacting = true;
        yield return new WaitForSeconds(interactionCooldownTimer);
        interacting = false;
    }

}
