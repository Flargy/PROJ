using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactionRadius = 2.0f; // Position for player to stand when interacting
    

    public virtual void Interact()
    {
        // will be overwritten by inheritage
    }

    public virtual void Interact(GameObject player)
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    public void DistanceCheck(Vector3 playerPosition)
    {
        if((playerPosition - transform.position).sqrMagnitude < interactionRadius * interactionRadius)
        {
            Interact();
        }
    }

   
}
