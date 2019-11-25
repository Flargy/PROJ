using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughWallRaycast : MonoBehaviour
{
    [SerializeField] private GameObject seeThrough = null;
    [SerializeField] private LayerMask wallLayer = 0;
    [SerializeField] private GameObject cam = null;


    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position + Vector3.up * 0.6f, cam.transform.position - transform.position);

        RaycastHit hit;
        if(Physics.SphereCast(transform.position + Vector3.up * 0.6f, 1.5f, cam.transform.position - (transform.position + Vector3.up * 0.6f), out hit, 10.0f, wallLayer))
        {
            seeThrough.transform.LookAt(transform.position - cam.transform.position, Vector3.up);
            if (seeThrough.activeSelf == false)
            {
                seeThrough.SetActive(true);
            }
        }
        else
        {
            if(seeThrough.activeSelf == true)
            {
                seeThrough.SetActive(false);
            }
        }
    }
}
