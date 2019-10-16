using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{

    GameObject[] arrowSpawns;
    public GameObject arrow;

    int arrowNum;
    // Start is called before the first frame update
    void Start()
    {
        arrowSpawns = GameObject.FindGameObjectsWithTag("ArrowSpawn");
    }

    private void OnTriggerEnter(Collider other)
    {
        arrowNum = Random.Range(1, arrowSpawns.Length);

        Debug.Log("Collide");
        if (other.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i < arrowNum; i++)
            {
                GameObject arrowPos = arrowSpawns[Random.Range(0, arrowSpawns.Length)];
                Instantiate(arrow, arrowPos.transform.position, arrowPos.transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
