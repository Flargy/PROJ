using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour
{
    [SerializeField] private int sceneNumber = 0;
    
    private int playerCount = 0;
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCount++;
            if (playerCount == 2)
            {
                activated = true;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerCount--;
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
