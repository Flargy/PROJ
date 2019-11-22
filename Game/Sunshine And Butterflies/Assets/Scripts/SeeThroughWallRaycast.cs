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
        RaycastHit hit;
        if(Physics.SphereCast(transform.position + Vector3.up * 0.6f, 0.45f, cam.transform.position - transform.position, out hit, 10.0f, wallLayer))
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
