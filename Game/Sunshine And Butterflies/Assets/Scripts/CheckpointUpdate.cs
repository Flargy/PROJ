using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUpdate : MonoBehaviour
{
    [SerializeField] private Transform[] respawnPositions = null;

    private GameObject firstPlayer = null;
    private int counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(firstPlayer == null)
            {
                firstPlayer = other.gameObject;
                other.GetComponent<NewPlayerScript>().ChangeSpawnPoint(respawnPositions[counter].position);
                counter++;
            }
            else if(firstPlayer != other.gameObject)
            {
                other.GetComponent<NewPlayerScript>().ChangeSpawnPoint(respawnPositions[counter].position);
                counter++;
            }
        }
        if (counter == respawnPositions.Length)
        {
            Destroy(gameObject);
        }
        

    }

    private void Start()
    {
        Debug.Log(respawnPositions.Length);
    }
}
