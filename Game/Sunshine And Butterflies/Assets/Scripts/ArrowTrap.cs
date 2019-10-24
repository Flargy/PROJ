using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{

    public GameObject[] arrowSpawns;
    public GameObject arrow;

    public bool timerBased;
    public float fireTimer = 3f;
    public float timer = 0f;
    // Start is called before the first frame update

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

    // Update is called once per frame
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
