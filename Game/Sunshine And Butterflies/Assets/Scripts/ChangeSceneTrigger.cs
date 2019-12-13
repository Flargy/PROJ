using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour
{
    
    private int playerCount = 0;
    private bool activated = false;

    /// <summary>
    /// Increases the value of <see cref="playerCount"/> when an object tagged with "Player" enters the trigger zone.
    /// Activates <see cref="ChangeScene"/> if the value is equals to 2.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCount++;
            if (playerCount == 2)
            {
                activated = true;
                ChangeScene();
            }
        }
    }

    /// <summary>
    /// Lowers the value of <see cref="playerCount"/> when an object tagged with "Player" leaves the trigger zone.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCount--;
        }
    }

    /// <summary>
    /// Loads the next scene in the build order
    /// </summary>
    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
