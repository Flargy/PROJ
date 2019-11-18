using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInteraction : MonoBehaviour
{
    [SerializeField] private int otherPlayer = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9 || other.gameObject.layer == otherPlayer) { 
        other.GetComponent<Interactable>().ShowInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == otherPlayer)
        { 

            other.GetComponent<Interactable>().HideInteraction();
        }
    }
}
