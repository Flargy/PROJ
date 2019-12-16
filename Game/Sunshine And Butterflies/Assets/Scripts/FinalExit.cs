using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalExit : MonoBehaviour
{
    [SerializeField] private GameObject player1, player2 = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
