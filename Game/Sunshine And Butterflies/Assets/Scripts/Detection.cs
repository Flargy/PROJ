using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    [SerializeField] private LayerMask detectionLayer;
    private Transform lens;
    void Start()
    {
        lens = transform.parent.GetComponent<Transform>();
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("inside field");
        if(other.gameObject.CompareTag("Player"))
        {
            Vector3 direction = other.transform.position - lens.position;
            RaycastHit hit;

            if(Physics.Raycast(lens.transform.position, direction.normalized, out hit, 1000, detectionLayer))
            {
                Debug.Log(hit.collider.name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("test");
        }
    }
}
