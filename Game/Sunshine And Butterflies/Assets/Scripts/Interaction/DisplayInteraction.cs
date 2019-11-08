using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Interactable>().ShowInteraction();
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Interactable>().HideInteraction();
    }
}
