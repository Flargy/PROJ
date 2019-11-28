using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughWallRaycast : MonoBehaviour
{
    [SerializeField] private GameObject seeThrough = null;
    [SerializeField] private LayerMask wallLayer = 0;
    [SerializeField] private GameObject cam = null;
    [SerializeField] private float radius = 1.0f;


    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position + Vector3.up * 0.6f, cam.transform.position - transform.position + Vector3.up * 0.6f);
        Debug.DrawRay(transform.position + Vector3.up * 0.6f + Vector3.right * radius, cam.transform.position - transform.position + Vector3.up * 0.6f);
        Debug.DrawRay(transform.position + Vector3.up * 0.6f + Vector3.left * radius, cam.transform.position - transform.position + Vector3.up * 0.6f);
        Debug.DrawRay(transform.position + Vector3.up * 0.6f + Vector3.up * radius, cam.transform.position - transform.position + Vector3.up * 0.6f);
        Debug.DrawRay(transform.position + Vector3.up * 0.6f + Vector3.down * radius, cam.transform.position - transform.position + Vector3.up * 0.6f);


        RaycastHit hit;
        if(Physics.SphereCast(transform.position + Vector3.up * 0.6f, radius, cam.transform.position - (transform.position + Vector3.up * 0.6f), out hit, 10.0f, wallLayer))
        {
            seeThrough.transform.LookAt(cam.transform.position, Vector3.up);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * 0.6f, radius);
    }
}
