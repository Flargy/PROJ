using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<NewPlayerScript>().Respawn();
        }
        else if (other.CompareTag("CarryBox"))
        {
            other.GetComponent<InteractionPickUp>().Respawn();
        }
    }
}
