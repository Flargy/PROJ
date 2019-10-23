using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{

    public GameObject[] arrowSpawns;
    public GameObject arrow;

    public int arrowNum;
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
        arrowNum = arrowSpawns.Length;
        for (int i = 0; i < arrowNum; i++)
        {
            //GameObject arrowPos = arrowSpawns(arrow);
            Instantiate(arrow, arrowPos.transform.position, arrowPos.transform.rotation);
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
