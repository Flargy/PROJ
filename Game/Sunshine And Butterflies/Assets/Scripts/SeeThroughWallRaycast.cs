using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughWallRaycast : MonoBehaviour
{
    [SerializeField] private GameObject seeThrough = null;
    [SerializeField] private LayerMask wallLayer = 0;
    [SerializeField] private GameObject cam = null;
    [SerializeField] private float radius = 1.0f;

    private List<Vector3> castPoints;

    private void Awake()
    {
        castPoints = new List<Vector3>();
        castPoints.Add(Vector3.up * 0.6f);
        castPoints.Add(Vector3.up * 0.6f + Vector3.right * radius);
        castPoints.Add(Vector3.up * 0.6f + Vector3.left * radius);
        castPoints.Add(Vector3.up * 0.6f + Vector3.up * radius);
        castPoints.Add(Vector3.up * 0.6f + Vector3.down * radius);
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position + Vector3.up * 0.6f, cam.transform.position - transform.position + Vector3.up * 0.6f);
        Debug.DrawRay(transform.position + Vector3.up * 0.6f + Vector3.right * radius, cam.transform.position - transform.position + Vector3.up * 0.6f);
        Debug.DrawRay(transform.position + Vector3.up * 0.6f + Vector3.left * radius, cam.transform.position - transform.position + Vector3.up * 0.6f);
        Debug.DrawRay(transform.position + Vector3.up * 0.6f + Vector3.up * radius, cam.transform.position - transform.position + Vector3.up * 0.6f);
        Debug.DrawRay(transform.position + Vector3.up * 0.6f + Vector3.down * radius, cam.transform.position - transform.position + Vector3.up * 0.6f);


        RaycastHit hit;
        
        for ( int i = 0; i < 5; i++)
        {
            if(Physics.Raycast(transform.position + castPoints[i], cam.transform.position - transform.position, out hit, 20.0f, wallLayer))
            {
                seeThrough.transform.LookAt(cam.transform.position, Vector3.up);
                if (seeThrough.activeSelf == false)
                {
                    seeThrough.SetActive(true);
                    break;
                }
               
            }
            else
            {
                if (seeThrough.activeSelf == true)
                {
                    seeThrough.SetActive(false);
                }
            }
        }


        //if(Physics.SphereCast(transform.position + Vector3.up * 0.6f, radius, cam.transform.position - (transform.position + Vector3.up * 0.6f), out hit, 10.0f, wallLayer))
        //{
        //    seeThrough.transform.LookAt(cam.transform.position, Vector3.up);
        //    if (seeThrough.activeSelf == false)
        //    {
        //        seeThrough.SetActive(true);
        //    }
        //}
        //else
        //{
        //    if(seeThrough.activeSelf == true)
        //    {
        //        seeThrough.SetActive(false);
        //    }
        //}
    }

}
