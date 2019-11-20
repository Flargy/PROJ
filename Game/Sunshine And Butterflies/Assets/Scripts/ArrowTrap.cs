using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{

    [SerializeField] private GameObject[] arrowSpawns;
    [SerializeField] private GameObject arrow;
    [SerializeField] private bool timerBased;
    [SerializeField] private float fireTimer = 3f;
    [SerializeField] private float timer = 0f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            FireArrows();
            Debug.Log("Collide");

        }
    }

    void FireArrows()
    {
        for (int i = 0; i < arrowSpawns.Length; i++)
        {

            Instantiate(arrow, arrowSpawns[i].transform.position, arrowSpawns[i].transform.rotation);
        }

    }

    void Update()
    {
        if (timerBased == true)
        {
            if (timer <= fireTimer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                FireArrows();
                timer = 0f;
            }
        }
    }
}
