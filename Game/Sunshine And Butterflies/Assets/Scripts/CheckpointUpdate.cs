using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUpdate : MonoBehaviour
{
    [SerializeField] private Transform[] respawnPositions = null;

    private GameObject firstPlayer = null;
    private int counter = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(firstPlayer == null)
            {
                firstPlayer = other.gameObject;
                other.GetComponent<NewPlayerScript>().ChangeSpawnPoint(respawnPositions[counter -1].position);
            }
            else if(firstPlayer != other.gameObject)
            {
                other.GetComponent<NewPlayerScript>().ChangeSpawnPoint(respawnPositions[counter -1].position);
            }
        }
        if (counter == respawnPositions.Length)
        {
            Destroy(this);
        }
        counter++;

    }

    private void Start()
    {
        Debug.Log(respawnPositions.Length);
    }
}
